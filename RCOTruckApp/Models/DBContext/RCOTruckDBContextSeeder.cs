using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.Models.DBContext
{
    internal class RCOTruckDBContextSeeder : DropCreateDatabaseIfModelChanges<Models.DBContext.RCOTruckDBContext>
    {
        protected override void Seed(RCOTruckDBContext context)
        {
            //User.User user = new User.User()
            //{ 
            //    UserName = "test",
            //    Password = "test",
            //    Email = "test@gmail.com",
            //    IsActive = true,
            //    Archived = false,
            //    VersionUserID = 0,
            //    VersionDate = DateTime.Now,
            //    CreatedDate = DateTime.Now,
            //};

            //Trucks.Truck truck = new Trucks.Truck()
            //{
            //    TruckNumber = "123",
            //    CreatedDate = DateTime.Now
            //};

            //Driver.Driver driver = new Driver.Driver()
            //{
            //    DriverName = "TestDriver",
            //    UserID = 1,
            //    TruckID = 1,
            //    Status = "",
            //    CreatedDate = DateTime.Now,
            //};


            //context.Users.Add(user);
            //context.Trucks.Add(truck);
            //context.Drivers.Add(driver);

            //context.SaveChanges();
            //base.Seed(context);
        }
    }
}
