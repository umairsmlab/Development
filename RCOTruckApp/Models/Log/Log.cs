using System;

namespace RCOTruckApp.Models.Log
{
    public class Log
    {
        public int LogID { get; set; }
        public int LogType { get; set; }
        public string ActionName { get; set; }
        public string LogText { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
