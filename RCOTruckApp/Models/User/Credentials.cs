using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.Models.User
{
    public class Credentials
    {
        public int id { get; set; }
        public string rmsUserId { get; set; }
        public string username { get; set; }
        public string password { get; set; }

    }
}
