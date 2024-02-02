using Idiomas.CRUD.Application.Dtos;


namespace Idiomas.CRUD.Application.Services
{
    public interface IAlunoServices
    {
        Task<AlunoDto> GetAllAsync();
    }
}
