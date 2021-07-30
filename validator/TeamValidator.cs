using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamPlayCRUD.Models;

namespace TeamPlayCRUD.validator
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("Campo requerido")
                .NotNull().WithMessage("Campo requerido")
                .MaximumLength(50).WithMessage("No puede exceder de 50 caracteres");

            RuleFor(t => t.CountryCode)
                .NotEmpty().WithMessage("Campo requerido")
                .NotNull().WithMessage("Campo requerido")
                .NotEqual("").WithMessage("Campo requerido");
        }
    }
}
