using AutoMapper;
using Idiomas.CRUD.Application.Dtos;
using Idiomas.CRUD.Domain.CursoIdiomas;
using Idiomas.CRUD.Domain.CursoIdiomas.Repository;

namespace Idiomas.CRUD.Application.Services
{
    public class TurmaServices : ITurmaServices
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMapper _mapper;

        public TurmaServices(ITurmaRepository turmaRepository, IMapper mapper)
        {
            _turmaRepository = turmaRepository;
            _mapper = mapper;
        }

        public Task<TurmaDto> Create(TurmaDto turmaDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TurmaDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
