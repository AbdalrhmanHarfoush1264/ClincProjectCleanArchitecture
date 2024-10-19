using ClincProject.Core.Features.Doctors.Commands.Models;
using ClincProject.Service.Abstracts;
using FluentValidation;

namespace ClincProject.Core.Features.Doctors.Commands.Validatiors
{
    public class EditDoctorValidatior : AbstractValidator<EditDoctorCommand>
    {
        #region Fileds
        private readonly IDoctorService _doctorService;

        #endregion

        #region Constructor(s)
        public EditDoctorValidatior(IDoctorService doctorService)
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            _doctorService = doctorService;
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
             .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.DateOfBirth)
             .NotEmpty().WithMessage("Can't be empty.")
             .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.IsActive)
            .NotNull().WithMessage("Can't be blank.");
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Email)
                .MustAsync(async (key, CancellationToken) => !await _doctorService.IsEmailExist(key))
                .WithMessage("already Exist.");
        }

        #endregion
    }
}
