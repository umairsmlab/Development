using System;

using System.ComponentModel.DataAnnotations.Schema;

namespace RCOTruckApp.Models.Driver
{
    public class Driver
    {
        /// <summary>
        /// DriverID
        /// </summary>
        public int DriverID { get; set; }

        /// <summary>
        /// UserID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// TruckID
        /// </summary>
        public int TruckID { get; set; }

        /// <summary>
        /// DriverName
        /// </summary>
        public string DriverName { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// CreatedDate
        /// </summary>
        public DateTime CreatedDate{ get; set; }
    }
}
