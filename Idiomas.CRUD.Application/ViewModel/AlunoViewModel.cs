using Idiomas.CRUD.Domain.CursoIdiomas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idiomas.CRUD.Application.ViewModel
{
    public class AlunoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }        
        public Guid? TurmaId { get; set; }
        public string? NomeTurma { get; set; }

       
    }
}
