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
        public int MatriculaId { get; set; }
        public int? AlunoId { get; set; }
        public int? TurmaId { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Turma Turma { get; set; }
    }
}
