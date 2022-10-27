using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.Models.User
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ArCodingInfo
    {
        public string displayName { get; set; }
        public string value { get; set; }
    }

    public class UserResponseModel
    {
        public int LobjectId { get; set; }
        public string objectType { get; set; }
        public string loginId { get; set; }
        public string password { get; set; }
        public List<string> roles { get; set; }
        public List<ArCodingInfo> arCodingInfo { get; set; }
        
    }
    
}
