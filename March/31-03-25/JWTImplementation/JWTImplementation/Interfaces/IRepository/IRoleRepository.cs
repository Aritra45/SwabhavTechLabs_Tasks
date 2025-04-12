using JWTImplementation.Model.Entity;
using JWTImplementation.Model.RoleDto;

namespace JWTImplementation.Interfaces.IRepository
{
    public interface IRoleRepository
    {
        public List<Role> GetAllRoles();
        public Role AddRole(AddRoleDto addRoleDto);
    }
}
