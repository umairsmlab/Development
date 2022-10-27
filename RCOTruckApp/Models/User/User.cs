using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.Models.User
{
    public class User
    {
        public int id { get; set; }
        
        public string rmsUserId { get; set; }

        public string recordId { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string employeeId { get; set; }
        public string itemType { get; set; }
        public string trucknumber { get; set; }
        public string trailernumber { get; set; }

        
    }
}
