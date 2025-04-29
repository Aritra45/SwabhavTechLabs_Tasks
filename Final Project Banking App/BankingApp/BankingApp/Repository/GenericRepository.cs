using BankingApp.Database;
using BankingApp.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MyContext context;
        DbSet<T> dbSet;

        public GenericRepository(MyContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public async Task AddAsync(T t)
        {
            await dbSet.AddAsync(t);
            context.SaveChanges();
        }

        public void Delete(T t)
        {
            context.SaveChanges();
        }

        public List<T> GetAllAsync()
        {
            return dbSet.ToList();
        }


        public T GetByID(int id)
        {
            return dbSet.Find(id);

        }

        public T GetByEmail(string id)
        {
            return dbSet.Find(id);

        }

        public void Update(T t)
        {
            dbSet.Attach(t);
            context.SaveChanges();
        }
    }
}
