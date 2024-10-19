using ClincProject.Core.Features.Documents.Commands.Models;
using ClincProject.Service.Abstracts;
using FluentValidation;

namespace ClincProject.Core.Features.Documents.Commands.Validatiors
{
    public class AddDocumentValidator : AbstractValidator<AddDocumentCommand>
    {
        #region Fileds
        private readonly IDocumentTypeService _documentTypeService;
        private readonly IAppointmentService _appointmentService;



        #endregion


        #region Constructors
        public AddDocumentValidator(IDocumentTypeService documentTypeService,
           IAppointmentService appointmentService)
        {
            _documentTypeService = documentTypeService;
            _appointmentService = appointmentService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #endregion


        #region Functions
        public void ApplyValidationsRules()
        {


            RuleFor(x => x.DocumentName)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.");


            RuleFor(x => x.DocumentTypeId)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.AppointmentId)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.");

        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.DocumentTypeId)
                .MustAsync(async (key, CancellationToken) => await _documentTypeService.IsDocumentTypeExistByIdAsync(key))
                .WithMessage(": not found document type with this Id.");

            RuleFor(x => x.AppointmentId)
               .MustAsync(async (key, CancellationToken) => await _appointmentService.IsAppointmentExistByIdAsync(key))
               .WithMessage(": not found appointment with this Id.");

        }
        #endregion
    }
}
