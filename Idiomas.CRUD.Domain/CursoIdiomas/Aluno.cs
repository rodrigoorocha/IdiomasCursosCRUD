using FluentValidation;
using Idiomas.CRUD.Domain.Base;
using Idiomas.CRUD.Domain.CursoIdiomas.Rules;
using Idiomas.CRUD.Domain.CursoIdiomas.ValueObject;
using System.ComponentModel.DataAnnotations;


namespace Idiomas.CRUD.Domain.CursoIdiomas
{
    public class Aluno : Entity<int>
    {
        public string Nome { get; set; }
        public Cpf Cpf { get; set; }
        public Email Email { get; set; }
        public virtual ICollection<Turma> Turmas { get; set; } = new List<Turma>();

        public void Validate() =>
            new AlunoValidator().ValidateAndThrow(this);
        protected Aluno()
        {
                
        }

    }
}
