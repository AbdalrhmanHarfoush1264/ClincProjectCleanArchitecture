using AutoMapper;
using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.PatientCases.Commands.Models;
using ClincProject.Data.Entities;
using ClincProject.Service.Abstracts;
using MediatR;

namespace ClincProject.Core.Features.PatientCases.Commands.Handlers
{
    public class PatientCaseCommandHandler : CusResponseHandler,
        IRequestHandler<AddPatientCaseCommand, CusResponse<string>>,
        IRequestHandler<EditPatientCaseCommand, CusResponse<string>>,
        IRequestHandler<DeletePatientCaseCommand, CusResponse<string>>
    {

        #region Fileds
        private readonly IMapper _mapper;
        private readonly IPatientCaseService _patientCaseService;
        #endregion

        #region Constructors
        public PatientCaseCommandHandler(IMapper mapper,
            IPatientCaseService patientCaseService)
        {
            _mapper = mapper;
            _patientCaseService = patientCaseService;
        }
        #endregion

        #region Functions
        public async Task<CusResponse<string>> Handle(AddPatientCaseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return BadRequest<string>("the request can't be blank.");

                var patientCaseMapper = _mapper.Map<PatientCase>(request);

                var result = await _patientCaseService.AddPatientCaseAsync(patientCaseMapper);

                if (!result)
                    return BadRequest<string>("Added Operation Failed.");

                return Success("Added Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<CusResponse<string>> Handle(EditPatientCaseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return BadRequest<string>("the request can't be blank");

                var isExist = await _patientCaseService.IsPatientCaseExistById(request.Id);
                if (!isExist)
                    return NotFound<string>("patientCase with this id not found!");

                var PatientCaseMapper = _mapper.Map<PatientCase>(request);
                var result = await _patientCaseService.UpdatePatientCaseAsync(PatientCaseMapper);
                if (!result)
                    return BadRequest<string>("Updated Operation Failed.");

                return Success("Updated Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<CusResponse<string>> Handle(DeletePatientCaseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return BadRequest<string>("the request can't be blank");

                var isExist = await _patientCaseService.GetPatientCaseByIdAsync(request.Id);
                if (isExist == null)
                    return NotFound<string>("patientCase with this id not found!");

                var result = await _patientCaseService.DeletePatientCaseAsync(isExist);
                if (!result)
                    return BadRequest<string>("Deleted Operation Failed.");

                return Success("Deleted Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }
        #endregion

    }
}
