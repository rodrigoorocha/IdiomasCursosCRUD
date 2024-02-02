
namespace Idiomas.CRUD.Domain.Base
{
    public interface IRepository <T> where T : class
    {
        Task Save(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        Task<T> Get(object id);
        Task<IEnumerable<T>> GetAll();

    }
}
