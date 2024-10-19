using ClincProject.Data.Entities;

namespace ClincProject.Service.Abstracts
{
    public interface IClinicDepartmentService
    {
        public Task<bool> AddClinicDepartmentAsync(ClinicDepartment clinicDepartment);
        public Task<bool> EditClinicDepartmentAsync(ClinicDepartment clinicDepartment);
        public Task<bool> DeleteClinicDepartmentAsync(ClinicDepartment clinicDepartment);
        public Task<bool> IsDepartmentExistById(int Id);
        public Task<ClinicDepartment> GetClinicDepartmentByIdAsync(int Id);
        public Task<ClinicDepartment> GetClinicDepartmentByNameAsync(string departmentName);
        public Task<List<ClinicDepartment>> GetClinicDepartmentListAsync();
        public IQueryable<ClinicDepartment> FilterClinicDepartmentPaginatedQuerable(string search);
    }
}
