using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamPlayCRUD.Models;

namespace TeamPlayCRUD.validator
{
    public class StateValidator : AbstractValidator<State>
    {
        public StateValidator()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage("Campo requerido")
                .NotNull().WithMessage("Campo requerido")
                .MaximumLength(13).WithMessage("No puede exceder de 13 caracteres");

        }
    }
}
