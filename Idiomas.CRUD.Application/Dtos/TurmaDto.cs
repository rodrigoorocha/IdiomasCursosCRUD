using Idiomas.CRUD.Domain.CursoIdiomas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idiomas.CRUD.Application.Dtos
{
    public class TurmaDto
    {
        public Guid Id { get; set; }
      
        public string Numero { get; set; }
        public int AnoLetivo { get; set; }

    }
}
