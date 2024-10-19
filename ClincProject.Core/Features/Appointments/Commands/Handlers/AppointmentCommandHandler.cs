using AutoMapper;
using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Appointments.Commands.Models;
using ClincProject.Data.Entities;
using ClincProject.Service.Abstracts;
using MediatR;

namespace ClincProject.Core.Features.Appointments.Commands.Handlers
{
    public class AppointmentCommandHandler : CusResponseHandler,
        IRequestHandler<AddAppointmentCommand, CusResponse<string>>,
        IRequestHandler<EditAppointmentCommand, CusResponse<string>>,
        IRequestHandler<DeleteAppointmentCommand, CusResponse<string>>
    {

        #region Fileds
        private readonly IMapper _mapper;
        private readonly IAppointmentService _appointmentService;
        #endregion

        #region Constructors
        public AppointmentCommandHandler(IMapper mapper,
            IAppointmentService appointmentService)
        {
            _mapper = mapper;
            _appointmentService = appointmentService;
        }
        #endregion

        #region Functions
        public async Task<CusResponse<string>> Handle(AddAppointmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return BadRequest<string>("the request can't be blank.");

                var AppointmentMapper = _mapper.Map<Appointment>(request);
                AppointmentMapper.TimeCreated = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

                var result = await _appointmentService.AddAppointmentAsync(AppointmentMapper);

                if (!result)
                    return BadRequest<string>("Added Operation Failed.");

                return Success("Added Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<CusResponse<string>> Handle(EditAppointmentCommand request, CancellationToken cancellationToken)
        {

            try
            {
                if (request == null)
                    return BadRequest<string>("the request can't be blank");

                var isExist = await _appointmentService.IsAppointmentExistByIdAsync(request.Id);
                if (!isExist)
                    return NotFound<string>("Appointment with this id not found!");

                var AppointmentMapper = _mapper.Map<Appointment>(request);
                AppointmentMapper.TimeCreated = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

                var result = await _appointmentService.UpdateAppointmentAsync(AppointmentMapper);
                if (!result)
                    return BadRequest<string>("Updated Operation Failed.");

                return Success("Updated Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<CusResponse<string>> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return BadRequest<string>("the request can't be blank");

                var isExist = await _appointmentService.GetAppointmentByIdAsync(request.id);
                if (isExist == null)
                    return NotFound<string>("Appointment with this id not found!");


                var result = await _appointmentService.DeleteAppointmentAsync(isExist);
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
