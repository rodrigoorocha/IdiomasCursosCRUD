using Idiomas.CRUD.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idiomas.CRUD.Application.ViewModel
{
    public class MatriculaViewModel
    {
        public int? MatriculaId { get; set; }
        public int? AlunoId { get; set; }
        public int? TurmaId { get; set; }
        public virtual AlunoDto Aluno { get; set; }
        public virtual TurmaDto Turma { get; set; }
    }
}
