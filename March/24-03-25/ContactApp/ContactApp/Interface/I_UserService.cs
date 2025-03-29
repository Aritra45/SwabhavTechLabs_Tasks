using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Model;

namespace ContactApp.Interface
{
    internal interface I_UserService
    {
        public void AddUser();
        public void RemoveUser(int userID);
        public void UpdateUser();
        public void ViewUserByID();
        public void ViewAllUser();
    }

}

