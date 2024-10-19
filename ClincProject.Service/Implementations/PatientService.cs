using ClincProject.Data.Entities;
using ClincProject.Infrastructure.InfrastructureBases;
using ClincProject.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClincProject.Service.Implementations
{
    public class PatientService : IPatientService
    {


        #region Fileds
        private readonly IGenericRepository<Patient> _patientRepository;
        private readonly IGenericRepository<PatientCase> _patientCaseRepository;
        private readonly ILogger<PatientService> _logger;
        #endregion


        #region Constructors
        public PatientService(IGenericRepository<Patient> patientRepository
            , IGenericRepository<PatientCase> patientCaseRepository, ILogger<PatientService> logger)
        {
            _patientRepository = patientRepository;
            _patientCaseRepository = patientCaseRepository;
            _logger = logger;
        }
        #endregion


        #region Handle Functions
        public async Task<List<Patient>> GetPatientListAsync()
        {
            return await _patientRepository.GetTableNoTracking().ToListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int Id)
        {
            var patient = await _patientRepository.GetTableNoTracking().Where(x => x.PatientId.Equals(Id)).FirstOrDefaultAsync();
            return patient;
        }

        public IQueryable<Patient> FilterPatientPaginatedQuerable(string search)
        {
            var querable = _patientRepository.GetTableNoTracking().AsQueryable();
            if (search != null)
            {
                querable = querable.Where(x => x.FirstName.Contains(search) || x.LastName.Contains(search) || x.Email.Contains(search));
            }

            return querable;
        }


        public async Task<bool> CreatePatientAsync(Patient patient)
        {
            var result = await _patientRepository.AddAsync(patient);
            if (result == null)
                return false;

            return true;
        }

        public async Task<bool> UpdatePatientAsync(Patient patient)
        {
            await _patientRepository.UpdateAsync(patient);
            return true;
        }

        public async Task<bool> DeletePatientAsync(Patient patient)
        {
            var isPatientCaseUsePatientID = await _patientCaseRepository.GetTableNoTracking().Where(x => x.PatientId == patient.PatientId).AnyAsync();
            if (isPatientCaseUsePatientID)
                return false;

            await _patientRepository.DeleteAsync(patient);
            return true;
        }

        public async Task<bool> IsEmailExist(string email)
        {
            var result = await _patientRepository.GetTableNoTracking().Where(x => x.Email.Equals(email)).FirstOrDefaultAsync();
            if (result == null)
                return false;

            return true;
        }

        public async Task<bool> IsPatientExistById(int Id)
        {
            try
            {
                var result = await _patientRepository.GetTableNoTracking().Where(x => x.PatientId == Id).FirstOrDefaultAsync();
                if (result == null)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in IsPatientExistById");
                throw;
            }
        }
        #endregion



    }
}
