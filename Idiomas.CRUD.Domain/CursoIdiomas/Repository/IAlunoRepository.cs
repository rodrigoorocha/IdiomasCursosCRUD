using Idiomas.CRUD.Domain.Base;
using Idiomas.CRUD.Domain.CursoIdiomas.ValueObject;

namespace Idiomas.CRUD.Domain.CursoIdiomas.Repository
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task<IEnumerable<Aluno>> GetAllAsyncWithTurma();
        Task<Aluno> GetByIdAsync(Guid id);

        Task<Aluno> GetAlunoByCPF(string cpf);


    }
}
