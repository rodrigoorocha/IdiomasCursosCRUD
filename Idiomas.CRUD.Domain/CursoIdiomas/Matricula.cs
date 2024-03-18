using Idiomas.CRUD.Domain.Base;
using Idiomas.CRUD.Domain.CursoIdiomas;
using System.ComponentModel.DataAnnotations;

namespace Idiomas.CRUD.Domain
{
    public class Matricula : Entity<int>
    {
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Turma Turma { get; set; }       
        //EF
        protected Matricula() { }
    }
}
