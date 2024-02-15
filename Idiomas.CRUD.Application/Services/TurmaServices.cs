using AutoMapper;
using Idiomas.CRUD.Application.Dtos;
using Idiomas.CRUD.Domain.CursoIdiomas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<TurmaDto>> GetAllAsync()
        {
            var query = await _turmaRepository.GetAll();

            var turmaDto = _mapper.Map<IEnumerable<TurmaDto>>(query);
            return turmaDto;

        }
    }
}
