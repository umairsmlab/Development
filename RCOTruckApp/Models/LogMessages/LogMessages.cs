using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.Models.LogMessages
{
    internal class LogMessages
    {
        public int LogMessagesID { get; set; }
        public string Topic { get; set; }
        public string Msg { get; set; }
        public string Status { get; set; }
        public string Username { get; set; }
    }
}
