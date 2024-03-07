
using Idiomas.CRUD.Domain.CursoIdiomas;

namespace Idiomas.CRUD.Application.Dtos
{
    public class MatriculaDto
    {
        public int? MatriculaId { get; set; }
        public int? AlunoId { get; set; }
        public int? TurmaId { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Turma Turma { get; set; }
    }
}
