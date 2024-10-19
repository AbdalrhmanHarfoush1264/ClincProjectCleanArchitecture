using ClincProject.Core.Features.EmployeeSchedulesFile.Commands.Models;
using ClincProject.Service.Abstracts;
using FluentValidation;

namespace ClincProject.Core.Features.EmployeeSchedulesFile.Commands.Validatiors
{
    public class EditEmployeeScheduleValidatior : AbstractValidator<EditEmployeeScheduleCommand>
    {
        #region Fileds
        private readonly IClinicDepartmentService _clinicDepartmentService;
        private readonly IDoctorService _doctorService;
        #endregion

        #region Constructor(s)
        public EditEmployeeScheduleValidatior(IDoctorService doctorService,
            IClinicDepartmentService clinicDepartmentService)
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            _doctorService = doctorService;
            _clinicDepartmentService = clinicDepartmentService;
        }

        #endregion

        #region Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Can't be empty.")
               .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.DoctorId)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.DepartmentId)
               .NotEmpty().WithMessage("Can't be empty.")
               .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.TimeFrom)
               .NotEmpty().WithMessage("Can't be empty.")
               .NotNull().WithMessage("Can't be blank.");


            RuleFor(x => x.TimeTo)
              .NotEmpty().WithMessage("Can't be empty.")
             .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.IsActive)
            .NotNull().WithMessage("Can't be blank.");
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.DoctorId)
                .MustAsync(async (key, CancellationToken) => await _doctorService.IsDoctorExistById(key))
                .WithMessage(": Doctor with this Id not exist.");

            RuleFor(x => x.DepartmentId)
                .MustAsync(async (key, CancellationToken) => await _clinicDepartmentService.IsDepartmentExistById(key))
                .WithMessage(": Department with this Id not exist.");
        }

        #endregion
    }
}
