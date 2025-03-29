using ContactApp.Interface;
using ContactApp.Model;
using ContactApp.Repository;

namespace ContactApp.Services
{
    internal class ContactDetailsService : I_ContactDetailsService
    {
        ContactDetailsRepository contactDetailsRepository = new ContactDetailsRepository();

        public void AddContactDetails(int contactId)
        {
            contactDetailsRepository.AddContactDetails(contactId);
        }

        public void RemoveContactDetails(int contactDetailsId)
        {
            contactDetailsRepository.RemoveContactDetails(contactDetailsId);
        }

        public void UpdateContactDetails(int contactDetailsID)
        {
            contactDetailsRepository.UpdateContactDetails(contactDetailsID);
        }
    }
}