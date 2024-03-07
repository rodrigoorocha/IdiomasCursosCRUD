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

        public async Task<IEnumerable<AlunoDto>> GetAllAsync()
        {
            var query = await _alunoRepository.GetAllAsync();

            var alunoDto = _mapper.Map<IEnumerable<AlunoDto>>(query);
            return alunoDto;
        }
        public async Task<AlunoDto> CreateAsync(AlunoDto alunoDto)
        {

            if (await _alunoRepository.AnyAsync(x => x.Cpf.Numero == alunoDto.Cpf.Numero))
                throw new Exception("Já existe um funcionario cadastrado com o mesmo CPF");

            var aluno = _mapper.Map<Aluno>(alunoDto);
            aluno.Validate();
            await _alunoRepository.SaveAsync(aluno);

            return _mapper.Map<AlunoDto>(aluno);
        }
        public async Task<AlunoDto> UpdateAsync(AlunoDto alunoDto)
        {
            var aluno = await _alunoRepository.GetAlunoByCPF(alunoDto.Cpf.Numero);
            if (aluno == null)
                throw new Exception("Aluno não encontrado");

            _mapper.Map(alunoDto, aluno);

            await _alunoRepository.UpdateAsync(aluno);

            return _mapper.Map<AlunoDto>(aluno);
        }
        public async Task<AlunoDto> DeleteAsync(int id)
        {
            var aluno = await _alunoRepository.GetByIdAsync(id);         

            if (aluno == null)
                throw new Exception("Aluno não encontrado");
         
            await _alunoRepository.DeleteAsync(aluno.AlunoId);           
            
            return _mapper.Map<AlunoDto>(aluno);
        }

        public async Task<AlunoDto> GetAlunoWithTurmaMatricula(string cpf)
        {
            var aluno = await _alunoRepository.GetAlunoByCPF(cpf);
            if (aluno == null)
                throw new Exception("Aluno não encontrado");
            return _mapper.Map<AlunoDto>(aluno);
        }
    }
}
