using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.ViewModels.PreTrip
{
    internal class PreTripCheckListHistoryViewModel
    {
        public int PreTripCheckListID { get; set; }
        public DateTime Date { get; set; }

        [Display(Name ="Truck Number")]
        public string TruckNumber { get; set; }

        [Display(Name = "Trailer 1 Number")]
        public string  Trailer1Number { get; set; }

        [Display(Name = "Trailer 2 Number")]
        public string Trailer2Number { get; set; }

        public string DriverName { get; set; }
    }
}
