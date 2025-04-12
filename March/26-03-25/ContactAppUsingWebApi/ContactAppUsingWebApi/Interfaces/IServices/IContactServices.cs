using ContactAppUsingWebApi.Model.ContactDto;
using ContactAppUsingWebApi.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ContactAppUsingWebApi.Interface.IServices
{
    public interface IContactServices
    {
        public List<Contact> GetAllContacts();
        public Task<Contact> AddContact(AddContactDto addContactDto);
        public Contact UpdateContactFirstName(int contactId, UpdateContactFirstNameDto updateContactFirstNameDto);
        public Contact UpdateContactLastName(int contactId, UpdateContactLastNameDto updateContactLastNameDto);
        public Contact UpdateContactActivation(int contactId, UpdateContactActivationDto updateContactActivationDto);
        public Task DeleteContact(int contactId);
    }
}
