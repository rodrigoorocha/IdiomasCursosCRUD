using Idiomas.CRUD.Domain.CursoIdiomas;
using Idiomas.CRUD.Domain.CursoIdiomas.Repository;
using Idiomas.CRUD.Infraestructure.Context;
using Idiomas.CRUD.Infraestructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Idiomas.CRUD.Infraestructure.Repository
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(IdiomasContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Aluno>> GetAllAsyncWithTurma()
        {
            var query = await this.Query.Include(x=> x.Turma).ToListAsync();
            return query;
        }

        public async Task<Aluno> GetAlunoByCPF(string cpf)
        {
            
            var query = await this.Query.FirstOrDefaultAsync(x=> x.Cpf.Numero.Equals(cpf));
            return query;
        }

        public Task<Aluno> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
