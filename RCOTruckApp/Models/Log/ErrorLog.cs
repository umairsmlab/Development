using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.Models.Log
{
    public class ErrorLog
    {
        public int ErrorLogID { get; set; }
        public int LogType { get; set; }
        public string ActionName { get; set; }
        public string LogText { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
