using Idiomas.CRUD.Application.Dtos;
using Idiomas.CRUD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idiomas.CRUD.Application.Services
{
    public interface IMatriculaService 
    {

        Task<MatriculaDto> CriarMatriculaAsync(MatriculaInputDto matriculaDto);
        Task<IEnumerable<MatriculaDto>> GetAllAsync();
        Task<MatriculaDto> DeleteAsync(int id);
        
    }
}
