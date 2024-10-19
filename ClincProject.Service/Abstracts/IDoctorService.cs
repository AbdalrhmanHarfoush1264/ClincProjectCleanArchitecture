using ClincProject.Data.Entities;

namespace ClincProject.Service.Abstracts
{
    public interface IDoctorService
    {
        public Task<List<Doctor>> GetDoctorListAsync();
        public Task<Doctor> GetDoctorByIdAsync(int Id);
        public Task<bool> CreateDoctorAsync(Doctor doctor);
        public Task<bool> UpdateDoctorAsync(Doctor doctor);
        public Task<bool> DeleteDoctorAsync(Doctor doctor);
        public Task<bool> IsEmailExist(string email);
        public Task<bool> IsDoctorExistById(int Id);
        public IQueryable<Doctor> FilterDoctorPaginatedQuerable(string search);


    }
}
