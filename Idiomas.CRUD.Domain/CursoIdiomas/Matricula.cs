using Idiomas.CRUD.Domain.Base;
using Idiomas.CRUD.Domain.CursoIdiomas;

namespace Idiomas.CRUD.Domain
{
    public class Matricula : Entity<int>
    {        
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }
        public Aluno Aluno { get; set; }
        public Turma Turma { get; set; }
        
    }
}
