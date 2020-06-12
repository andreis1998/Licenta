using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LicentaPrototip.Utilities;
using LicentaPrototip.Models;
using LicentaPrototip.Context;

namespace LicentaPrototip.Controllers
{
    public class LightsController : Controller
    {
        public HttpUtilities HttpHelper = new HttpUtilities();
        public AppDbContext db = new AppDbContext();

        public ActionResult Index(MyHouseModel model)
        {

            model.IsLedIntensityAutomatic = bool.Parse(db.HouseParameters.SingleOrDefault(x => x.ParameterId.ToString() == "38ED76B4-FF9A-49FE-B547-F737E4E9F5E3").Value);
            model.IsGroundLedOn = bool.Parse(db.HouseParameters.SingleOrDefault(x => x.ParameterId.ToString() == "48F4CD81-FFFA-4F26-92CE-D6D4196F84B6").Value);
            model.IsFloorLedOn = bool.Parse(db.HouseParameters.SingleOrDefault(x => x.ParameterId.ToString() == "CBA58E71-3A17-4369-A99A-250E63E9F557").Value);

            return View(model);
        }

        [HttpPost]
        public void ToggleLed()
        {
            var t = Task.Run(() => HttpHelper.PostAsync("toggle"));
            t.Wait();
        }

        public ActionResult ToggleGreenLed()
        {
            var t = Task.Run(() => HttpHelper.PostAsync("toggleGreen"));
            t.Wait();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public void GroundLed(string status)
        {
            var t = Task.Run(() => HttpHelper.PostAsync("ledground"));
            t.Wait();

            var groundLedStatus = db.HouseParameters.SingleOrDefault(x => x.ParameterId.ToString() == "48F4CD81-FFFA-4F26-92CE-D6D4196F84B6");
            if (status == bool.TrueString.ToLower())
            {
                groundLedStatus.Value = bool.FalseString;
            }
            else
            {
                groundLedStatus.Value = bool.TrueString;
            }

            db.SaveChanges();
        }

        [HttpPost]
        public void FloorLed(string status)
        {
            var t = Task.Run(() => HttpHelper.PostAsync("ledfloor"));
            t.Wait();

            var floorLedStatus = db.HouseParameters.SingleOrDefault(x => x.ParameterId.ToString() == "CBA58E71-3A17-4369-A99A-250E63E9F557");
            if (status == bool.TrueString.ToLower())
            {
                floorLedStatus.Value = bool.FalseString;
            }
            else
            {
                floorLedStatus.Value = bool.TrueString;
            }

            db.SaveChanges();
        }

        [HttpPost]
        public void SetIntensity(string intensity)
        {
            var t = Task.Run(() => HttpHelper.PostAsync("led?intensity=" + intensity));
            t.Wait();
        }

        [HttpPost]
        public void SetAutomaticIntensity(string value)
        {
            var automaticIntensityValue = db.HouseParameters.SingleOrDefault(x => x.ParameterId.ToString() == "38ED76B4-FF9A-49FE-B547-F737E4E9F5E3");
            if (value == null)
            {
                if (automaticIntensityValue.Value == bool.TrueString)
                {
                    automaticIntensityValue.Value = bool.FalseString;
                    value = bool.FalseString;
                }
                else
                {
                    automaticIntensityValue.Value = bool.TrueString;
                    value = bool.TrueString;
                }
            }
            else
            {
                if (value != string.Empty)
                {
                    if (value == bool.FalseString.ToLower())
                    {
                        automaticIntensityValue.Value = bool.FalseString;
                        value = bool.FalseString;
                    }
                    else
                    {
                        automaticIntensityValue.Value = bool.TrueString;
                        value = bool.TrueString;
                    }
                }
                else
                {
                    return;
                }
            }

            db.SaveChanges();

            var t = Task.Run(() => HttpHelper.PostAsync("automaticLedIntensity?value=" + value));
            t.Wait();
        }
    }
}