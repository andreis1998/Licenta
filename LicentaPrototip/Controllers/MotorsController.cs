using LicentaPrototip.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LicentaPrototip.Controllers
{
    public class MotorsController : Controller
    {
        public HttpUtilities HttpHelper = new HttpUtilities();

        // GET: Motors
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void OpenDoor()
        {
            var t = Task.Run(() => HttpHelper.PostAsync("openDoor"));
            t.Wait();
        }

        [HttpPost]
        public void CloseDoor()
        {
            var t = Task.Run(() => HttpHelper.PostAsync("closeDoor"));
            t.Wait();
        }
    }
}