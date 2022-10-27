using RCOTruckApp.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.Repository.DriverStatus
{
    internal class DriverStatusRepository
    {
        RCOTruckDBContext rCOTruckDBContext = new RCOTruckDBContext();

        internal void UpdateDriverStatus(string status)
        {
            //int driverID = StaticServices.UserService.Driver.DriverID;
            //Models.Driver.Driver driver = rCOTruckDBContext.Drivers.FirstOrDefault(x => x.DriverID == driverID);
            //if(driver != null)
            //{
            //    driver.Status = status;
            //    rCOTruckDBContext.SaveChanges();
            //    StaticServices.UserService.Driver = driver;
            //}
        }
    }
}
