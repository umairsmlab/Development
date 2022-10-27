using RCOTruckApp.Repository.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.StaticServices
{
    internal static class LogTypes
    {
        public static int User = 1;
        
        public static int VehicleInfo = 3;
        public static int DriverStatus = 4;
        public static int Login = 5;
        public static int Logout = 6;
        public static int Exception = 9;
    }

    internal static class LogService
    {
        internal static void Log(int logType,string ActionName,string LogText,int userID)
        {
            LogRepository logRepository = new LogRepository();
            logRepository.AddLog(logType, ActionName, LogText,userID);
        }

        internal static void LogException(string ActionName, string LogText, int userID)
        {
            LogRepository logRepository = new LogRepository();
            logRepository.AddLog(LogTypes.Exception, ActionName, LogText, userID);
        }
    }
}
