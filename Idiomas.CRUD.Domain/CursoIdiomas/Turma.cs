using Idiomas.CRUD.Domain.Base;

namespace Idiomas.CRUD.Domain.CursoIdiomas
{
    public class Turma : Entity<Guid>
    {
    

        protected Turma() { 
        
        }
        public string Numero {  get; set; }
        public int AnoLetivo {  get; set; }

        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
    }
}
