using FluentValidation;

namespace Idiomas.CRUD.Domain.CursoIdiomas.Rules
{
    public class AlunoValidator : AbstractValidator<Aluno>
    {
        public AlunoValidator()
        {
                RuleFor(x=>x.Email).SetValidator(new EmailValidator());
                RuleFor(x=>x.Cpf).SetValidator(new CpfValidator()); 
        }
    }
}
