using ContactAppUsingWebApi.Data;
using ContactAppUsingWebApi.Exception;
using ContactAppUsingWebApi.Interface.IRepositoryes;
using ContactAppUsingWebApi.Interface.IServices;
using ContactAppUsingWebApi.Model.ContactDetailsDto;
using ContactAppUsingWebApi.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ContactAppUsingWebApi.Service
{
    public class ContactDetailsServices : IContactDetailsServices
    {
        IContactDetailsRepository repository;
        public ContactDetailsServices(IContactDetailsRepository repository)
        {
            this.repository = repository;
        }

        
        public List<ContactDetails> GetAllContactDetails()
        {
            return repository.GetAllContactDetails();
        }

        
        public ContactDetails AddContactDetails(AddContactDetailsDto addContactDetailsDto)
        {
            return repository.AddContactDetails(addContactDetailsDto);
        }

        
        public ContactDetails UpdateContactDetailsType(int contactDetailsId, UpdateContactDetailsTypeDto updateContactDetailsTypeDto)
        {
            return repository.UpdateContactDetailsType(contactDetailsId, updateContactDetailsTypeDto);
        }

        
        public ContactDetails UpdateContactDetailsValue(int contactDetailsId, UpdateContactDetailsValueDto updateContactDetailsValueDto)
        {
            return repository.UpdateContactDetailsValue(contactDetailsId, updateContactDetailsValueDto);
        }

        
        public ContactDetails UpdateContactDetailsActivation(int contactDetailsId, UpdateContactDetailsActivationDto updateContactDetailsActivationDto)
        {
            return repository.UpdateContactDetailsActivation(contactDetailsId, updateContactDetailsActivationDto);
        }

        
        public ContactDetails DeleteContactDetails(int contactDetailsId)
        {
            return repository.DeleteContactDetails(contactDetailsId);
        }
    }
}
