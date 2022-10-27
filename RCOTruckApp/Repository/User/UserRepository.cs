using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RCOTruckApp.Models.DBContext;
using RCOTruckApp.Models.User;
using RCOTruckApp.Services.Helper;

namespace RCOTruckApp.Repository.User
{
    internal class UserRepository
    {
        RCOTruckDBContext rCOTruckDBContext = new RCOTruckDBContext();
        internal List<Models.User.User> GetUsers()
        {
            return rCOTruckDBContext.Users.ToList();
        }
        internal bool VerifyUserLoginOnline(string userName, string password)
        {
            using (var client = new HttpClient())
            {
                string LoginURL = APIURLHelper.LoginURL + userName +"/" +password;
                client.BaseAddress = new Uri(APIURLHelper.BaseURL);
                HttpResponseMessage response = client.GetAsync(LoginURL).Result;
                var json = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode && json.Equals("\"true\""))
                {
                    string UserInfoURL = APIURLHelper.GetUserInfoURL + userName + "/" + password;

                    response = client.GetAsync(UserInfoURL).Result;
                    var getUserInfoJson = response.Content.ReadAsStringAsync().Result;
                    UserResponseModel responseuserInfo = JsonConvert.DeserializeObject<UserResponseModel>(getUserInfoJson);

                    var rmsUserId = GetDisplayValue(responseuserInfo.arCodingInfo, "RMS User Id");
                    var credential = rCOTruckDBContext.Credentials.FirstOrDefault(x=>x.rmsUserId == rmsUserId);
                    if (credential == null)
                    {
                        rCOTruckDBContext.Credentials.Add(new Credentials
                        {
                            username = userName,
                            password = password,
                            rmsUserId = GetDisplayValue(responseuserInfo.arCodingInfo, "RMS User Id")
                        });
                    }
                    else
                    {
                        credential.username = userName;
                        credential.password = password;
                        credential.rmsUserId = GetDisplayValue(responseuserInfo.arCodingInfo, "RMS User Id");

                    }

                    StaticServices.UserService.LoggedInUserCredentials = credential;

                    var userInfo = rCOTruckDBContext.Users.FirstOrDefault(x => x.rmsUserId == rmsUserId);
                    if (userInfo == null)
                    {
                        rCOTruckDBContext.Users.Add(new Models.User.User
                        {
                            firstName = GetDisplayValue(responseuserInfo.arCodingInfo, "First Name"),
                            lastName = GetDisplayValue(responseuserInfo.arCodingInfo, "Last Name"),
                            itemType = GetDisplayValue(responseuserInfo.arCodingInfo, "ItemType"),
                            employeeId = GetDisplayValue(responseuserInfo.arCodingInfo, "Employee Id"),
                            recordId = GetDisplayValue(responseuserInfo.arCodingInfo, "RecordId"),
                            rmsUserId = GetDisplayValue(responseuserInfo.arCodingInfo, "RMS User Id"),
                            trailernumber = GetDisplayValue(responseuserInfo.arCodingInfo, ""),
                            trucknumber = GetDisplayValue(responseuserInfo.arCodingInfo, "Truck Number")
                        });
                    }
                    else
                    {
                        userInfo.firstName = GetDisplayValue(responseuserInfo.arCodingInfo, "First Name");
                        userInfo.lastName = GetDisplayValue(responseuserInfo.arCodingInfo, "Last Name");
                        userInfo.itemType = GetDisplayValue(responseuserInfo.arCodingInfo, "ItemType");
                        userInfo.employeeId = GetDisplayValue(responseuserInfo.arCodingInfo, "Employee Id");
                        userInfo.recordId = GetDisplayValue(responseuserInfo.arCodingInfo, "RecordId");
                        userInfo.rmsUserId = GetDisplayValue(responseuserInfo.arCodingInfo, "RMS User Id");
                        userInfo.trailernumber = GetDisplayValue(responseuserInfo.arCodingInfo, "");
                        userInfo.trucknumber = GetDisplayValue(responseuserInfo.arCodingInfo, "Truck Number");
                    }
                    rCOTruckDBContext.SaveChanges();
                    StaticServices.UserService.LoggedInUser = userInfo;
                    return true;
                }
                else
                {

                    return false;
                }
            }
        }
        internal bool VerifyUserLoginOffline(string userName, string password)
        {
            bool isValidLogin = false;
            Models.User.Credentials credentials = rCOTruckDBContext.Credentials.FirstOrDefault(x => x.username == userName && x.password == password);
            if (credentials != null)
            {
               StaticServices.UserService.LoggedInUserCredentials = credentials;
                isValidLogin = true;
            }
            return isValidLogin;
        }

        public string GetDisplayValue(List<ArCodingInfo> arCodingInfos ,string keyName)
        {
            foreach (var item in arCodingInfos)
            {
                if (item.displayName == keyName)
                {
                    return item.value;
                }
            }
            return string.Empty;

        }
    }
}
