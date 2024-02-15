using Idiomas.CRUD.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idiomas.CRUD.Application.Services
{
    public interface ITurmaServices
    {
        Task<IEnumerable<TurmaDto>> GetAllAsync();
          
    }
}
