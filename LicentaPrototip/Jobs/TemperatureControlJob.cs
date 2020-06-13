using LicentaPrototip.Context;
using LicentaPrototip.Utilities;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LicentaPrototip.Jobs
{
    public class TemperatureControlJob : IJob
    {
        public HttpUtilities HttpHelper = new HttpUtilities();
        public AppDbContext db = new AppDbContext();

        public void Execute(IJobExecutionContext context)
        {
            var setPoint = db.HouseParameters.SingleOrDefault(x => x.ParameterId.ToString() == "02E1271D-D30C-4C16-8010-E729099CC7E3").Value;

            var t = Task.Run(() => HttpHelper.PostAsync("controlTemperature?setpoint=" + setPoint));
            t.Wait();
        }
    }
}