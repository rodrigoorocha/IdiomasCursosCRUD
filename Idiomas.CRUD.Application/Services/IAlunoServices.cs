using Idiomas.CRUD.Application.Dtos;
using Idiomas.CRUD.Domain.CursoIdiomas;


namespace Idiomas.CRUD.Application.Services
{
    public interface IAlunoServices
    {
        
        Task<AlunoDto> Create(AlunoDto alunoDto);
        Task<IEnumerable<TurmaDto>> GetAllAsync();



    }
}
