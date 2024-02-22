using AutoMapper;
using Idiomas.CRUD.Application.Dtos;
using Idiomas.CRUD.Domain.CursoIdiomas;
using Idiomas.CRUD.Domain.CursoIdiomas.Repository;

namespace Idiomas.CRUD.Application.Services
{
    public class AlunoService : IAlunoServices
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public AlunoService(IAlunoRepository alunoRepository, IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;

        }

        public Task<AlunoDto> Create(AlunoDto alunoDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TurmaDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
