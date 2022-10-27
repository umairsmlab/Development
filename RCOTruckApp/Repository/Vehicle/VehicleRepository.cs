using RCOTruckApp.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.Repository.Vehicle
{
    internal class VehicleRepository
    {
        RCOTruckDBContext rCOTruckDBContext = new RCOTruckDBContext();

        internal bool VerifyVehicleInfo(string vehicleNumber)
        {
            bool isValid = true;
            Models.Trucks.Truck truck = rCOTruckDBContext.Trucks.FirstOrDefault(x => x.TruckNumber == vehicleNumber);
            if(truck != null && truck.TruckID > 0)
            {
                //int userID = StaticServices.UserService.LoggedInUser.UserID;
                //Models.Driver.Driver driver = rCOTruckDBContext.Drivers.FirstOrDefault(x => x.UserID == userID && x.TruckID == truck.TruckID);
                //if (driver != null && driver.DriverID > 0)
                //{
                //    StaticServices.UserService.Truck = truck;
                //    StaticServices.UserService.Driver = driver;
                //    isValid = true;
                //}
                return true;
            }
                return isValid;
        }
    }
}
