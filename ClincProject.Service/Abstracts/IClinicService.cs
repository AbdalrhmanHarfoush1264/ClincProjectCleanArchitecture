using ClincProject.Data.Entities;

namespace ClincProject.Service.Abstracts
{
    public interface IClinicService
    {
        public Task<bool> CreateClinicAsync(Clinic clinic);
        public Task<bool> IsClinicExistByNameAsync(string clinicName);
        public Task<bool> IsClinicExistByIdAsync(int Id);
        public Task<Clinic> GetClinicByIdAsync(int Id);
        public Task<bool> EditClinicAsync(Clinic clinic);
        public Task<bool> DeleteClinicAsync(Clinic clinic);
        public Task<List<Clinic>> GetClinicListAsync();
    }
}
