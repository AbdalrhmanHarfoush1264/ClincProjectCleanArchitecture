using ClincProject.Core.Features.Users.Commands.Models;
using FluentValidation;

namespace ClincProject.Core.Features.Users.Commands.Validatiors
{
    public class ChangeUserPasswordValidatior : AbstractValidator<ChangeUserPasswordCommand>
    {
        #region Constructors
        public ChangeUserPasswordValidatior()
        {
            ApplyValidationsRules();
        }
        #endregion

        #region Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.CurrentPassword)
               .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.NewPassword)
               .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.ConfirmPassword)
               .NotNull().WithMessage("Can't be blank.")
               .Equal(x => x.NewPassword).WithMessage("newPassword and confirmPassword not Equals.");


        }
        #endregion
    }
}
