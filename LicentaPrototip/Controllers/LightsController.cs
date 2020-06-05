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

            model.IsLedIntensityAutomatic = bool.Parse(db.HouseParameters.SingleOrDefault(x => x.Description == "IntensitateAutomata").Value);

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

        public ActionResult OpenDoor()
        {
            var t = Task.Run(() => HttpHelper.PostAsync("openDoor"));
            t.Wait();

            return RedirectToAction("Index");
        }

        public ActionResult CloseDoor()
        {
            var t = Task.Run(() => HttpHelper.PostAsync("closeDoor"));
            t.Wait();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public string ShowTemp()
        {
            var t = Task.Run(() => HttpHelper.PostAsync("temperature"));
            t.Wait();

            return t.Result;
        }

        [HttpPost]
        public void SetIntensity(string intensity)
        {
            var t = Task.Run(() => HttpHelper.PostAsync("led?intensity=" + intensity));
            t.Wait();
        }

        [HttpPost]
        public void SetAutomaticIntensity()
        {
            var t = Task.Run(() => HttpHelper.PostAsync("automaticLedIntensity"));
            t.Wait();

            var automaticIntensityValue = db.HouseParameters.SingleOrDefault(x => x.Description == "IntensitateAutomata");
            if (automaticIntensityValue.Value == bool.TrueString)
            {
                automaticIntensityValue.Value = bool.FalseString;
            }
            else
            {
                automaticIntensityValue.Value = bool.TrueString;
            }

            db.SaveChanges();
        }
    }
}