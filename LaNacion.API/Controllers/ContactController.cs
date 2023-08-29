using AutoMapper;
using LaNacion.Model.Entities;
using LaNacion.Services;
using LaNacion.Services.Services.Contacts.DTOs;
using LaNacion.Services.Services.Contacts.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace LaNacion.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IServices _services;
        private readonly IMapper _mapper;

        public ContactController(IServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Contact>))]
        public IActionResult GetContacts()
        {
            var contacts = _mapper.Map<IEnumerable<ContactDTO>>(_services.ContactsService.GetAll());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(contacts);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateContact([FromBody] ContactDTO createdContact)
        {
            try
            {
                _services.ContactsService.Create(_mapper.Map<ContactDTO, Contact>(createdContact));

                return Ok("Successfully created");
            }
            catch (CreateContactException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DuplicatedContactException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateContacty(int id, [FromBody] ContactDTO updatedContact)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _services.ContactsService.Update(id, updatedContact);

                return Ok("Successfully updated");

            }
            catch (ContactNotFoundException ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
            catch (UpdateContactException ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteContact(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _services.ContactsService.Delete(id);

                return Ok("Successfully deleted");
            }
            catch (ContactNotFoundException ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
            catch (DeleteContactException ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Contact))]
        [ProducesResponseType(400)]
        public IActionResult GetContactById(int id)
        {
            try
            {
                var contact = _mapper.Map<ContactDTO>(_services.ContactsService.GetById(id));

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(contact);
            }
            catch (ContactNotFoundException ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetByEmail")]
        public IActionResult GetContactByEmail([FromQuery] string email)
        {
            try
            {
                var contact = _mapper.Map<ContactDTO>(_services.ContactsService.GetByEmail(email));

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(contact);
            }
            catch (ContactNotFoundException ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetByPhoneNumber")]
        public IActionResult GetContactByPhoneNumber([FromQuery] string phoneNumber)
        {
            try
            {
                var result = _services.ContactsService.GetByPhoneNumber(phoneNumber);

                return Ok(result);
            }
            catch (ContactNotFoundException ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetByStateOrCity")]
        public IActionResult GetContactByCityOrState([FromQuery] string cityOrState)
        {
            try
            {
                var result = _services.ContactsService.GetByCityOrState(cityOrState);

                return Ok(result);
            }
            catch (ContactNotFoundException ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }
    }
}