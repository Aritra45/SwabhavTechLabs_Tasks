
using DemoApi.DataAccess;
using DemoApi.Interfaces.IRepositoryes;
using DemoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactAppUsingWebApi.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DemoDataAccess context;
        DbSet<T> dbSet;

        public GenericRepository(DemoDataAccess context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public async Task AddAsync(T t)
        {
            await dbSet.AddAsync(t);
            context.SaveChanges();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public T GetByID(int id)
        {
            return dbSet.Find(id);
            
        }

        public void Update(T t)
        {
            dbSet.Attach(t);
            //context.Entry(t).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(T t)
        {
            dbSet.Remove(t);
            context.SaveChanges();
        }

    }
}
