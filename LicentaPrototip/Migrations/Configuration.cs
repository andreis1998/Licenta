using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using LicentaPrototip.Context;
using LicentaPrototip.SqlViews;

namespace LicentaPrototip.Migrations
{
    public class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //protected override void Seed(AppDbContext context)
        //{
        //    if (!context.HouseParameters.Any(x => x.Description == "TemperaturaInterioara"))
        //    {
        //        context.HouseParameters.AddOrUpdate(new HouseParameters()
        //        {
        //            Description = "TemperaturaInterioara",
        //            ParameterId = Guid.NewGuid()
        //        });
        //    }

        //    //context.Database.ExecuteSqlCommand("delete from HouseParameters");
        //}
    }
}