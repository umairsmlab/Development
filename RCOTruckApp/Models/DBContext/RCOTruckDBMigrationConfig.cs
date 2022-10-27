using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.Models.DBContext
{
    public sealed class RCOTruckDBMigrationConfig : DbMigrationsConfiguration<RCOTruckDBContext>
    {
        public RCOTruckDBMigrationConfig()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

    }
}
