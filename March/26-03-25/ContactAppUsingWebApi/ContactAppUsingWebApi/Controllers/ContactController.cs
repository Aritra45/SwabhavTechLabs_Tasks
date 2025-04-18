﻿using ContactAppUsingWebApi.Data;
using ContactAppUsingWebApi.Exception;
using ContactAppUsingWebApi.Interface.IServices;
using ContactAppUsingWebApi.Model.ContactDto;
using ContactAppUsingWebApi.Model.Entity;
using ContactAppUsingWebApi.Model.UserDto;
using ContactAppUsingWebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactAppUsingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        
        IContactServices contactServices;
        public ContactController(IContactServices contactServices)
        {
            this.contactServices = contactServices;
        }

        [HttpGet("all-contacts")]
        [Authorize(Roles = "Staff")]
        public IActionResult GetAllContacts()
        {
            var contacts = contactServices.GetAllContacts();
            return Ok(contacts);
        }

        [HttpPost("add-contact")]
        [Authorize(Roles = "Staff")]
        public IActionResult AddContact(AddContactDto addContactDto)
        {
            var contactEntity = contactServices.AddContact(addContactDto);
            return Ok(contactEntity);
        }

        [HttpPut("update-contact-first-name/{contactId:int}")]
        [Authorize(Roles = "Staff")]
        public IActionResult UpdateContactFirstName(int contactId, UpdateContactFirstNameDto updateContactFirstNameDto)
        {
            var contactEntity = contactServices.UpdateContactFirstName(contactId, updateContactFirstNameDto);
            return Ok(contactEntity);
        }

        [HttpPut("update-contact-last-name/{contactId:int}")]
        [Authorize(Roles = "Staff")]
        public IActionResult UpdateContactLastName(int contactId, UpdateContactLastNameDto updateContactLastNameDto)
        {
            var contactEntity = contactServices.UpdateContactLastName(contactId, updateContactLastNameDto);
            return Ok(contactEntity);
        }

        [HttpPut("update-contact-activation/{contactId:int}")]
        [Authorize(Roles = "Staff")]
        public IActionResult UpdateContactActivation(int contactId, UpdateContactActivationDto updateContactActivationDto)
        {
            var contactEntity = contactServices.UpdateContactActivation(contactId, updateContactActivationDto);
            return Ok(contactEntity);
        }

        [HttpDelete("remove-contact-access/{contactId:int}")]
        [Authorize(Roles = "Staff")]
        public IActionResult DeleteContact(int contactId)
        {
            contactServices.DeleteContact(contactId);
            return Ok();
        }
    }
}
