
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
                    .WithMessage("Email is required.")
                    .NotNull()
                    .WithMessage("Email is required.");

            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .NotNull()
                .WithMessage("Password is required.")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.");
                 

        }
    }
}
