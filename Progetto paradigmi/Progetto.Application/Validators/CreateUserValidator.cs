
using FluentValidation;
using Progetto_paradigmi.Progetto.Application.DTO;
using System.Text.RegularExpressions;
namespace Progetto_paradigmi.Progetto.Application.Validators

{
    public class CreateUserValidator : AbstractValidator<UtentiDTO>
    {
        public CreateUserValidator() {
            RuleFor(r => r.Email)
                    .NotEmpty()
                    .WithMessage("")
                    .NotNull()
                    .WithMessage("");

            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("")
                .NotNull()
                .WithMessage("")
                .MinimumLength(6)
                .WithMessage("");
                 

        }
    }
}
