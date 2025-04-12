using JWTImplementation.Interfaces.IRepository;
using JWTImplementation.Interfaces.IService;
using JWTImplementation.Model.Entity;
using JWTImplementation.Model.RoleDto;

namespace JWTImplementation.Service
{
    public class RoleServices : IRoleServices
    {
        IRoleRepository repository;
        public RoleServices(IRoleRepository repository)
        {
            this.repository = repository;
        }

        public Role AddRole(AddRoleDto addRoleDto)
        {
            return repository.AddRole(addRoleDto);
        }

        public List<Role> GetAllRoles()
        {
            return repository.GetAllRoles();
        }
    }
}
