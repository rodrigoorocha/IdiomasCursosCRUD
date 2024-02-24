
using System.Linq.Expressions;

namespace Idiomas.CRUD.Domain.Base
{
    public interface IRepository <T> where T : class
    {
        Task SaveAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAllByCriterioAsync(Expression<Func<T, bool>> expression);
        Task<T> FindOneByCriterioAsync(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    }
}
