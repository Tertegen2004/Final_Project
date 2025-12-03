using EduAll.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EduAll.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext context;

        public Repository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Create(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            return context.SaveChanges();
        }

        public Task<int> CreateRange(IEnumerable<T> entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(int id)
        {
            var entity = await FindById(id);
            context.Set<T>().Remove(entity);
            return await context.SaveChangesAsync();
        }

        public Task<int> DeleteAll(IEnumerable<T> entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T> FindById(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);

            return entity;
        }

        public async Task<IQueryable<T>> GettAll(Expression<Func<T,bool>> filter=null ,params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = context.Set<T>();

            if (filter != null)
            {
                query= query.Where(filter);
            }

            if (includes.Length > 0)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            // Take attention this method return iquerable
            return query;
        }

        public async Task<T> SelectBy(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<int> Update(int id)
        {
            var entity = await FindById(id);
            context.Set<T>().Update(entity);

            return await context.SaveChangesAsync();
        }

        IQueryable<T> IRepository<T>.GettAll(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes != null && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

    }
}
