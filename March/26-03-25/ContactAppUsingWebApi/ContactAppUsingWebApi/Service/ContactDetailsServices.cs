using System.Collections.Generic;
using ContactAppUsingWebApi.Data;
using ContactAppUsingWebApi.Exception;
using ContactAppUsingWebApi.Interface.IRepositoryes;
using ContactAppUsingWebApi.Interface.IServices;
using ContactAppUsingWebApi.Interfaces.IRepositoryes;
using ContactAppUsingWebApi.Model.ContactDetailsDto;
using ContactAppUsingWebApi.Model.ContactDto;
using ContactAppUsingWebApi.Model.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactAppUsingWebApi.Service
{
    public class ContactDetailsServices : IContactDetailsServices
    {
        IGenericRepository<ContactDetails> repository;
        public ContactDetailsServices(IGenericRepository<ContactDetails> repository)
        {
            this.repository = repository;
        }

        
        public List<ContactDetails> GetAllContactDetails()
        {
            var contactDetails = repository.GetAllAsync();
            return contactDetails.Where(contactDetails => contactDetails.IsActive == true).ToList();
        }

        
        public async Task<ContactDetails> AddContactDetails(AddContactDetailsDto addContactDetailsDto)
        {
            var contactDetailsEntity = new ContactDetails
            {
                Type = addContactDetailsDto.Type,
                Value = addContactDetailsDto.Value,
                IsActive = true,
                ContactId = addContactDetailsDto.ContactId
            };

            await repository.AddAsync(contactDetailsEntity);
            return contactDetailsEntity;
        }

        
        public ContactDetails UpdateContactDetailsType(int contactDetailsId, UpdateContactDetailsTypeDto updateContactDetailsTypeDto)
        {
            var contactDetailsEntity = repository.GetByID(contactDetailsId);
            if (contactDetailsEntity == null)
            {
                throw new KeyNotFoundException($"ContactDetails with ID {contactDetailsId} not found.");
            }

            contactDetailsEntity.Type = updateContactDetailsTypeDto.Type;
            repository.Update(contactDetailsEntity);
            return contactDetailsEntity;
        }

        
        public ContactDetails UpdateContactDetailsValue(int contactDetailsId, UpdateContactDetailsValueDto updateContactDetailsValueDto)
        {
            var contactDetailsEntity = repository.GetByID(contactDetailsId);
            if (contactDetailsEntity == null)
            {
                throw new KeyNotFoundException($"ContactDetails with ID {contactDetailsId} not found.");
            }

            contactDetailsEntity.Value = updateContactDetailsValueDto.Value;
            repository.Update(contactDetailsEntity);
            return contactDetailsEntity;
        }

        
        public ContactDetails UpdateContactDetailsActivation(int contactDetailsId, UpdateContactDetailsActivationDto updateContactDetailsActivationDto)
        {
            var contactDetailsEntity = repository.GetByID(contactDetailsId);
            if (contactDetailsEntity == null)
            {
                throw new KeyNotFoundException($"ContactDetails with ID {contactDetailsId} not found.");
            }

            contactDetailsEntity.IsActive = updateContactDetailsActivationDto.IsActive;
            repository.Update(contactDetailsEntity);
            return contactDetailsEntity;
        }

        
        public async Task DeleteContactDetails(int contactDetailsId)
        {
            var contactDetails = repository.GetByID(contactDetailsId);
            if (contactDetails != null)
            {
                contactDetails.IsActive = false;
            }
            else
            {
                throw new MyNotFoundException("Not Found");
            }
        }
    }
}
