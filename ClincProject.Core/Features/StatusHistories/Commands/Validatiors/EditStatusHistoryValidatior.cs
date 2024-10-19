using ClincProject.Core.Features.StatusHistories.Commands.Models;
using ClincProject.Service.Abstracts;
using FluentValidation;

namespace ClincProject.Core.Features.StatusHistories.Commands.Validatiors
{
    public class EditStatusHistoryValidatior : AbstractValidator<EditStatusHistoryCommand>
    {
        #region Fileds
        private readonly IAppointmentService _appointmentService;
        private readonly IAppointmentStatusService _appointmentStatusService;
        #endregion

        #region Constructors

        public EditStatusHistoryValidatior(IAppointmentService appointmentService, IAppointmentStatusService appointmentStatusService)
        {

            _appointmentService = appointmentService;
            _appointmentStatusService = appointmentStatusService;

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

            RuleFor(x => x.AppointmentStatusID)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.AppointmentId)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.");
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.AppointmentId)
                .MustAsync(async (key, CancellationToken) => await _appointmentService.IsAppointmentExistByIdAsync(key))
                .WithMessage(": not found Appointment with this Id.");

            RuleFor(x => x.AppointmentStatusID)
               .MustAsync(async (key, CancellationToken) => await _appointmentStatusService.IsAppointmentStatusByIdAsync(key))
               .WithMessage(": not found appointment status with this Id.");

        }
        #endregion

    }
}
