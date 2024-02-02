using AutoMapper;
using Idiomas.CRUD.Application.Dtos;
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

        public async Task<AlunoDto> GetAllAsync()
        {
            var query = await _alunoRepository.GetAll();
            var alunoDto = _mapper.Map<AlunoDto>(query);
            return alunoDto;

        }
    }
}
