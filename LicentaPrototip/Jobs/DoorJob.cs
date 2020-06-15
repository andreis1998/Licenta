using LicentaPrototip.Utilities;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LicentaPrototip.Jobs
{
    public class DoorJob : IJob
    {
        public HttpUtilities HttpHelper = new HttpUtilities();

        public void Execute(IJobExecutionContext context)
        {
            var t = Task.Run(() => HttpHelper.PostAsync("controlDoor"));
            t.Wait();
        }
    }
}