using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LicentaPrototip.Context;
using LicentaPrototip.Utilities;

namespace LicentaPrototip.App_Start
{
    public class InitialConfiguration
    {
        public static AppDbContext db = new AppDbContext();
        public static HttpUtilities HttpHelper = new HttpUtilities();

        public static void Load()
        {
            var automaticIntensityValue = db.HouseParameters.SingleOrDefault(x => x.Description == "IntensitateAutomata").Value;

            var t = Task.Run(() => HttpHelper.PostAsync("automaticLedIntensity?value=" + automaticIntensityValue));
            t.Wait();
        }
    }
}