using Idiomas.CRUD.Application.Dtos;


namespace Idiomas.CRUD.Application.Services
{
    public interface IAlunoServices
    {
        
        Task<AlunoDto> CreateAsync(AlunoInputDto alunoInputDto);
        Task<AlunoDto> UpdateAsync(AlunoDto alunoDto);
        Task<IEnumerable<AlunoDto>> GetAllAsync();
        Task<AlunoDto> DeleteAsync(int id);

    }
}
