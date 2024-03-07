using Idiomas.CRUD.Domain;
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
                .Include(x=>x.Turmas)
                .ToListAsync();
            return query;
        }

        public async Task<Aluno> GetAlunoByCPF(string cpf)
        {
            var query = await this.Query
                .Include(x=>x.Turmas)                
                .FirstOrDefaultAsync(x => x.Cpf.Numero.Equals(cpf));
            return query;
        }

        public async Task<IEnumerable<Aluno>> GetAlunosByTurma(int turmaId)
        {
            //var alunosNaTurma = await Query
            //    .Where(a => a.Matriculas.Any(m => m.TurmaId == turmaId))
            //    .ToListAsync();
            //return alunosNaTurma;

            var alunosNaTurma = await (from aluno in Query
                                       join matricula in Context.Set<Matricula>() on aluno.AlunoId equals matricula.AlunoId
                                       join turma in Context.Set<Turma>() on matricula.TurmaId equals turma.TurmaId
                                       where matricula.TurmaId == turmaId
                                       select new
                                       {
                                           Aluno = aluno,
                                           Turma = turma
                                       }).ToListAsync();

            // Mapear o resultado para objetos Aluno
            var alunos = alunosNaTurma.Select(item => item.Aluno);
            return alunos;

        }

        public async Task<IQueryable> GetAlunoWithTurmaMatricula(string cpf)
        {
            var query = this.Query
                .Where(x => x.Cpf.Numero.Equals(cpf));
                //.Include(x => x.Matriculas);
            return query;
        }
    }
}
