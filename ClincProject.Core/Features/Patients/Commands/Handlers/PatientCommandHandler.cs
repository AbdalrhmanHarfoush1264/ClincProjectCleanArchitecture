using AutoMapper;
using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Patients.Commands.Models;
using ClincProject.Data.Entities;
using ClincProject.Service.Abstracts;
using MediatR;

namespace ClincProject.Core.Features.Patients.Commands.Handlers
{
    public class PatientCommandHandler : CusResponseHandler,
        IRequestHandler<AddPatientCommand, CusResponse<string>>,
        IRequestHandler<EditPatientCommand, CusResponse<string>>,
        IRequestHandler<DeletePatientCommand, CusResponse<string>>
    {
        #region Fileds
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor(s)
        public PatientCommandHandler(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }
        #endregion

        #region Handle Functions
        public async Task<CusResponse<string>> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return BadRequest<string>("the request can't be blank");

            var patientMapper = _mapper.Map<Patient>(request);
            var result = await _patientService.CreatePatientAsync(patientMapper);

            if (!result)
                return BadRequest<string>("Added Operation Failed.");

            return Success("Added Operation Successfully.");
        }

        public async Task<CusResponse<string>> Handle(EditPatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientService.GetPatientByIdAsync(request.Id);
            if (patient == null)
                return BadRequest<string>("Patient with this id not found!");

            var patientMapper = _mapper.Map<Patient>(request);
            var result = await _patientService.UpdatePatientAsync(patientMapper);
            if (!result)
                return BadRequest<string>("Updated Operation Failed.");

            return Success("Updated Operation Successfully.");
        }

        public async Task<CusResponse<string>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientService.GetPatientByIdAsync(request.Id);
            if (patient == null)
                return BadRequest<string>("Patient with this id not found!");

            var result = await _patientService.DeletePatientAsync(patient);
            if (!result)
                return BadRequest<string>("Deleted Operation Failed.");

            return Success("Deleted Operation Successfully.");
        }
        #endregion

    }
}
