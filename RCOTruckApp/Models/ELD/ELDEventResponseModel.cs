using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.Models.ELD
{
    public class MapCodingInfo
    {
        [JsonProperty("Record Origin")]
        public string RecordOrigin { get; set; }

        [JsonProperty("Event Code")]
        public string EventCode { get; set; }

        [JsonProperty("Event Code Description")]
        public string EventCodeDescription { get; set; }
        public string BarCode { get; set; }
        public string DriverRecordId { get; set; }
        public string Time { get; set; }

        [JsonProperty("Organization Number")]
        public string OrganizationNumber { get; set; }
        public string DateTime { get; set; }

        [JsonProperty("Engine Hours")]
        public string EngineHours { get; set; }

        [JsonProperty("Order Number User")]
        public string OrderNumberUser { get; set; }

        [JsonProperty("RMS Coding Timestamp")]
        public string RMSCodingTimestamp { get; set; }
        public string RecordId { get; set; }
        public string CheckData { get; set; }

        [JsonProperty("Record Status")]
        public string RecordStatus { get; set; }

        [JsonProperty("Organization Name")]
        public string OrganizationName { get; set; }

        [JsonProperty("ELD Username")]
        public string ELDUsername { get; set; }

        [JsonProperty("Localization Description")]
        public string LocalizationDescription { get; set; }
        public string RecordOriginId { get; set; }
        public string MobileRecordId { get; set; }
        public string Odometer { get; set; }

        [JsonProperty("Latitude String")]
        public string LatitudeString { get; set; }

        [JsonProperty("Driver Last Name")]
        public string DriverLastName { get; set; }

        [JsonProperty("Creation Time")]
        public string CreationTime { get; set; }
        public string Date { get; set; }
        public string ObjectName { get; set; }

        [JsonProperty("Sequence Id")]
        public string SequenceId { get; set; }

        [JsonProperty("Driver First Name")]
        public string DriverFirstName { get; set; }

        [JsonProperty("Event Seconds")]
        public string EventSeconds { get; set; }

        [JsonProperty("Creation Date")]
        public string CreationDate { get; set; }

        [JsonProperty("Longitude String")]
        public string LongitudeString { get; set; }
        public string CheckSum { get; set; }

        [JsonProperty("Event Type")]
        public string EventType { get; set; }

        [JsonProperty("RMS Timestamp")]
        public string RMSTimestamp { get; set; }
        public string VIN { get; set; }

        [JsonProperty("Vehicle Miles")]
        public string VehicleMiles { get; set; }

        [JsonProperty("Order Number CMV")]
        public string OrderNumberCMV { get; set; }

        [JsonProperty("Shift Start")]
        public string ShiftStart { get; set; }
    }

    public class ELDEventResponseModel
    {
        public int LobjectId { get; set; }
        public string objectType { get; set; }
        public int iCsvRow { get; set; }
        public string mobileRecordId { get; set; }
        public MapCodingInfo mapCodingInfo { get; set; }
    }

}
