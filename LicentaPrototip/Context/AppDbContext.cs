using LicentaPrototip.SqlViews;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LicentaPrototip.Migrations;

namespace LicentaPrototip.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("SmartHouse")
        {
            Database.SetInitializer<AppDbContext>(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>());
            //Database.SetInitializer<AppDbContext>(null);
        }

        public DbSet<HouseParameters> HouseParameters { get; set; }
    }
}