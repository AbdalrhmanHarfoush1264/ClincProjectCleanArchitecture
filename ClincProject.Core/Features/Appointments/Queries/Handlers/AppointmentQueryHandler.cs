using AutoMapper;
using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Appointments.Queries.Models;
using ClincProject.Core.Features.Appointments.Queries.Responses;
using ClincProject.Core.Wappers;
using ClincProject.Data.Entities;
using ClincProject.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace ClincProject.Core.Features.Appointments.Queries.Handlers
{
    public class AppointmentQueryHandler : CusResponseHandler,
        IRequestHandler<GetAppointmentListQuery, CusResponse<List<GetAppointmentListResponse>>>,
        IRequestHandler<GetAppointmentByIdQuery, CusResponse<GetSingleAppointmentResponse>>,
        IRequestHandler<GetAppointmentPaginatedQuery, PaginatedResult<GetAppointmentPaginatedResponse>>
    {
        #region Fileds
        private readonly IMapper _mapper;
        private readonly ILogger<AppointmentQueryHandler> _logger;
        private readonly IAppointmentService _appointmentService;
        #endregion

        #region Constructors

        public AppointmentQueryHandler(IMapper mapper, ILogger<AppointmentQueryHandler> logger, IAppointmentService appointmentService)
        {
            _mapper = mapper;
            _logger = logger;
            _appointmentService = appointmentService;
        }
        #endregion
        public async Task<CusResponse<List<GetAppointmentListResponse>>> Handle(GetAppointmentListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _appointmentService.GetAppointmentListAsync();
                var listMapper = _mapper.Map<List<GetAppointmentListResponse>>(result);
                return Success(listMapper);
            }
            catch (Exception ex)
            {
                return ServerError<List<GetAppointmentListResponse>>(ex.Message);
            }
        }

        public async Task<CusResponse<GetSingleAppointmentResponse>> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var appointment = await _appointmentService.GetAppointmentByIdAsync(request.Id);
                if (appointment == null)
                    return NotFound<GetSingleAppointmentResponse>("Appointment with this id not found.");

                var resultMapper = _mapper.Map<GetSingleAppointmentResponse>(appointment);
                return Success(resultMapper);
            }
            catch (Exception ex)
            {
                return ServerError<GetSingleAppointmentResponse>(ex.Message);
            }
        }

        public async Task<PaginatedResult<GetAppointmentPaginatedResponse>> Handle(GetAppointmentPaginatedQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<Appointment, GetAppointmentPaginatedResponse>> expression =
                    entity => new GetAppointmentPaginatedResponse(entity.AppointmentId, entity.TimeCreated, entity.StartTime,
                    entity.EndTime, entity.PatientCase.Patient.FirstName + " " + entity.PatientCase.Patient.LastName,
                    entity.Doctor.FirstName + " " + entity.Doctor.LastName, entity.PatientCase.TotalCost, entity.PatientCase.AmountPaid, entity.AppointmentStatus.StatusName);

                var filterResult = _appointmentService.FilterAppointmentPaginatedQuerable(request.DoctorName,
                    request.PatientName, request.StatusName);

                var paginatedList = await filterResult.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
                return paginatedList;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error: in GetAppointmentPaginatedQuery");
                throw;
            }
        }
    }
}
