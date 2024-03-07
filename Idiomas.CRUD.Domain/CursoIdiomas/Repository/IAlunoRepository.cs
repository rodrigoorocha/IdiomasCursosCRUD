using Idiomas.CRUD.Domain.Base;
using Idiomas.CRUD.Domain.CursoIdiomas.ValueObject;
using System.Threading.Tasks;

namespace Idiomas.CRUD.Domain.CursoIdiomas.Repository
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        
        
        Task<Aluno> GetAlunoByCPF(string cpf);
        Task<IQueryable> GetAlunoWithTurmaMatricula(string cpf);
        Task<IEnumerable<Aluno>> GetAllAlunoWithTurmaMatricula();
        Task<IEnumerable<Aluno>> GetAlunosByTurma(int turmaId);



    }
}
