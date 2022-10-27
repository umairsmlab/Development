using RCOTruckApp.Repository.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.Services.Vehicle
{

    internal class VehicleServices
    {
        VehicleRepository vehicleRepository = new VehicleRepository();

        internal bool VerifyVehicleInfo(string vehicleNumber)
        {
            return vehicleRepository.VerifyVehicleInfo(vehicleNumber);
        }
    }
}
