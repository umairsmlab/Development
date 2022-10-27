using RCOTruckApp.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.Repository.Log
{
    internal class LogRepository
    {
        RCOTruckDBContext rCOTruckDBContext = new RCOTruckDBContext();

        internal void AddLog(int logType, string ActionName, string LogText, int userID)
        {
            Models.Log.Log log = new Models.Log.Log();
            log.LogType = logType;
            log.ActionName = ActionName;
            log.LogText = LogText;
            log.UserID = userID;
            log.CreatedDate = DateTime.Now;

            rCOTruckDBContext.Logs.Add(log);
            rCOTruckDBContext.SaveChanges();
        }

    }
}
