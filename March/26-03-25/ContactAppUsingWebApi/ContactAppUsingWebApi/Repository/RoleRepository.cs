
using ContactAppUsingWebApi.Data;
using ContactAppUsingWebApi.Model.Entity;
using ContactAppUsingWebApi.Model.RoleDto;
using ContactAppUsingWebApi.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ContactAppUsingWebApi.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly MyContext context;

        DbSet<Role> dbSet;
        public RoleRepository(MyContext context)
        {
            this.context = context;
            dbSet = context.Set<Role>();
        }
        public Role AddRole(AddRoleDto addRoleDto)
        {
            var roleEntity = new Role
            {
                Rolename = addRoleDto.Rolename,
            };
            dbSet.Add(roleEntity);
            context.SaveChanges();
            return roleEntity;
        }

        public List<Role> GetAllRoles()
        {
            return dbSet.ToList();
        }
    }
}
