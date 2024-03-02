using FluentValidation;
using Idiomas.CRUD.Domain.Base;
using Idiomas.CRUD.Domain.CursoIdiomas.Rules;
using Idiomas.CRUD.Domain.CursoIdiomas.ValueObject;


namespace Idiomas.CRUD.Domain.CursoIdiomas
{
    public class Aluno: Entity<int>
    {     

        //EF
        protected Aluno() { }
        public string Nome { get; set; }
        public Cpf Cpf { get; set; }
        public Email Email { get; set; }
        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();

        public void Validate() =>
            new AlunoValidator().ValidateAndThrow(this);


    }
}
