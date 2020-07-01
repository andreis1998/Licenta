using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LicentaPrototip.Utilities;
using System.Threading.Tasks;
using LicentaPrototip.Context;

namespace LicentaPrototip.Jobs
{
    public class LightIntensityJob : IJob
    {
        public HttpUtilities HttpHelper = new HttpUtilities();
        public AppDbContext db = new AppDbContext();

        public void Execute(IJobExecutionContext context)
        {
            var automaticIntensity = db.HouseParameters.SingleOrDefault(x => x.ParameterId.ToString() == "38ED76B4-FF9A-49FE-B547-F737E4E9F5E3").Value;

            if (automaticIntensity == bool.TrueString)
            {
                var t = Task.Run(() => HttpHelper.PostAsync("controlLedIntensity"));
                t.Wait();
            }
        }
    }
}