using ContactAppUsingWebApi.Data;
using ContactAppUsingWebApi.Exception;
using ContactAppUsingWebApi.Interface.IRepositoryes;
using ContactAppUsingWebApi.Interface.IServices;
using ContactAppUsingWebApi.Model.ContactDto;
using ContactAppUsingWebApi.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ContactAppUsingWebApi.Service
{
    public class ContactServices : IContactServices
    {
        IContactRepository repository;
        public ContactServices(IContactRepository repository)
        {
            this.repository = repository;
        }


        public List<Contact> GetAllContacts()
        {
            return repository.GetAllContacts();
        }


        public Contact AddContact(AddContactDto addContactDto)
        {
            return repository.AddContact(addContactDto);
        }


        public Contact UpdateContactFirstName(int contactId, UpdateContactFirstNameDto updateContactFirstNameDto)
        {
            return repository.UpdateContactFirstName(contactId, updateContactFirstNameDto);
        }

        
        public Contact UpdateContactLastName(int contactId, UpdateContactLastNameDto updateContactLastNameDto)
        {
            return repository.UpdateContactLastName(contactId, updateContactLastNameDto);
        }

        
        public Contact UpdateContactActivation(int contactId, UpdateContactActivationDto updateContactActivationDto)
        {
            return repository.UpdateContactActivation(contactId, updateContactActivationDto);
        }

        
        public Contact DeleteContact(int contactId)
        {
            return repository.DeleteContact(contactId);
        }
    }
}
