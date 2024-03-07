using Idiomas.CRUD.Application.Dtos;
using Idiomas.CRUD.Domain.CursoIdiomas;


namespace Idiomas.CRUD.Application.Services
{
    public interface IAlunoServices
    {
        
        Task<AlunoDto> CreateAsync(AlunoDto alunoDto);
        Task<AlunoDto> UpdateAsync(AlunoDto alunoDto);
        Task<IEnumerable<AlunoDto>> GetAllAsync();
        Task<AlunoDto> DeleteAsync(int id);
        Task<AlunoDto> GetAlunoWithTurmaMatricula(string cpf);

    }
}
