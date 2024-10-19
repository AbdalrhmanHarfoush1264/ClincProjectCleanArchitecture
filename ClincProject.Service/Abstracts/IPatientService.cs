using ClincProject.Data.Entities;

namespace ClincProject.Service.Abstracts
{
    public interface IPatientService
    {
        public Task<List<Patient>> GetPatientListAsync();
        public Task<Patient> GetPatientByIdAsync(int Id);
        public IQueryable<Patient> FilterPatientPaginatedQuerable(string search);
        public Task<bool> CreatePatientAsync(Patient patient);
        public Task<bool> IsEmailExist(string email);
        public Task<bool> UpdatePatientAsync(Patient patient);
        public Task<bool> DeletePatientAsync(Patient patient);
        public Task<bool> IsPatientExistById(int Id);
    }
}
