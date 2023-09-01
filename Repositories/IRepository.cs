using Database.Models;
using System.Linq.Expressions;

namespace Database.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Expression<Func<T, bool>> condition);
        Task<T> GetAsync(Expression<Func<T, bool>> condition);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> condition);
        Task SaveAsync();
    }
}
