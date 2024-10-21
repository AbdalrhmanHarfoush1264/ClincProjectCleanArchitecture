using ClincProject.Core.Features.Authentications.Commands.Models;
using FluentValidation;

namespace ClincProject.Core.Features.Authentications.Commands.Validatiors
{
    public class SignInValidatior : AbstractValidator<SignInCommand>
    {

        public SignInValidatior()
        {
            ApplyValidationsRules();
        }

        #region Functions
        public void ApplyValidationsRules()
        {

            RuleFor(x => x.UserName)
                 .NotNull().WithMessage("Can't be empty.");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Can't be empty.");
        }
        #endregion
    }
}
