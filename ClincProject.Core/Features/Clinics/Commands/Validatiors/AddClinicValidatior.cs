using ClincProject.Core.Features.Clinics.Commands.Models;
using FluentValidation;

namespace ClincProject.Core.Features.Clinics.Commands.Validatiors
{
    public class AddClinicValidatior : AbstractValidator<AddClinicCommand>
    {
        #region Fileds

        #endregion

        #region Constructor(s)
        public AddClinicValidatior()
        {
            ApplyValidationsRules();
        }

        #endregion

        #region Functions
        public void ApplyValidationsRules()
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.")
                .MaximumLength(500);

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.")
                .MaximumLength(700);

        }

        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}

