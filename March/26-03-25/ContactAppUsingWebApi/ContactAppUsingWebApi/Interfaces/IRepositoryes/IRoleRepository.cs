using ContactAppUsingWebApi.Model.Entity;
using ContactAppUsingWebApi.Model.RoleDto;

namespace ContactAppUsingWebApi.Interfaces.IRepository
{
    public interface IRoleRepository
    {
        public List<Role> GetAllRoles();
        public Role AddRole(AddRoleDto addRoleDto);
    }
}
