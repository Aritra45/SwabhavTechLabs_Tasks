using ContactAppUsingWebApi.Data;
using ContactAppUsingWebApi.Exception;
using ContactAppUsingWebApi.Interface.IServices;
using ContactAppUsingWebApi.Model.ContactDetailsDto;
using ContactAppUsingWebApi.Model.ContactDto;
using ContactAppUsingWebApi.Model.Entity;
using ContactAppUsingWebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactAppUsingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDetailsController : ControllerBase
    {
        IContactDetailsServices contactDetailsServices;
        public ContactDetailsController(IContactDetailsServices contactDetailsServices)
        {
            this.contactDetailsServices = contactDetailsServices;
        }

        [HttpGet("all-contact-details")]
        [Authorize(Roles = "Staff")]
        public IActionResult GetAllContactDetails()
        {
            var contactDetails = contactDetailsServices.GetAllContactDetails();
            return Ok(contactDetails);
        }
        [HttpPost("add-contact-details")]
        [Authorize(Roles = "Staff")]
        public IActionResult AddContactDetails(AddContactDetailsDto addContactDetailsDto)
        {
            var contactDetailsEntity = contactDetailsServices.AddContactDetails(addContactDetailsDto);
            return Ok(contactDetailsEntity);
        }
        [HttpPut("update-contact-details-type/{contactDetailsId:int}")]
        [Authorize(Roles = "Staff")]
        public IActionResult UpdateContactDetailsType(int contactDetailsId, UpdateContactDetailsTypeDto updateContactDetailsTypeDto)
        {
            var contactDetailsEntity = contactDetailsServices.UpdateContactDetailsType(contactDetailsId, updateContactDetailsTypeDto);
            return Ok(contactDetailsEntity);
        }
        [HttpPut("update-contact-details-value/{contactDetailsId:int}")]
        [Authorize(Roles = "Staff")]
        public IActionResult UpdateContactDetailsValue(int contactDetailsId, UpdateContactDetailsValueDto updateContactDetailsValueDto)
        {
            var contactDetailsEntity = contactDetailsServices.UpdateContactDetailsValue(contactDetailsId, updateContactDetailsValueDto);
            return Ok(contactDetailsEntity);
        }
        [HttpPut("update-contact-details-activation/{contactDetailsId:int}")]
        [Authorize(Roles = "Staff")]
        public IActionResult UpdateContactDetailsActivation(int contactDetailsId, UpdateContactDetailsActivationDto updateContactDetailsActivationDto)
        {
            var contactDetailsEntity = contactDetailsServices.UpdateContactDetailsActivation(contactDetailsId, updateContactDetailsActivationDto);
            return Ok(contactDetailsEntity);
        }
        [HttpDelete("remove-contact-details-access/{contactDetailsId:int}")]
        [Authorize(Roles = "Staff")]
        public IActionResult DeleteContact(int contactDetailsId)
        {
            contactDetailsServices.DeleteContactDetails(contactDetailsId);
            return Ok();
        }
    }
}
