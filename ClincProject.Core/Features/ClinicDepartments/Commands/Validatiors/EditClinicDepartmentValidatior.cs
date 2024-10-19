using ClincProject.Core.Features.ClinicDepartments.Commands.Models;
using ClincProject.Service.Abstracts;
using FluentValidation;

namespace ClincProject.Core.Features.ClinicDepartments.Commands.Validatiors
{
    public class EditClinicDepartmentValidatior : AbstractValidator<EditClinicDepartmentCommand>
    {
        #region Fileds
        private readonly IClinicService _clinicService;
        #endregion

        #region Constructor(s)
        public EditClinicDepartmentValidatior(IClinicService clinicService)
        {
            _clinicService = clinicService;
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

            RuleFor(x => x.DepartmentName)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.")
                .MaximumLength(500);

            RuleFor(x => x.ClinicId)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.");

        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.ClinicId)
                .MustAsync(async (key, CancellationToken) => await _clinicService.IsClinicExistByIdAsync(key))
                .WithMessage("is not Exist.");
        }
        #endregion
    }
}