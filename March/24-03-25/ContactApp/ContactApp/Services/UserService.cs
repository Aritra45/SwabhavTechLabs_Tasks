using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Interface;
using ContactApp.Repository;

namespace ContactApp.Services
{
    internal class UserService : I_UserService
    {
        UserRepository userRepository = new UserRepository();
        public void AddUser()
        {
            userRepository.AddUser();
        }

        public void RemoveUser(int userID)
        {
            userRepository.RemoveUser(userID);
        }

        public void UpdateUser()
        {
            userRepository.UpdateUser();
        }
        public void ViewUserByID()
        {
            userRepository.ViewUserByID();
        }
        public void ViewAllUser()
        {
            userRepository.ViewAllUsers();
        }
    }
}
