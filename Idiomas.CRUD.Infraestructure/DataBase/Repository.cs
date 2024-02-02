using Idiomas.CRUD.Domain.Base;
using Idiomas.CRUD.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Idiomas.CRUD.Infraestructure.DataBase
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected DbSet<T> Query {  get; set; }
        protected DbContext Context { get; set; }

        public Repository (IdiomasContext context)
        {
            this.Context = context; 
            this.Query = Context.Set<T>();   
        }


        public async Task Delete(T entity)
        {
            this.Query.Remove(entity);
            await this.Context.SaveChangesAsync();
        }

        public  async Task<T> Get(object id)
        {
            return await this.Query.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this.Query.ToListAsync();
        }

        public async Task Save(T entity)
        {
            await this.Query.AddAsync(entity);
           await this.Context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
           this.Query.Update(entity);
           await this.Context.SaveChangesAsync();
        }
    }
}
