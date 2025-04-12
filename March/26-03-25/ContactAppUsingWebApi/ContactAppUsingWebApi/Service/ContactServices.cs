using System.Collections.Generic;
using ContactAppUsingWebApi.Data;
using ContactAppUsingWebApi.Exception;
using ContactAppUsingWebApi.Interface.IRepositoryes;
using ContactAppUsingWebApi.Interface.IServices;
using ContactAppUsingWebApi.Interfaces.IRepositoryes;
using ContactAppUsingWebApi.Model.ContactDto;
using ContactAppUsingWebApi.Model.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ContactAppUsingWebApi.Service
{
    public class ContactServices : IContactServices
    {
        IGenericRepository<Contact> repository;
        public ContactServices(IGenericRepository<Contact> repository)
        {
            this.repository = repository;
        }


        public List<Contact> GetAllContacts()
        {
            var contacts = repository.GetAllAsync();
            return contacts.Where(contact => contact.IsActive == true).ToList();
        }


        public async Task<Contact> AddContact(AddContactDto addContactDto)
        {
            var contactEntity = new Contact
            {
                FirstName = addContactDto.FirstName,
                LastName = addContactDto.LastName,
                IsActive = true,
                UserId = addContactDto.UserId
            };

            await repository.AddAsync(contactEntity);
            return contactEntity;
        }


        public Contact UpdateContactFirstName(int contactId, UpdateContactFirstNameDto updateContactFirstNameDto)
        {
            var contactEntity = repository.GetByID(contactId);
            if (contactEntity == null)
            {
                throw new KeyNotFoundException($"Contact with ID {contactId} not found.");
            }

            contactEntity.FirstName = updateContactFirstNameDto.FirstName;
            repository.Update(contactEntity);
            return contactEntity;
        }

        
        public Contact UpdateContactLastName(int contactId, UpdateContactLastNameDto updateContactLastNameDto)
        {
            var contactEntity = repository.GetByID(contactId);
            if (contactEntity == null)
            {
                throw new KeyNotFoundException($"Contact with ID {contactId} not found.");
            }

            contactEntity.LastName = updateContactLastNameDto.LastName;
            repository.Update(contactEntity);
            return contactEntity;
        }

        
        public Contact UpdateContactActivation(int contactId, UpdateContactActivationDto updateContactActivationDto)
        {
            var contactEntity = repository.GetByID(contactId);
            if (contactEntity == null)
            {
                throw new KeyNotFoundException($"Contact with ID {contactId} not found.");
            }

            contactEntity.IsActive = updateContactActivationDto.IsActive;
            repository.Update(contactEntity);
            return contactEntity;
        }

        
        public async Task DeleteContact(int contactId)
        {
            var contact = repository.GetByID(contactId);
            if (contact != null)
            {
                contact.IsActive = false;
            }
            else
            {
                throw new MyNotFoundException("Not Found");
            }
        }
    }
    
}
