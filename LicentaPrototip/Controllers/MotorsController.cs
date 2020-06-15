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
    public class MotorsController : Controller
    {
        public HttpUtilities HttpHelper = new HttpUtilities();
        public AppDbContext db = new AppDbContext();

        // GET: Motors
        public ActionResult Index(MyHouseModel model)
        {
            var automaticDoor = db.HouseParameters.SingleOrDefault(x => x.ParameterId.ToString() == "60EDBB16-5F5A-42E9-B28C-2ADFE120326A").Value;
            if (!string.IsNullOrEmpty(automaticDoor))
            {
                model.IsDoorAutomatic = bool.Parse(automaticDoor);
            }

            return View(model);
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

        [HttpPost]
        public void SetAutomaticDoor()
        {
            var t = Task.Run(() => HttpHelper.PostAsync("autoDoor"));
            t.Wait();

            var automaticDoorValue = db.HouseParameters.SingleOrDefault(x => x.ParameterId.ToString() == "60EDBB16-5F5A-42E9-B28C-2ADFE120326A");
            if (automaticDoorValue.Value == bool.TrueString)
            {
                automaticDoorValue.Value = bool.FalseString;
            }
            else
            {
                automaticDoorValue.Value = bool.TrueString;
            }

            db.SaveChanges();
        }
    }
}