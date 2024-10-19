using ClincProject.Data.Entities;
using ClincProject.Infrastructure.InfrastructureBases;
using ClincProject.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClincProject.Service.Implementations
{
    public class PatientCaseService : IPatientCaseService
    {

        #region Fileds
        private readonly IGenericRepository<PatientCase> _patientCaseRepository;
        private readonly IGenericRepository<Appointment> _appointmentRepository;
        private readonly ILogger<PatientCaseService> _logger;

        #endregion


        #region Constructors
        public PatientCaseService(ILogger<PatientCaseService> logger,
            IGenericRepository<PatientCase> patientCaseRepository, IGenericRepository<Appointment> appointmentRepository)
        {
            _logger = logger;
            _patientCaseRepository = patientCaseRepository;
            _appointmentRepository = appointmentRepository;
        }
        #endregion


        #region Functions
        public async Task<bool> AddPatientCaseAsync(PatientCase patientCase)
        {
            try
            {
                var result = await _patientCaseRepository.AddAsync(patientCase);
                if (result == null)
                    return false;

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in AddPatientCaseAsync");
                throw;
            }
        }

        public async Task<bool> UpdatePatientCaseAsync(PatientCase patientCase)
        {
            try
            {
                var result = await _patientCaseRepository.UpdateAsync(patientCase);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in UpdatePatientCaseAsync");
                throw;
            }
        }

        public async Task<bool> DeletePatientCaseAsync(PatientCase patientCase)
        {
            try
            {
                var AnyPointmentUseThisId = await _appointmentRepository.GetTableNoTracking().Where(x => x.PatientCaseId == patientCase.PatientCaseId).AnyAsync();
                if (AnyPointmentUseThisId)
                    return false;

                var result = await _patientCaseRepository.DeleteAsync(patientCase);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in DeletePatientCaseAsync");
                throw;
            }
        }

        public async Task<List<PatientCase>> GetPatientCaseListAsync()
        {
            try
            {
                var result = await _patientCaseRepository.GetTableNoTracking()
                    .Include(x => x.Patient).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetPatientCaseListAsync");
                throw;
            }
        }

        public async Task<PatientCase> GetPatientCaseByIdAsync(int Id)
        {
            try
            {
                var result = await _patientCaseRepository.GetTableNoTracking()
                    .Where(x => x.PatientCaseId == Id)
                    .Include(x => x.Patient).FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetPatientCaseByIdAsync");
                throw;
            }
        }

        public async Task<bool> IsPatientCaseExistById(int Id)
        {
            try
            {
                var result = await _patientCaseRepository.GetTableNoTracking().Where(x => x.PatientCaseId == Id).FirstOrDefaultAsync();
                if (result == null)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in IsPatientCaseExistById");
                throw;
            }
        }

        public IQueryable<PatientCase> FilterPatientCasePaginatedQuerable(string? search = null)
        {

            try
            {
                var query = _patientCaseRepository.GetTableNoTracking().Include(x => x.Patient).AsQueryable();
                if (search != null)
                {
                    query = query.Where(x => x.Patient.FirstName == search || x.Patient.LastName == search);
                }
                return query;

            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in FilterPatientCasePaginatedQuerable");
                throw;
            }

        }
        #endregion


    }

}
