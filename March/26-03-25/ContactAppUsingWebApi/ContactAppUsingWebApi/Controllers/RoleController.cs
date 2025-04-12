using ContactAppUsingWebApi.Interfaces.IService;
using ContactAppUsingWebApi.Model.RoleDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactAppUsingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleServices roleServices;
        public RoleController(IRoleServices roleServices)
        {
            this.roleServices = roleServices;
        }

        [HttpGet("get-all-roles")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllRoles()
        {
            var roles = roleServices.GetAllRoles();
            return Ok(roles);
        }

        [HttpPost("add-new-role")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddRole(AddRoleDto addRoleDto)
        {
            var role = roleServices.AddRole(addRoleDto);
            return Ok(role);
        }
    }
}
