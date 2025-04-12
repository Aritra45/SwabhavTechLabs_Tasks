using ContactAppUsingWebApi.Model.Entity;

using ContactAppUsingWebApi.Model.RoleDto;

namespace ContactAppUsingWebApi.Interfaces.IService
{
    public interface IRoleServices
    {
        public List<Role> GetAllRoles();
        public Role AddRole(AddRoleDto addRoleDto);
    }
}
