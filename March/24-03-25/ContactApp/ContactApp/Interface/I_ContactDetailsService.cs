using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Repository;

namespace ContactApp.Interface
{
    internal interface I_ContactDetailsService
    {
        public void AddContactDetails(int contactId);
        public void RemoveContactDetails(int contactDetailsId);
        
        public void UpdateContactDetails(int contactDetailsID);


    }
}
