using Idiomas.CRUD.Domain.CursoIdiomas;
using System.ComponentModel.DataAnnotations;

namespace Idiomas.CRUD.Domain
{
    public class Matricula
    {
        [Key]
        public int MatriculaId { get; set; }
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Turma Turma { get; set; }       
        //EF
        protected Matricula() { }
    }
}
