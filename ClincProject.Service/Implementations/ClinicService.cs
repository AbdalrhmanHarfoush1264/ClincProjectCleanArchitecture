using ClincProject.Data.Entities;
using ClincProject.Infrastructure.InfrastructureBases;
using ClincProject.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClincProject.Service.Implementations
{
    public class ClinicService : IClinicService
    {

        #region Fileds
        private readonly IGenericRepository<Clinic> _clinicRepository;
        private readonly ILogger<ClinicService> _logger;
        private readonly IGenericRepository<ClinicDepartment> _clinicDepartmentRepository;

        #endregion

        #region Constructors

        public ClinicService(IGenericRepository<Clinic> clinicRepository,
            ILogger<ClinicService> logger, IGenericRepository<ClinicDepartment> clinicDepartmentRepository)
        {
            _clinicRepository = clinicRepository;
            _clinicDepartmentRepository = clinicDepartmentRepository;
            _logger = logger;
        }
        #endregion

        #region Handle Functions

        public async Task<bool> CreateClinicAsync(Clinic clinic)
        {
            try
            {
                var IsAdded = await _clinicRepository.AddAsync(clinic);
                if (IsAdded == null)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in CreateClinicAsync");
                throw;
            }

        }


        public async Task<bool> EditClinicAsync(Clinic clinic)
        {
            try
            {
                var isUpdated = await _clinicRepository.UpdateAsync(clinic);
                return isUpdated;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in EditClinicAsync");
                throw;
            }
        }

        public async Task<bool> DeleteClinicAsync(Clinic clinic)
        {
            try
            {
                //Is ClinicDepartment Used this Clinic.
                var isClinicDepartmentUsedThisClinic = await _clinicDepartmentRepository.GetTableNoTracking()
                    .Where(x => x.ClinicId == clinic.ClinicId).FirstOrDefaultAsync();

                if (isClinicDepartmentUsedThisClinic != null)
                    return false;

                var IsDeleted = await _clinicRepository.DeleteAsync(clinic);
                return IsDeleted;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in DeleteClinicAsync");
                throw;
            }
        }

        public async Task<Clinic> GetClinicByIdAsync(int Id)
        {
            try
            {
                var result = await _clinicRepository.GetTableNoTracking()
                    .Where(x => x.ClinicId == Id).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in FindClinicByIdAsync");
                throw;
            }
        }
        public async Task<bool> IsClinicExistByIdAsync(int Id)
        {
            try
            {
                var IsExist = await _clinicRepository.GetTableNoTracking().
                   Where(x => x.ClinicId == Id)
                   .AnyAsync();

                return IsExist;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in IsClinicExistByIdAsync");
                throw;
            }

        }
        public async Task<bool> IsClinicExistByNameAsync(string clinicName)
        {
            try
            {
                var IsExist = await _clinicRepository.GetTableNoTracking().
                   Where(x => x.Name.ToLower() == clinicName.ToLower())
                   .AnyAsync();

                return IsExist;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in IsClinicExistByNameAsync");
                throw;
            }

        }


        public async Task<List<Clinic>> GetClinicListAsync()
        {
            try
            {
                var clinicList = await _clinicRepository.GetTableNoTracking().ToListAsync();
                return clinicList;
            }
            catch (Exception ex)
            {

                _logger.LogDebug(ex, "Error in GetClinicListAsync");
                throw;
            }
        }
        #endregion
    }
}
