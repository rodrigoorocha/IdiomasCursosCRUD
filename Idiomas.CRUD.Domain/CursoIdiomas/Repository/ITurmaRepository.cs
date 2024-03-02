using Idiomas.CRUD.Domain.Base;

namespace Idiomas.CRUD.Domain.CursoIdiomas.Repository
{
    public interface ITurmaRepository : IRepository<Turma>
    {
        Task<IEnumerable<Turma>> GetAllTurmaWithAlunos();
        Task<Turma> GetTurmaById(int id);


    }
}
