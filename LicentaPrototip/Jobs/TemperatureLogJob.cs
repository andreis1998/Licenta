using LicentaPrototip.Context;
using LicentaPrototip.SqlViews;
using LicentaPrototip.Utilities;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicentaPrototip.Jobs
{
    public class TemperatureLogJob : IJob
    {
        public HttpUtilities HttpHelper = new HttpUtilities();
        public AppDbContext db = new AppDbContext();

        public void Execute(IJobExecutionContext context)
        {
            var currentTemperature = db.HouseParameters.SingleOrDefault(x => x.Description == "TemperaturaInterioara").Value;

            if (!string.IsNullOrEmpty(currentTemperature))
            {
                if (currentTemperature.First() != '-' && currentTemperature.First() != '−')
                {
                    db.TemperatureLogs.Add(new TemperatureLogs
                    {
                        Value = currentTemperature,
                        Date = DateTime.UtcNow.AddHours(3)
                    });

                    db.SaveChanges();
                }
            }
        }
    }
}