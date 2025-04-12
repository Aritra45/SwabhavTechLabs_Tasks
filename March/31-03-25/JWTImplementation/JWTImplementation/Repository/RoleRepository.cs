using JWTImplementation.Data;
using JWTImplementation.Interfaces.IRepository;
using JWTImplementation.Model.Entity;
using JWTImplementation.Model.RoleDto;
using Microsoft.EntityFrameworkCore;

namespace JWTImplementation.Repository
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
