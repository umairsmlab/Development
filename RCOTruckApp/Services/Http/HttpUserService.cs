using RCOTruckApp.Models.User;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.Services.Http
{
    internal class HttpUserService
    {
        public string BaseURL { get; set; }
        public async Task<bool> Login(string URL)
        {

            using (var client = new HttpClient())
            {
                BaseURL = ConfigurationManager.AppSettings["BaseURL"];
                client.BaseAddress = new Uri(BaseURL);
                HttpResponseMessage response = await client.GetAsync(URL);
                var json = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {

                    return true;
                }
                else
                {

                    return false;
                }
            }
        }
    }
}
