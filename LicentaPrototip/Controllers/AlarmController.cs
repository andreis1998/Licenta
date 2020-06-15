using LicentaPrototip.Context;
using LicentaPrototip.Models;
using LicentaPrototip.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LicentaPrototip.Controllers
{
    public class AlarmController : Controller
    {
        public HttpUtilities HttpHelper = new HttpUtilities();
        public AppDbContext db = new AppDbContext();

        public ActionResult Index(MyHouseModel model)
        {
            var alarm = db.HouseParameters.SingleOrDefault(x => x.ParameterId.ToString() == "0AB213B4-4FA8-4F74-8EF6-9AE185EFF862").Value;

            if (!string.IsNullOrEmpty(alarm))
            {
                model.IsAlarmOn = bool.Parse(alarm);
            }
            return View(model);
        }

        [HttpPost]
        public void SetAlarm()
        {
            var alarm = db.HouseParameters.SingleOrDefault(x => x.ParameterId.ToString() == "0AB213B4-4FA8-4F74-8EF6-9AE185EFF862");
            if (alarm.Value == bool.TrueString)
            {
                alarm.Value = bool.FalseString;
            }
            else
            {
                alarm.Value = bool.TrueString;
            }
            db.SaveChanges();

            var t = Task.Run(() => HttpHelper.PostAsync("setAlarm"));
            t.Wait();
        }
    }
}