using FluentValidation;
using Idiomas.CRUD.Domain.CursoIdiomas.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Idiomas.CRUD.Domain.CursoIdiomas.Rules
{
    public class CpfValidator : AbstractValidator<Cpf>
    {

        private const string Pattern = @"^\d{3}.?\d{3}.?\d{3}-?\d{2}$";

        public CpfValidator() {
            RuleFor(x => x.Numero)
                .NotEmpty()
                .Must(BeCpfValid).WithMessage("cpf inválido");
        
        }

        private bool BeCpfValid(string value)=> Regex.IsMatch(value, Pattern);


    }
}
