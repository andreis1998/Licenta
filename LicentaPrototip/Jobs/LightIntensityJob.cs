using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LicentaPrototip.Utilities;
using System.Threading.Tasks;

namespace LicentaPrototip.Jobs
{
    public class LightIntensityJob : IJob
    {
        public HttpUtilities HttpHelper = new HttpUtilities();

        public void Execute(IJobExecutionContext context)
        {
            var t = Task.Run(() => HttpHelper.PostAsync("controlLedIntensity"));
            t.Wait();
        }
    }
}