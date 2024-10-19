using AutoMapper;
using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Clinics.Queries.Models;
using ClincProject.Core.Features.Clinics.Queries.Response;
using ClincProject.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClincProject.Core.Features.Clinics.Queries.Handlers
{
    public class ClinicQueryHandler : CusResponseHandler,
        IRequestHandler<IsClinicExistByNameQuery, CusResponse<string>>,
        IRequestHandler<IsClinicExistByIdQuery, CusResponse<string>>,
        IRequestHandler<GetClinicListQuery, CusResponse<List<GetClinicListResponse>>>
    {
        #region Fileds
        private readonly IClinicService _clinicService;
        private readonly ILogger<ClinicQueryHandler> _logger;
        private readonly IMapper _mapper;
        #endregion


        #region Constructor(s)

        public ClinicQueryHandler(IClinicService clinicService,
            ILogger<ClinicQueryHandler> logger, IMapper mapper)
        {
            _clinicService = clinicService;
            _logger = logger;
            _mapper = mapper;
        }
        #endregion


        #region Functions
        public async Task<CusResponse<string>> Handle(IsClinicExistByNameQuery request, CancellationToken cancellationToken)
        {
            try
            {


                var IsClinicExist = await _clinicService.IsClinicExistByNameAsync(request.ClinicName);
                if (!IsClinicExist)
                    return NotFound<string>("clinic with this name is't exist.");

                return Success("clinic with this name is exist.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<CusResponse<string>> Handle(IsClinicExistByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var IsClinicExist = await _clinicService.IsClinicExistByIdAsync(request.Id);
                if (!IsClinicExist)
                    return NotFound<string>("clinic with this Id is't exist.");

                return Success("clinic with this Id is exist.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<CusResponse<List<GetClinicListResponse>>> Handle(GetClinicListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var clinicList = await _clinicService.GetClinicListAsync();
                var clinicListMapper = _mapper.Map<List<GetClinicListResponse>>(clinicList);

                return Success(clinicListMapper);

            }
            catch (Exception ex)
            {
                return ServerError<List<GetClinicListResponse>>(ex.Message);
            }
        }
        #endregion

    }
}
