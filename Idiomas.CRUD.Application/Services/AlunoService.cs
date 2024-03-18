using AutoMapper;
using Idiomas.CRUD.Application.Dtos;
using Idiomas.CRUD.Domain.CursoIdiomas;
using Idiomas.CRUD.Domain.CursoIdiomas.Repository;


namespace Idiomas.CRUD.Application.Services
{
    public class AlunoService : IAlunoServices
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMapper _mapper;

        public AlunoService(IAlunoRepository alunoRepository, ITurmaRepository turmaRepository, IMapper mapper)
        {
            _turmaRepository = turmaRepository;
            _alunoRepository = alunoRepository;
            _mapper = mapper;

        }

        public async Task<IEnumerable<AlunoDto>> GetAllAsync()
        {
            var query = await _alunoRepository.GetAllAlunoWithTurmaMatricula();
            var alunoDto = _mapper.Map<IEnumerable<AlunoDto>>(query);
            return alunoDto;
        }
        public async Task<AlunoDto> CreateAsync(AlunoDto alunoCreateDto)
        {
            if (await _alunoRepository.AnyAsync(x => x.Cpf.Numero == alunoCreateDto.Cpf.Numero))
                throw new Exception("Já existe um funcionário cadastrado com o mesmo CPF");

            var turmaIds = alunoCreateDto.TurmasDto.Select(turma => turma.Id.Value).ToList();
            var turmas = await _turmaRepository.GetByIdsAsync(turmaIds);

            foreach (var turmaDto in alunoCreateDto.TurmasDto)
            {
                var turma = turmas.FirstOrDefault(t => t.Id == turmaDto.Id);

                if (turma == null)
                {
                    throw new Exception($"A turma com o ID {turmaDto.Id} não foi encontrada no banco de dados.");
                }

                if (turma.Numero != turmaDto.Numero || turma.AnoLetivo != turmaDto.AnoLetivo)
                {
                    throw new Exception($"As informações da turma com o ID {turmaDto.Id} não correspondem às informações no banco de dados.");
                }

                if (turma.Alunos.Count() >= 5)
                {
                    throw new Exception("Turma cheia");
                }
            }

            var aluno = _mapper.Map<Aluno>(alunoCreateDto);
            aluno.Turmas = turmas.ToList(); 

            aluno.Validate();
            await _alunoRepository.SaveAsync(aluno);

            var alunoDtoWithTurmas = _mapper.Map<AlunoDto>(aluno);
            return alunoDtoWithTurmas;
        }

        public async Task<AlunoDto> UpdateAsync(AlunoDto alunoDto)
        {
            var aluno = await _alunoRepository.GetAlunoByCPF(alunoDto.Cpf.Numero);
            if (aluno == null)
                throw new Exception("Aluno não encontrado");


            var turmaIds = alunoDto.TurmasDto.Select(turma => turma.Id.Value).ToList();
            var turmas = await _turmaRepository.GetByIdsAsync(turmaIds);

            foreach (var turmaDto in alunoDto.TurmasDto)
            {
                var turma = turmas.FirstOrDefault(t => t.Id == turmaDto.Id);

                if (turma == null)
                {
                    throw new Exception($"A turma com o ID {turmaDto.Id} não foi encontrada no banco de dados.");
                }

                if (turma.Numero != turmaDto.Numero || turma.AnoLetivo != turmaDto.AnoLetivo)
                {
                    throw new Exception($"As informações da turma com o ID {turmaDto.Id} não correspondem às informações no banco de dados.");
                }

                if (turma.Alunos.Count() >= 5)
                {
                    throw new Exception("Turma cheia");
                }
            }

            _mapper.Map(alunoDto, aluno);

            await _alunoRepository.UpdateAsync(aluno);

            return _mapper.Map<AlunoDto>(aluno);
        }
        public async Task<AlunoDto> DeleteAsync(int id)
        {
            var aluno = await _alunoRepository.GetByIdAsync(id);         

            if (aluno == null)
                throw new Exception("Aluno não encontrado");
                        
            await _alunoRepository.DeleteAsync(aluno.Id);           
            
            return _mapper.Map<AlunoDto>(aluno);
        }

        public async Task<AlunoDto> GetAlunoWithTurmaMatricula(string cpf)
        {
            var aluno = await _alunoRepository.GetAlunoByCPF(cpf);
            if (aluno == null)
                throw new Exception("Aluno não encontrado");
                        
            
                var alunoDto = new AlunoDto
                {
                    Id = aluno.Id,
                    Nome = aluno.Nome,
                    Cpf = aluno.Cpf,
                    Email = aluno.Email
                };


                foreach (var turma in aluno.Turmas)
                {
                    var turmaDto = new TurmaDto
                    {
                        Id = turma.Id,
                        Numero = turma.Numero,
                        AnoLetivo = turma.AnoLetivo,
                    };

                    alunoDto.TurmasDto.Add(turmaDto);
                }
                return alunoDto;
            

        }

        public async Task<AlunoDto> GetById(int id)
        {
            var aluno = await _alunoRepository.GetByIdAsync(id);               
            return _mapper.Map<AlunoDto>(aluno);
        }
    }
}
