using Idiomas.CRUD.Domain.CursoIdiomas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idiomas.CRUD.Application.Dtos
{
    public class MatriculaInputDto
    {
      
        public int? AlunoId { get; set; }
        public int? TurmaId { get; set; }
        
    }
}
