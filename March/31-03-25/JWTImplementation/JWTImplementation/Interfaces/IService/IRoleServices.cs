using JWTImplementation.Model.Entity;
using JWTImplementation.Model.RoleDto;

namespace JWTImplementation.Interfaces.IService
{
    public interface IRoleServices
    {
        public List<Role> GetAllRoles();
        public Role AddRole(AddRoleDto addRoleDto);
    }
}
