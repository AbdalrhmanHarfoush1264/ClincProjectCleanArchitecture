using ClincProject.Core.Features.Patients.Commands.Models;
using ClincProject.Service.Abstracts;
using FluentValidation;

namespace ClincProject.Core.Features.Patients.Commands.Validatiors
{
    public class EditPatientValidatior : AbstractValidator<EditPatientCommand>
    {
        #region Fileds
        private readonly IPatientService _patientService;

        #endregion

        #region Constructor(s)
        public EditPatientValidatior(IPatientService patientService)
        {
            _patientService = patientService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #endregion

        #region Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.")
                .MaximumLength(150);

            RuleFor(x => x.LastName)
               .NotEmpty().WithMessage("Can't be empty.")
               .NotNull().WithMessage("Can't be blank.")
               .MaximumLength(150);

            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("Can't be empty.")
               .NotNull().WithMessage("Can't be blank.")
               .MaximumLength(250);


            RuleFor(x => x.Gender)
             //.NotEmpty().WithMessage("Can't be empty.")
             .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.DateOfBirth)
             .NotEmpty().WithMessage("Can't be empty.")
             .NotNull().WithMessage("Can't be blank.");
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Email)
                .MustAsync(async (key, CancellationToken) => !await _patientService.IsEmailExist(key))
                .WithMessage("already Exist.");
        }
        #endregion
    }
}
