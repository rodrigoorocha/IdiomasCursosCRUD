using Idiomas.CRUD.Domain.Base;

namespace Idiomas.CRUD.Domain.CursoIdiomas
{
    public class Turma : Entity<int>
    {
        public int Numero { get; set; }
        public int AnoLetivo { get; set; }
            
        public virtual ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();  

        public virtual ICollection<Matricula> Matricula { get; set; } = new List<Matricula>();
        //EF
        protected Turma() { }
    }
}
