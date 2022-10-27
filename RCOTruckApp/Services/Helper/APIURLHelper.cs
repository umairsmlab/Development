using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.Services.Helper
{
    internal class APIURLHelper
    {
        public static string BaseURL { get; set; } = ConfigurationManager.AppSettings["BaseURL"];

        public const string LoginURL = "userservice/authenticateUser/";
        public const string GetUserInfoURL = "userservice/getUserInfo/";
        public const string ELDEventsCount = "recordservice/getRecordsUpdatedXFilteredCount/dragosi/dragosi/ELD%20Event/-5000/0/+/+/+/DriverRecordId/,/1909158/,/+/+/";
        public const string ELDEventsRecords = "recordservice/getRecordsUpdatedXFiltered/dragosi/dragosi/ELD%20Event/-5000/timeStampValue/+/+/+/DriverRecordId/,/1909158/,/+/+";


    }
}
