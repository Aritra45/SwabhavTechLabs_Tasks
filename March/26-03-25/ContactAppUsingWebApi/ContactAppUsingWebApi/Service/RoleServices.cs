using ContactAppUsingWebApi.Interfaces.IRepository;
using ContactAppUsingWebApi.Interfaces.IService;
using ContactAppUsingWebApi.Model.Entity;
using ContactAppUsingWebApi.Model.RoleDto;

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
