using AutoMapper;
using Idiomas.CRUD.Application.Dtos;

namespace Idiomas.CRUD.Application.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMapper _mapper;

        public MatriculaService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<MatriculaDto> CreateAsync(MatriculaDto matriculaDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MatriculaDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
