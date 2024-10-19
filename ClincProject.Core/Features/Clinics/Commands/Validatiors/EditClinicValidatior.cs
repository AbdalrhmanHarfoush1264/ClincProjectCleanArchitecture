using ClincProject.Core.Features.Clinics.Commands.Models;
using FluentValidation;

namespace ClincProject.Core.Features.Clinics.Commands.Validatiors
{
    public class EditClinicValidatior : AbstractValidator<EditClinicCommand>
    {
        #region Fileds

        #endregion

        #region Constructor(s)
        public EditClinicValidatior()
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