using ClincProject.Core.Features.Schedules.Commands.Models;
using ClincProject.Service.Abstracts;
using FluentValidation;

namespace ClincProject.Core.Features.Schedules.Commands.Validatiors
{
    public class EditScheduleValidatior : AbstractValidator<EditScheduleCommand>
    {
        #region Fileds
        private readonly IEmployeeScheduleService _employeeScheduleService;

        #endregion

        #region Constructor(s)
        public EditScheduleValidatior(IEmployeeScheduleService employeeScheduleService)
        {
            _employeeScheduleService = employeeScheduleService;
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

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.TimeStart)
               .NotEmpty().WithMessage("Can't be empty.")
               .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.TimeEnd)
               .NotEmpty().WithMessage("Can't be empty.")
               .NotNull().WithMessage("Can't be blank.");


            RuleFor(x => x.EmployeeSchedulesId)
              .NotEmpty().WithMessage("Can't be empty.")
             .NotNull().WithMessage("Can't be blank.");


        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.EmployeeSchedulesId)
                .MustAsync(async (key, CancellationToken) => await _employeeScheduleService.IsEmployeeScheduleExist(key))
                .WithMessage(": EmployeeSchedules with this Id not exist.");

        }

        #endregion
    }
}
