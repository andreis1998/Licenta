using LicentaPrototip.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LicentaPrototip.Controllers
{
    public class TemperatureController : Controller
    {
        public AppDbContext db = new AppDbContext();
        // GET: Temperature
        public ActionResult Index()
        {
            return View();
        }

        public string GetTemp()
        {
            return db.HouseParameters.SingleOrDefault(x => x.Description == "TemperaturaInterioara").Value;
        }
    }
}