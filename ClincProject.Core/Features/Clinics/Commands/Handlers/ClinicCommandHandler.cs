using AutoMapper;
using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Clinics.Commands.Models;
using ClincProject.Data.Entities;
using ClincProject.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClincProject.Core.Features.Clinics.Commands.Handlers
{
    public class ClinicCommandHandler : CusResponseHandler,
        IRequestHandler<AddClinicCommand, CusResponse<string>>,
        IRequestHandler<EditClinicCommand, CusResponse<string>>,
        IRequestHandler<DeleteClinicCommand, CusResponse<string>>
    {
        private readonly IClinicService _clinicService;
        private readonly IMapper _mapper;
        private readonly ILogger<ClinicCommandHandler> _logger;
        #region Fileds

        #endregion

        #region Constructors

        public ClinicCommandHandler(IClinicService clinicService, IMapper mapper, ILogger<ClinicCommandHandler> logger)
        {
            _clinicService = clinicService;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region Handle Functions

        #endregion

        public async Task<CusResponse<string>> Handle(AddClinicCommand request, CancellationToken cancellationToken)
        {
            try
            {


                var IsClinicExist = await _clinicService.IsClinicExistByNameAsync(request.Name);
                if (IsClinicExist)
                    return BadRequest<string>("This clinic name already exists.");

                var clinicMapper = _mapper.Map<Clinic>(request);
                var IsAdded = await _clinicService.CreateClinicAsync(clinicMapper);
                if (!IsAdded)
                    return BadRequest<string>("Clinic Added Operation is Failed.");

                return Success("Clinic Added Operation is Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<CusResponse<string>> Handle(EditClinicCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var IsExist = await _clinicService.IsClinicExistByIdAsync(request.Id);
                if (!IsExist)
                    return NotFound<string>("the clinc isn't exist.");

                var clinicMapper = _mapper.Map<Clinic>(request);
                var isEdit = await _clinicService.EditClinicAsync(clinicMapper);
                if (!isEdit)
                    return BadRequest<string>("Updated Operation Failed.");

                return Success("Updated Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<CusResponse<string>> Handle(DeleteClinicCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var isExist = await _clinicService.IsClinicExistByIdAsync(request.Id);
                if (!isExist)
                    return NotFound<string>("clinic with this id not found.");

                var clinicExist = await _clinicService.GetClinicByIdAsync(request.Id);
                var isDeleted = await _clinicService.DeleteClinicAsync(clinicExist);
                if (!isDeleted)
                    return BadRequest<string>("Deleted Operation Failed.");

                return Success("Deleted Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }
    }
}
