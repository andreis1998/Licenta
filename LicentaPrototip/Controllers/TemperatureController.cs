using LicentaPrototip.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LicentaPrototip.Utilities;
using LicentaPrototip.SqlViews;
using LicentaPrototip.Models;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;

namespace LicentaPrototip.Controllers
{
    public class TemperatureController : Controller
    {
        public AppDbContext db = new AppDbContext();
        public HttpUtilities HttpHelper = new HttpUtilities();
        // GET: Temperature
        public ActionResult Index()
        {
            var lowTempLimit = db.HouseParameters.SingleOrDefault(x => x.Description == "LimitaInferioaraTemperatura").Value;
            var highTempLimit = db.HouseParameters.SingleOrDefault(x => x.Description == "LimitaSuperioaraTemperatura").Value;
            var model = new MyHouseModel();
            if (!string.IsNullOrEmpty(lowTempLimit))
            {
                model.LowLimitTemperature = int.Parse(lowTempLimit);
            }
            if (!string.IsNullOrEmpty(highTempLimit))
            {
                model.HighLimitTemperature = int.Parse(highTempLimit);
            }

            return View(model);
        }

        public string GetTemp()
        {
            var t = Task.Run(() => HttpHelper.PostAsync("temperature"));
            t.Wait();

            return t.Result;
        }

        public ActionResult ShowGraph()
        {
            return View("TemperatureGraph");
        }

        public ContentResult GetContent()
        {
            var dataPoints = new List<TemperatureGraphModel>();
            var temperatureLogs = db.TemperatureLogs.Select(x => x).ToList();
            foreach (var log in temperatureLogs)
            {
                dataPoints.Add(new TemperatureGraphModel
                {
                    TemperatureValue = double.Parse(log.Value),
                    DateLogged = log.Date
                });
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
            return Content(JsonConvert.SerializeObject(dataPoints, _jsonSetting), "application/json");
        }

        [HttpPost]
        public void SetLowLimit(string value)
        {
            var limit = db.HouseParameters.SingleOrDefault(x => x.Description == "LimitaInferioaraTemperatura");
            var lowAlertTriggered = db.HouseParameters.SingleOrDefault(x => x.ParameterId.ToString() == "54DAAB85-0953-4EA6-B905-E10FC958E846");

            if (limit != null)
            {
                limit.Value = value;
            }

            if (lowAlertTriggered != null)
            {
                lowAlertTriggered.Value = bool.FalseString;
            }

            db.SaveChanges();
        }

        [HttpPost]
        public void SetHighLimit(string value)
        {
            var limit = db.HouseParameters.SingleOrDefault(x => x.Description == "LimitaSuperioaraTemperatura");
            var highAlertTriggered = db.HouseParameters.SingleOrDefault(x => x.ParameterId.ToString() == "086989F7-A1AC-4E10-97CF-2030E1F069D1");

            if (limit != null)
            {
                limit.Value = value;
                
            }

            if (highAlertTriggered != null)
            {
                highAlertTriggered.Value = bool.FalseString;
            }

            db.SaveChanges();
        }


        [HttpGet]
        public void CheckTemperatureLimit()
        {
            var currentTemperature = db.HouseParameters.SingleOrDefault(x => x.Description == "TemperaturaInterioara").Value;
            var lowTempLimit = db.HouseParameters.SingleOrDefault(x => x.Description == "LimitaInferioaraTemperatura").Value;
            var highTempLimit = db.HouseParameters.SingleOrDefault(x => x.Description == "LimitaSuperioaraTemperatura").Value;
            var lowAlertTriggered = db.HouseParameters.SingleOrDefault(x => x.ParameterId.ToString() == "54DAAB85-0953-4EA6-B905-E10FC958E846");
            var highAlertTriggered = db.HouseParameters.SingleOrDefault(x => x.ParameterId.ToString() == "086989F7-A1AC-4E10-97CF-2030E1F069D1");

            if (float.Parse(currentTemperature) > float.Parse(highTempLimit) && highAlertTriggered.Value == bool.FalseString)
            {
                GenerateHighLimitAlert(highTempLimit);
                highAlertTriggered.Value = bool.TrueString;
                db.SaveChanges();
            }

            if (float.Parse(currentTemperature) < float.Parse(lowTempLimit) && lowAlertTriggered.Value == bool.FalseString)
            {
                GenerateLowLimitAlert(lowTempLimit);
                lowAlertTriggered.Value = bool.TrueString;
                db.SaveChanges();
            }
        }

        private void GenerateHighLimitAlert(string threshold)
        {
            using (var message = new MailMessage("andreis.serban1998@gmail.com", "andreis.serban1998@gmail.com"))
            {
                var dateAndTime = DateTime.Now;
                message.Subject = "Alerta temperatura casa";
                message.Body = "Temperatura in casa a depasit pragul stabilit de " + threshold + 
                    " ℃ la data de " + dateAndTime.ToShortDateString() + " si ora " + dateAndTime.ToLongTimeString();
                using (SmtpClient client = new SmtpClient
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    Port = 587,
                    Credentials = new NetworkCredential("andreis.serban1998@gmail.com", "Paganizondarhuayra1998#")
                })
                {
                    client.Send(message);
                }
            }
        }

        private void GenerateLowLimitAlert(string threshold)
        {
            using (var message = new MailMessage("andreis.serban1998@gmail.com", "andreis.serban1998@gmail.com"))
            {
                var dateAndTime = DateTime.Now;
                message.Subject = "Alerta temperatura casa";
                message.Body = "Temperatura in casa a scazut sub pragul stabilit de " + threshold + 
                    " ℃ la data de " + dateAndTime.ToShortDateString() + " si ora " + dateAndTime.ToLongTimeString();
                using (SmtpClient client = new SmtpClient
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    Port = 587,
                    Credentials = new NetworkCredential("andreis.serban1998@gmail.com", "Paganizondarhuayra1998#")
                })
                {
                    client.Send(message);
                }
            }
        }
    }
}