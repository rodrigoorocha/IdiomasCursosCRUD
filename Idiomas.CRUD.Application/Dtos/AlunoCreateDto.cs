using Idiomas.CRUD.Domain.CursoIdiomas.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Idiomas.CRUD.Application.Dtos
{
    public class AlunoCreateDto
    {
       
        public string Nome { get; set; }
        public Cpf Cpf { get; set; }
        public Email Email { get; set; }
        public virtual ICollection<TurmaDto>? TurmasDto { get; set; } = new List<TurmaDto>();
    }

}
