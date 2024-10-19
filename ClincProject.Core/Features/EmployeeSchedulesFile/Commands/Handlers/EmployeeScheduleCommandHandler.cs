using AutoMapper;
using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.EmployeeSchedulesFile.Commands.Models;
using ClincProject.Data.Entities;
using ClincProject.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClincProject.Core.Features.EmployeeSchedulesFile.Commands.Handlers
{
    public class EmployeeScheduleCommandHandler : CusResponseHandler,
        IRequestHandler<AddEmployeeScheduleCommand, CusResponse<string>>,
        IRequestHandler<EditEmployeeScheduleCommand, CusResponse<string>>,
        IRequestHandler<DeleteEmployeeScheduleCommand, CusResponse<string>>
    {
        #region Fileds
        private readonly IMapper _mapper;
        private readonly IEmployeeScheduleService _employeeScheduleService;
        private readonly ILogger<EmployeeScheduleCommandHandler> _logger;
        #endregion

        #region Constructors
        public EmployeeScheduleCommandHandler(ILogger<EmployeeScheduleCommandHandler> logger,
            IEmployeeScheduleService employeeScheduleService, IMapper mapper)
        {
            _logger = logger;
            _employeeScheduleService = employeeScheduleService;
            _mapper = mapper;
        }
        #endregion

        #region Functions

        /*
        *  try
                   {

                   }catch(Exception ex)
                   {
        return ServerError<List<GetDoctorsListResponse>>(ex.Message);
                   }
        */


        public async Task<CusResponse<string>> Handle(AddEmployeeScheduleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return BadRequest<string>("the request can't be blank.");

                var employeeScheduleMapper = _mapper.Map<EmployeeSchedules>(request);

                var result = await _employeeScheduleService.AddEmployeeScheduleAsync(employeeScheduleMapper);
                if (!result)
                    return BadRequest<string>("Added Operation Failed.");

                return Success("Added Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<CusResponse<string>> Handle(EditEmployeeScheduleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return BadRequest<string>("the request can't be blank");

                var isExist = await _employeeScheduleService.IsEmployeeScheduleExist(request.Id);
                if (!isExist)
                    return NotFound<string>("EmployeeSchedule with this id not found!");

                var employeeScheduleMapper = _mapper.Map<EmployeeSchedules>(request);
                var result = await _employeeScheduleService.EditEmployeeScheduleAsync(employeeScheduleMapper);
                if (!result)
                    return BadRequest<string>("Updated Operation Failed.");

                return Success("Updated Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<CusResponse<string>> Handle(DeleteEmployeeScheduleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employeeSchedule = await _employeeScheduleService.GetEmployeeScheduleByIdAsync(request.Id);
                if (employeeSchedule == null)
                    return NotFound<string>("employeeSchedule with this id not found!");

                var result = await _employeeScheduleService.DeleteEmployeeScheduleAsync(employeeSchedule);
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
