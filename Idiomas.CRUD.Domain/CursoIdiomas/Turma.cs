
using System.ComponentModel.DataAnnotations;

namespace Idiomas.CRUD.Domain.CursoIdiomas
{
    public class Turma 
    {
        [Key]   
        public int TurmaId { get; set; }
        public int Numero { get; set; }
        public int AnoLetivo { get; set; }
            
        public virtual ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();  

        public virtual ICollection<Matricula> Matricula { get; set; } = new List<Matricula>();
        //EF
        protected Turma() { }
    }
}
