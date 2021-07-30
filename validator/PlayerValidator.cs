using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamPlayCRUD.Models;

namespace TeamPlayCRUD.validator
{
    public class PlayerValidator : AbstractValidator<Player>
    {
        public PlayerValidator()
        {
            RuleFor(p=>p.FirstName)
                .NotEmpty().WithMessage("Campo requerido")
                .NotNull().WithMessage("Campo requerido")
                .MaximumLength(50).WithMessage("No puede exceder de 50 caracteres");

            RuleFor(p => p.LastName)
               .NotEmpty().WithMessage("Campo requerido")
               .NotNull().WithMessage("Campo requerido")
               .MaximumLength(50).WithMessage("No puede exceder de 50 caracteres");

            RuleFor(p => p.DateBirth)
            .NotEmpty().WithMessage("Campo requerido")
            .NotNull().WithMessage("Campo requerido");

            RuleFor(p => p.Passport)
               .NotEmpty().WithMessage("Campo requerido")
               .NotNull().WithMessage("Campo requerido")
               .MaximumLength(10).WithMessage("No puede exceder de 10 caracteres");

            RuleFor(p => p.Address)
               .NotEmpty().WithMessage("Campo requerido")
               .NotNull().WithMessage("Campo requerido")
               .MaximumLength(100).WithMessage("No puede exceder de 100 caracteres");

            RuleFor(p => p.Gender)
              .NotEmpty().WithMessage("Campo requerido")
              .NotNull().WithMessage("Campo requerido")
              .MaximumLength(1);

            RuleFor(p => p.StateId).NotEmpty().WithMessage("Campo requerido")
                .NotNull().WithMessage("Campo requerido");

            RuleFor(p => p.TeamId).NotEmpty().WithMessage("Campo requerido")
               .NotNull().WithMessage("Campo requerido");

        }
    }
}
