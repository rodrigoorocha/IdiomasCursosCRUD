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

        public async Task<TurmaDto> CreateAsync(TurmaDto turmaDto)
        {

            var turma = _mapper.Map<Turma>(turmaDto);
            await _turmaRepository.SaveAsync(turma);
            return _mapper.Map<TurmaDto>(turma);

        }

        public async Task<TurmaDto> DeleteAsync(int id)
        {
           
            var turma = await _turmaRepository.GetByIdAsync(id);

            if (turma == null)
                throw new Exception("Turma não encontrada");

            await _turmaRepository.DeleteAsync(turma.Id);

            return _mapper.Map<TurmaDto>(turma);
        }

        public async Task<IEnumerable<TurmaDto>> GetAllAsync()
        {
            var query = await _turmaRepository.GetAllAsync();

            var turmaDto = _mapper.Map<IEnumerable<TurmaDto>>(query);
            return turmaDto;

        }

        public async Task<TurmaDto> UpdateAsync(TurmaDto turmaDto)
        {

            var turma = await _turmaRepository.GetTurmaById((int)turmaDto.Id);

            if (turma == null)
                throw new Exception("Turma não encontrada");                      
                                    
            await _turmaRepository.UpdateAsync(turma);

            return _mapper.Map<TurmaDto>(turma);
        }
    }
}
