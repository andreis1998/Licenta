using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Quartz;
using LicentaPrototip.Utilities;
using LicentaPrototip.Context;

namespace LicentaPrototip.Jobs
{
    public class TemperatureJob : IJob
    {
        public HttpUtilities HttpHelper = new HttpUtilities();
        public AppDbContext db = new AppDbContext();

        public void Execute(IJobExecutionContext context)
        {
            var t = Task.Run(() => HttpHelper.PostAsync("temperature"));
            t.Wait();
            var temperature = db.HouseParameters.SingleOrDefault(x => x.Description == "TemperaturaInterioara");
            if (temperature != null)
            {
                if (t.Result != null)
                {
                    temperature.Value = t.Result;
                    db.SaveChanges();
                }
            }
        }
    }
}