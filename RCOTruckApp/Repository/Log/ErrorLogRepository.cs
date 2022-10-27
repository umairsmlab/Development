using RCOTruckApp.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCOTruckApp.Repository.Log
{
    internal class ErrorLogRepository
    {
        RCOTruckDBContext rCOTruckDBContext = new RCOTruckDBContext();

        internal void AddLog(int logType, string ActionName, string LogText, int userID)
        {
            Models.Log.ErrorLog errorLog = new Models.Log.ErrorLog();
            errorLog.LogType = logType;
            errorLog.ActionName = ActionName;
            errorLog.LogText = LogText;
            errorLog.UserID = userID;
            errorLog.CreatedDate = DateTime.Now;

            rCOTruckDBContext.ErrorLogs.Add(errorLog);
            rCOTruckDBContext.SaveChanges();
        }
    }
}
