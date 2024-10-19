using ClincProject.Core.Features.Users.Commands.Models;
using FluentValidation;

namespace ClincProject.Core.Features.Users.Commands.Validatiors
{
    public class EditUserValidatior : AbstractValidator<EditUserCommand>
    {

        #region Constructors
        public EditUserValidatior()
        {
            ApplyValidationsRules();
        }
        #endregion

        #region Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.")
                .MaximumLength(200);

            RuleFor(x => x.UserName)
               .NotEmpty().WithMessage("Can't be empty.")
               .NotNull().WithMessage("Can't be blank.")
               .MaximumLength(100);

            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("Can't be empty.")
               .NotNull().WithMessage("Can't be blank.")
               .MaximumLength(100);


        }
        #endregion

    }
}
