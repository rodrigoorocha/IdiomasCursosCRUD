using AutoMapper;
using Idiomas.CRUD.Application.Dtos;
using Idiomas.CRUD.Domain;
using Idiomas.CRUD.Domain.CursoIdiomas;
using Idiomas.CRUD.Domain.CursoIdiomas.Repository;
using Microsoft.EntityFrameworkCore;

namespace Idiomas.CRUD.Application.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMapper _mapper;
        private readonly IMatriculaRepository _matriculaRepository;

        //contrutor da classe MatriculaService
        public MatriculaService(IMapper mapper, IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
            _mapper = mapper;
        }

        public async Task<MatriculaDto> CriarMatriculaAsync(int alunoId, int turmaId)
        {
            // Aqui você pode adicionar lógica de validação ou regras de negócio antes de criar a matrícula

            // Exemplo simples de verificação de existência de aluno e turma
            var aluno = await dbContext.Alunos.FindAsync(alunoId);
            if (aluno == null)
            {
                throw new InvalidOperationException("Aluno não encontrado.");
            }

            var turma = await dbContext.Turmas.FindAsync(turmaId);
            if (turma == null)
            {
                throw new InvalidOperationException("Turma não encontrada.");
            }

            // Se a verificação passar, crie a matrícula
            var matricula = new Matricula
            {
                AlunoId = alunoId,
                TurmaId = turmaId,
                Aluno = aluno,
                Turma = turma
            };

            dbContext.Matriculas.Add(matricula);
            await dbContext.SaveChangesAsync();

            return matricula;
        }


        public async Task<MatriculaDto> CreateAsync(MatriculaDto matriculaDto)
        {
            var matricula = _mapper.Map<Matricula>(matriculaDto);
            await _matriculaRepository.SaveAsync(matricula);
            return _mapper.Map<MatriculaDto>(matricula);
        }

        public async Task<MatriculaDto> DeleteAsync(int id)
        {
            var matricula = await _matriculaRepository.GetByIdAsync(id);

            if (matricula == null)
                throw new Exception("Matricula não encontrada");

            await _matriculaRepository.DeleteAsync(matricula.Id);

            return _mapper.Map<MatriculaDto>(matricula);
        }

        public async Task<IEnumerable<MatriculaDto>> GetAllAsync()
        {
            var matriculas = await _matriculaRepository.GetAllAsync();
            var matriculasDto = _mapper.Map<IEnumerable<MatriculaDto>>(matriculas);
            return matriculasDto;

        }

       
    }
}
