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

        public async Task<AlunoDto> Create(AlunoDto alunoDto)
        {
            

            var aluno = _mapper.Map<Aluno>(alunoDto);

            await _alunoRepository.Save(aluno);

            return _mapper.Map<AlunoDto>(aluno);

        }


        public Task<AlunoDto> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AlunoDto>> GetAllAsync()
        {
            var query = await _alunoRepository.GetAllAsyncWithTurma();

            //var alunoDtos = new List<AlunoDto>();

            //foreach (var aluno in query)
            //{
            //    var alunoDto = new AlunoDto
            //    {
            //        Nome = aluno.Nome,
            //        Cpf = aluno.Cpf,
            //        Email = aluno.Email,
            //        
            //        
            //    };
            //
            //    alunoDtos.Add(alunoDto);
            //}          

            var alunoDtos = _mapper.Map<IEnumerable<AlunoDto>>(query);

            return alunoDtos;

        }

        public async Task<AlunoDto> GetByIdAsync(Guid id)
        {
            if (id == null)
                throw new Exception("Id null, favor informar id");

            var agenda = await _alunoRepository.GetByIdAsync(id);

            return _mapper.Map<AlunoDto>(id);
        }

        public Task<AlunoDto> Update(Guid id, AlunoDto alunoDto)
        {
            throw new NotImplementedException();
        }
    }
}
