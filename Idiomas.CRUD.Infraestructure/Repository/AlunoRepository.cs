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

        public async Task<IEnumerable<Aluno>> GetAllAlunoWithTurmaMatricula()
        {
            var query = await this.Query
                .Include(x => x.Matriculas)
                .ToListAsync();



            return query;
        }

        public async Task<Aluno> GetAlunoByCPF(string cpf)
        {
            var query = await this.Query.FirstOrDefaultAsync(x => x.Cpf.Numero.Equals(cpf));
            return query;
        }

        public async Task<Aluno> GetAlunoWithTurmaMatricula(string cpf)
        {
            var query = this.Query
                .Where(x => x.Cpf.Numero.Equals(cpf))
                .Include(x => x.Matriculas);
            return (Aluno)query;
        }
    }
}
