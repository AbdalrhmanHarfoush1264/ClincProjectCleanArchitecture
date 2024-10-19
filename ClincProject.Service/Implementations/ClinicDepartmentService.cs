using ClincProject.Data.Entities;
using ClincProject.Infrastructure.InfrastructureBases;
using ClincProject.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClincProject.Service.Implementations
{
    public class ClinicDepartmentService : IClinicDepartmentService
    {
        #region Fileds
        private readonly IGenericRepository<ClinicDepartment> _clinicDepartmentRepository;
        private readonly ILogger<ClinicDepartmentService> _logger;
        private readonly IGenericRepository<EmployeeSchedules> _employeeSchedulesRepository;
        #endregion

        #region Constructor(s)
        public ClinicDepartmentService(IGenericRepository<ClinicDepartment> clinicDepartmentRepository,
            ILogger<ClinicDepartmentService> logger, IGenericRepository<EmployeeSchedules> employeeSchedulesRepository)
        {
            _clinicDepartmentRepository = clinicDepartmentRepository;
            _logger = logger;
            _employeeSchedulesRepository = employeeSchedulesRepository;
        }

        #endregion

        #region Functions

        public async Task<bool> AddClinicDepartmentAsync(ClinicDepartment clinicDepartment)
        {
            try
            {
                var result = await _clinicDepartmentRepository.AddAsync(clinicDepartment);
                if (result == null)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in AddClinicDepartmentAsync");
                throw;
            }
        }


        public async Task<bool> EditClinicDepartmentAsync(ClinicDepartment clinicDepartment)
        {
            try
            {
                var IsUpdated = await _clinicDepartmentRepository.UpdateAsync(clinicDepartment);
                if (!IsUpdated)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in EditClinicDepartmentAsync");
                throw;
            }
        }

        public async Task<bool> DeleteClinicDepartmentAsync(ClinicDepartment clinicDepartment)
        {
            try
            {
                var IsemployeeScheduleUseDoctorId = await _employeeSchedulesRepository.GetTableNoTracking()
                   .Where(x => x.clinicDepartmentId == clinicDepartment.DepartmentId).FirstOrDefaultAsync();

                if (IsemployeeScheduleUseDoctorId != null)
                    return false;

                var IsDeleted = await _clinicDepartmentRepository.DeleteAsync(clinicDepartment);
                if (!IsDeleted)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in DeleteClinicDepartment");
                throw;
            }
        }


        public async Task<bool> IsDepartmentExistById(int Id)
        {
            try
            {
                var result = await _clinicDepartmentRepository.GetTableNoTracking()
                       .Where(x => x.DepartmentId == Id).FirstOrDefaultAsync();

                if (result == null)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in IsDepartmentExistById");
                throw;
            }
        }
        public async Task<ClinicDepartment> GetClinicDepartmentByIdAsync(int Id)
        {
            try
            {
                var result = await _clinicDepartmentRepository.GetTableNoTracking()
                    .Where(x => x.DepartmentId.Equals(Id)).Include(x => x.Clinic).FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetClinicDepartmentById");
                throw;
            }
        }

        public async Task<ClinicDepartment> GetClinicDepartmentByNameAsync(string departmentName)
        {
            try
            {
                var result = await _clinicDepartmentRepository.GetTableNoTracking()
                    .Where(x => x.DepartmentName.ToLower() == departmentName.ToLower()).Include(x => x.Clinic).FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetClinicDepartmentById");
                throw;
            }
        }


        public async Task<List<ClinicDepartment>> GetClinicDepartmentListAsync()
        {
            try
            {
                var clinicDepartmentList = await _clinicDepartmentRepository.GetTableNoTracking().Include(x => x.Clinic).ToListAsync();
                return clinicDepartmentList;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetClinicDepartmentListAsync");
                throw;
            }
        }

        public IQueryable<ClinicDepartment> FilterClinicDepartmentPaginatedQuerable(string search)
        {
            try
            {
                var query = _clinicDepartmentRepository.GetTableNoTracking().AsQueryable();
                if (search != null)
                {
                    //Add More deatials about search if needed.
                    query = query.Where(x => x.DepartmentName.Contains(search));
                }
                return query;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in FilterClinicDepartmentPaginatedQuerable");
                throw;
            }

        }

        #endregion

    }
}
