using FluentValidation;
using Idiomas.CRUD.Domain.CursoIdiomas.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Idiomas.CRUD.Domain.CursoIdiomas.Rules
{
    public class EmailValidator : AbstractValidator<Email> 
    {

        private const string Pattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

        public EmailValidator()
        {
            RuleFor(x => x.Valor)
                .NotEmpty()
                .Must(BeAEmailValid).WithMessage("Email inválido");
        }
        private bool BeAEmailValid(string valor) => Regex.IsMatch(valor, Pattern);
    }
}
