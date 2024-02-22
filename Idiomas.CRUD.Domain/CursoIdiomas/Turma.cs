using Idiomas.CRUD.Domain.Base;
using Idiomas.CRUD.Domain.CursoIdiomas.ValueObject;

namespace Idiomas.CRUD.Domain.CursoIdiomas
{
    public class Turma : Entity<int>
    {
    

        protected Turma() { 
        
        }
        public int Numero { get; set; }
        public int AnoLetivo { get; set; }
        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();


    }
}
