using AutoMapper;
using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Doctors.Commands.Models;
using ClincProject.Data.Entities;
using ClincProject.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClincProject.Core.Features.Doctors.Commands.Handlers
{
    public class DoctorCommandHandler : CusResponseHandler,
        IRequestHandler<AddDoctorCommand, CusResponse<string>>,
        IRequestHandler<EditDoctorCommand, CusResponse<string>>,
        IRequestHandler<DeleteDoctorCommand, CusResponse<string>>
    {
        private readonly ILogger<DoctorCommandHandler> _logger;
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        #region Fileds

        #endregion

        #region Constructors
        public DoctorCommandHandler(ILogger<DoctorCommandHandler> logger,
            IDoctorService doctorService, IMapper mapper)
        {
            _logger = logger;
            _doctorService = doctorService;
            _mapper = mapper;
        }
        #endregion

        #region Handle Functions

        /*
         *  try
                    {

                    }catch(Exception ex)
                    {
         return ServerError<List<GetDoctorsListResponse>>(ex.Message);
                    }
         */

        public async Task<CusResponse<string>> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return BadRequest<string>("the request can't be blank");

                var doctorMapper = _mapper.Map<Doctor>(request);
                var result = await _doctorService.CreateDoctorAsync(doctorMapper);
                if (!result)
                    return BadRequest<string>("Added Operation Failed.");

                return Success("Added Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<CusResponse<string>> Handle(EditDoctorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return BadRequest<string>("the request can't be blank");

                var isExist = await _doctorService.IsDoctorExistById(request.Id);
                if (!isExist)
                    return NotFound<string>("doctor with this id not found!");

                var doctorMapper = _mapper.Map<Doctor>(request);
                var result = await _doctorService.UpdateDoctorAsync(doctorMapper);
                if (!result)
                    return BadRequest<string>("Updated Operation Failed.");

                return Success("Updated Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<CusResponse<string>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var doctor = await _doctorService.GetDoctorByIdAsync(request.Id);
                if (doctor == null)
                    return NotFound<string>("doctor with this id not found!");

                var result = await _doctorService.DeleteDoctorAsync(doctor);
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
