using Idiomas.CRUD.Application.Dtos;

namespace Idiomas.CRUD.Application.Services
{
    public interface ITurmaServices
    {


        Task<TurmaDto> CreateAsync(TurmaDto turmaDto);
        Task<IEnumerable<TurmaDto>> GetAllAsync();
        //Task<TurmaDto> UpdateAsync(TurmaDto turmaDto);


        Task<TurmaDto> UpdateAsync(TurmaDto turmaDto);
        Task<TurmaDto> DeleteAsync(int id);


    }
}

