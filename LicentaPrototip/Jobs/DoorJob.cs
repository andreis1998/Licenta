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
    public class DoorJob : IJob
    {
        public HttpUtilities HttpHelper = new HttpUtilities();
        public AppDbContext db = new AppDbContext();

        public void Execute(IJobExecutionContext context)
        {
            var automaticDoor = db.HouseParameters.SingleOrDefault(x => x.ParameterId.ToString() == "60EDBB16-5F5A-42E9-B28C-2ADFE120326A").Value;

            if (automaticDoor == bool.TrueString)
            {
                var t = Task.Run(() => HttpHelper.PostAsync("controlDoor"));
                t.Wait();
            }
        }
    }
}