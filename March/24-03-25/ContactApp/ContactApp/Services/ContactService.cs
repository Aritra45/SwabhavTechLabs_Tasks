using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Interface;
using ContactApp.Repository;

namespace ContactApp.Services
{
    internal class ContactService : I_ContactService
    {
        ContactRepository contactRepository = new ContactRepository();
        public void AddContact(int userId)
        {
            contactRepository.AddContact(userId);
        }

        public void RemoveContact()
        {
            contactRepository.RemoveContact();
        }

        public void UpdateContact()
        {
            contactRepository.UpdateContact();
        }

        public void ViewAllContact()
        {
            contactRepository.ViewAllContact();
        }

        public void ViewContactByID()
        {
            contactRepository.ViewContactByID();
        }
    }
}
