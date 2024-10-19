using AutoMapper;
using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Doctors.Queries.Models;
using ClincProject.Core.Features.Doctors.Queries.Response;
using ClincProject.Core.Wappers;
using ClincProject.Data.Entities;
using ClincProject.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace ClincProject.Core.Features.Doctors.Queries.Handlers
{
    public class DoctorQueryHandler : CusResponseHandler,
        IRequestHandler<GetDoctorsListQuery, CusResponse<List<GetDoctorsListResponse>>>,
        IRequestHandler<GetDoctorByIdQuery, CusResponse<GetSingleDoctorResponse>>,
        IRequestHandler<GetDoctorsPaginatedQuery, PaginatedResult<GetDoctorsPaginatedResponse>>
    {
        #region Fileds
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        private readonly ILogger<DoctorQueryHandler> _logger;

        #endregion

        #region Constructor(s)
        public DoctorQueryHandler(ILogger<DoctorQueryHandler> logger,
            IDoctorService doctorService, IMapper mapper)
        {
            _logger = logger;
            _doctorService = doctorService;
            _mapper = mapper;
        }
        #endregion

        #region Functions


        public async Task<CusResponse<List<GetDoctorsListResponse>>> Handle(GetDoctorsListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _doctorService.GetDoctorListAsync();
                var doctorsMapper = _mapper.Map<List<GetDoctorsListResponse>>(result);
                return Success(doctorsMapper);
            }
            catch (Exception ex)
            {
                return ServerError<List<GetDoctorsListResponse>>(ex.Message);
            }
        }

        public async Task<CusResponse<GetSingleDoctorResponse>> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var doctor = await _doctorService.GetDoctorByIdAsync(request.Id);
                if (doctor == null)
                    return NotFound<GetSingleDoctorResponse>("doctor with this Id not found!");

                var doctorMapper = _mapper.Map<GetSingleDoctorResponse>(doctor);
                return Success(doctorMapper);

            }
            catch (Exception ex)
            {
                return ServerError<GetSingleDoctorResponse>(ex.Message);
            }
        }

        public async Task<PaginatedResult<GetDoctorsPaginatedResponse>> Handle(GetDoctorsPaginatedQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<Doctor, GetDoctorsPaginatedResponse>> expression =
                entity => new GetDoctorsPaginatedResponse(entity.DoctorId,
                                entity.FirstName, entity.LastName, entity.Email, entity.Phone, entity.IsActive);

                var filterResult = _doctorService.FilterDoctorPaginatedQuerable(request.Search);
                var paginatedList = await filterResult.Select(expression).ToPaginatedListAsync(request.PageNumber,
                    request.PageSize);

                return paginatedList;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetDoctorsPaginatedQuery");
                throw;
            }
        }
        #endregion
    }
}
