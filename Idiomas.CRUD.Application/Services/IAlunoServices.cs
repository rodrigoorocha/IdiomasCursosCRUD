using Idiomas.CRUD.Application.Dtos;


namespace Idiomas.CRUD.Application.Services
{
    public interface IAlunoServices
    {
        Task<AlunoDto> Delete(Guid id);
        Task<AlunoDto> Create(AlunoDto alunoDto);
        Task<IEnumerable<AlunoDto>> GetAllAsync();
        Task<AlunoDto> GetByIdAsync(Guid id);
        Task<AlunoDto> Update(Guid id, AlunoDto alunoDto);


    }
}
