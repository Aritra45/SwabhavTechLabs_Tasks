using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Interface
{
    internal interface I_ContactService
    {
        public void AddContact(int UserId);
        public void RemoveContact();
        public void UpdateContact();
        public void ViewContactByID();
        public void ViewAllContact();
    }
}
