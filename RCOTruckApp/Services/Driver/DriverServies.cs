using RCOTruckApp.Repository.DriverStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.Services.Driver
{
    internal class DriverServies
    {
        DriverStatusRepository driverStatusRepository = new DriverStatusRepository();

        internal void UpdateDriverStatus(string status)
        {
            driverStatusRepository.UpdateDriverStatus(status);
        }
    }
}
