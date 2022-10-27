using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.StaticServices
{
    /// <summary>
    /// UserService
    /// </summary>
    internal class UserService
    {
        /// <summary>
        /// Logged In UserName
        /// </summary>
        internal static Models.User.User LoggedInUser { get; set; }
        internal static Models.User.Credentials LoggedInUserCredentials { get; set; }

        /// <summary>
        /// Driver
        /// </summary>
        internal static Models.Driver.Driver Driver { get; set; }

        /// <summary>
        /// Truck
        /// </summary>
        internal static Models.Trucks.Truck Truck { get; set; }

        public static string TruckNumber { get; set; }
        public static string Trailer1Number { get; set; }
        public static string Trailer2Number { get; set; }
        public static bool isMainWindowOpened { get; set; }
    }
}
