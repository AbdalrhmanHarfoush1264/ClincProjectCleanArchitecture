using AutoMapper;
using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Schedules.Queries.Models;
using ClincProject.Core.Features.Schedules.Queries.Responses;
using ClincProject.Core.Wappers;
using ClincProject.Data.Entities;
using ClincProject.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace ClincProject.Core.Features.Schedules.Queries.Handlers
{
    public class ScheduleQueryHandler : CusResponseHandler
        , IRequestHandler<GetScheduleListQuery, CusResponse<List<GetScheduleListResponse>>>
        , IRequestHandler<GetScheduleByIdQuery, CusResponse<GetScheduleByIdResponse>>
        , IRequestHandler<GetSchedulePaginatedQuery, PaginatedResult<GetSchedulePaginatedResponse>>
    {

        #region Fileds
        private readonly ILogger<ScheduleQueryHandler> _logger;
        private readonly IScheduleService _scheduleService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public ScheduleQueryHandler(ILogger<ScheduleQueryHandler> logger,
            IScheduleService scheduleService, IMapper mapper)
        {
            _logger = logger;
            _scheduleService = scheduleService;
            _mapper = mapper;
        }


        #endregion

        #region Functions
        public async Task<CusResponse<List<GetScheduleListResponse>>> Handle(GetScheduleListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _scheduleService.GetScheduleListAsync();
                var listMapper = _mapper.Map<List<GetScheduleListResponse>>(result);
                return Success(listMapper);
            }
            catch (Exception ex)
            {
                return ServerError<List<GetScheduleListResponse>>(ex.Message);
            }
        }

        public async Task<CusResponse<GetScheduleByIdResponse>> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var Schedule = await _scheduleService.GetScheduleByIdAsync(request.Id);
                if (Schedule == null)
                    return NotFound<GetScheduleByIdResponse>("Schedule with this id not found.");

                var resultMapper = _mapper.Map<GetScheduleByIdResponse>(Schedule);
                return Success(resultMapper);
            }
            catch (Exception ex)
            {
                return ServerError<GetScheduleByIdResponse>(ex.Message);
            }
        }

        public async Task<PaginatedResult<GetSchedulePaginatedResponse>> Handle(GetSchedulePaginatedQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<Schedule, GetSchedulePaginatedResponse>> expression =
                    entity => new GetSchedulePaginatedResponse(entity.ScheduleId,
                    entity.Date, entity.TimeStart, entity.TimeEnd, entity.EmployeeSchedules.Doctor.FirstName + " " +
                    entity.EmployeeSchedules.Doctor.LastName, entity.EmployeeSchedules.ClinicDepartment.DepartmentName);


                DateOnly? filterDate = request.Date.HasValue ? new DateOnly(request.Date.Value.Year,
                    request.Date.Value.Month, request.Date.Value.Day) : null;

                var filterResult = _scheduleService.FilterSchedulePaginatedQuerable(filterDate);
                var paginatedList = await filterResult.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

                return paginatedList;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error: in GetSchedulePaginatedQuery");
                throw;
            }
        }
        #endregion

    }
}
