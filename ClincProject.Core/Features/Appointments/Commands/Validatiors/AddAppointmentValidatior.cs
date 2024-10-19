using ClincProject.Core.Features.Appointments.Commands.Models;
using ClincProject.Service.Abstracts;
using FluentValidation;

namespace ClincProject.Core.Features.Appointments.Commands.Validatiors
{
    public class AddAppointmentValidatior : AbstractValidator<AddAppointmentCommand>
    {

        #region Fileds
        private readonly IPatientCaseService _patientCaseService;
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentStatusService _appointmentStatusService;
        #endregion

        #region Constructors

        public AddAppointmentValidatior(IPatientCaseService patientCaseService,
            IDoctorService doctorService, IAppointmentStatusService appointmentStatusService)
        {
            _appointmentStatusService = appointmentStatusService;
            _patientCaseService = patientCaseService;
            _doctorService = doctorService;

            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #endregion
        #region Functions
        public void ApplyValidationsRules()
        {


            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.EndTime)
                .NotNull().WithMessage("Can't be empty.");

            RuleFor(x => x.PatientCaseId)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.DoctorId)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.AppointmentStatusId)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.");
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.PatientCaseId)
                .MustAsync(async (key, CancellationToken) => await _patientCaseService.IsPatientCaseExistById(key))
                .WithMessage(": not found patient Case with this Id.");

            RuleFor(x => x.DoctorId)
               .MustAsync(async (key, CancellationToken) => await _doctorService.IsDoctorExistById(key))
               .WithMessage(": not found Doctor with this Id.");

            RuleFor(x => x.PatientCaseId)
               .MustAsync(async (key, CancellationToken) => await _appointmentStatusService.IsAppointmentStatusByIdAsync(key))
               .WithMessage(": not found  appointment Status with this Id.");
        }
        #endregion
    }
}
