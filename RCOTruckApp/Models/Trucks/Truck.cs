using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.Models.Trucks
{
    public class Truck
    {
        /// <summary>
        /// TruckID
        /// </summary>
        public int TruckID { get; set; }

        /// <summary>
        /// TruckNumber
        /// </summary>
        public string TruckNumber { get; set; }

        /// <summary>
        /// trailer 1 info
        /// </summary>
        public string trailer { get; set; }

        /// <summary>
        /// trailer2 info
        /// </summary>
        public string trailer2 { get; set; }

        /// <summary>
        /// CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
