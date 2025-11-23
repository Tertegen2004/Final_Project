using System.Linq.Expressions;

namespace EduAll.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<int> Create(T entity);

        Task<int> Delete(int id);

        Task<int> Update(int id);

        Task<T> FindById(int id);

        Task<T> SelectBy(Expression<Func<T, bool>> expression);

        Task<IQueryable<T>> GettAll(Expression<Func<T,bool>> filter = null, params Expression<Func<T, object>>[] includes);
    }
}
