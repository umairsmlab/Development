using RCOTruckApp.Repository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace RCOTruckApp.Services.User
{
    internal class UserServices
    {
        UserRepository userRepository = new UserRepository();

        public List<Models.User.User> GetUsers()
        {
            return userRepository.GetUsers();
        }

        public bool VerifyUserLogin(string userName, string password)
        {
            if (Helper.Helper.CheckConnection())
            {
                return userRepository.VerifyUserLoginOnline(userName, password);
            }
            else
            {
                return userRepository.VerifyUserLoginOffline(userName, password);
            }
        }
    }
}
