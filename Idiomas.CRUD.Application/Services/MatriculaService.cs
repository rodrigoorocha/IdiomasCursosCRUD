using AutoMapper;
using Idiomas.CRUD.Application.Dtos;
using Idiomas.CRUD.Domain;
using Idiomas.CRUD.Domain.CursoIdiomas;
using Idiomas.CRUD.Domain.CursoIdiomas.Repository;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Idiomas.CRUD.Application.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMapper _mapper;
        private readonly IMatriculaRepository _matriculaRepository;
        private readonly ITurmaRepository _turmaRepository;
        private readonly IAlunoRepository _alunoRepository;

        //contrutor da classe MatriculaService
        public MatriculaService(IMapper mapper, IMatriculaRepository matriculaRepository, ITurmaRepository turmaRepository, IAlunoRepository alunoRepository)
        {
            _matriculaRepository = matriculaRepository;
            _turmaRepository = turmaRepository;
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }
        

        public async Task<MatriculaDto> CriarMatriculaAsync(MatriculaDto matriculaDto)
        {
            var aluno = await _alunoRepository.GetByIdAsync(matriculaDto.AlunoId.Value);
            if (aluno == null)
            {
                throw new InvalidOperationException("Aluno não encontrado.");
            }

            var turma = await _turmaRepository.GetByIdAsync(matriculaDto.TurmaId.Value);
            if (turma == null)
            {
                throw new InvalidOperationException("Turma não encontrada.");
            }

            var matricula = _mapper.Map<Matricula>(matriculaDto);
            await _matriculaRepository.SaveAsync(matricula);
            return _mapper.Map<MatriculaDto>(matricula);

           
        }
        

        public async Task<MatriculaDto> DeleteAsync(int id)
        {
            var matricula = await _matriculaRepository.GetByIdAsync(id);

            if (matricula == null)
                throw new Exception("Matricula não encontrada");

            await _matriculaRepository.DeleteAsync(matricula.MatriculaId);

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
