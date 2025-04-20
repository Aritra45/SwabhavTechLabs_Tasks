using Form.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Form.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        MyContext _context;
        public FormController(MyContext context) { 
            this._context = context;
        }
        [HttpPost("register")]
        public async Task<IActionResult> AddUser([FromBody] MyForm form)
        {
            var forms = new MyForm()
            {
                Name = form.Name,
                Email = form.Email,
                Password = form.Password,
                ConfirmedPassword = form.ConfirmedPassword,

            };
             await _context.AddAsync(forms);
            await _context.SaveChangesAsync();
            return Ok(new {message="Added"});

        }

        [HttpGet("all-users")]

        public IActionResult GetAllRecords()
        {
            return Ok(_context.MyForms.ToList());
        }
    }
}
