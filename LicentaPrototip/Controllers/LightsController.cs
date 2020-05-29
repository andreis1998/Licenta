using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LicentaPrototip.Utilities;
using LicentaPrototip.Models;

namespace LicentaPrototip.Controllers
{
    public class LightsController : Controller
    {
        public HttpUtilities HttpHelper = new HttpUtilities();

        public ActionResult Index(MyHouseModel model)
        {
            if (model == null)
            {
                model.Temperature = string.Empty;
                return View(model);
            }

            return View(model);
        }

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
    }
}