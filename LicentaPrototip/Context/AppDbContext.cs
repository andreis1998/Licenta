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
        public AppDbContext() : base("SmartHouseConnection")
        {
            Database.SetInitializer<AppDbContext>(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>());
        }

        public DbSet<HouseParameters> HouseParameters { get; set; }
        public DbSet<TemperatureLogs> TemperatureLogs { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
    }
}