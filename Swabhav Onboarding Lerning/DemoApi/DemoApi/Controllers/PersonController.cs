using DemoApi.Handlers;
using DemoApi.Models;
using DemoApi.Models.PersonDto;
using DemoApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator mediator;
        public PersonController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public async Task<ActionResult<List<PersonModel>>> Get()
        {
            try
            {
                var result = await mediator.Send(new GenericQueries.GetPersonListQuery<PersonModel>());
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log exception here if logging is configured
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await mediator.Send(new GenericQueries.GetByIdQuery<PersonModel>(id));
            return Ok(user);    
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddPersonDto addPersonDto)
        {
            var users = await mediator.Send(new GenericQueries.AddPersonQuery<PersonModel>(addPersonDto));
            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePersonDto updatePersonDto)
        {
            var user = await mediator.Send(new GenericQueries.UpdatePersonQuery<PersonModel>(id, updatePersonDto));
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await mediator.Send(new GenericQueries.DeletePersonQuery<PersonModel>(id));
            return Ok(user);
        }
    }
}
