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
            var automaticIntensityValue = db.HouseParameters.SingleOrDefault(x => x.ParameterId.ToString() == "38ED76B4-FF9A-49FE-B547-F737E4E9F5E3").Value;
            var t = Task.Run(() => HttpHelper.PostAsync("automaticLedIntensity?value=" + automaticIntensityValue));
            t.Wait();

            var groundLedStatus = db.HouseParameters.SingleOrDefault(x => x.ParameterId.ToString() == "48F4CD81-FFFA-4F26-92CE-D6D4196F84B6").Value;
            var floorLedStatus = db.HouseParameters.SingleOrDefault(x => x.ParameterId.ToString() == "CBA58E71-3A17-4369-A99A-250E63E9F557").Value;
            t = Task.Run(() => HttpHelper.PostAsync("initLedStatus?ground=" + groundLedStatus + "&floor=" + floorLedStatus));
            t.Wait();
        }
    }
}