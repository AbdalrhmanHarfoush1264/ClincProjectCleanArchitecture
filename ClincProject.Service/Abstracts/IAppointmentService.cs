using ClincProject.Data.Entities;

namespace ClincProject.Service.Abstracts
{
    public interface IAppointmentService
    {
        public Task<bool> AddAppointmentAsync(Appointment appointment);
        public Task<bool> UpdateAppointmentAsync(Appointment appointment);
        public Task<bool> DeleteAppointmentAsync(Appointment appointment);
        public Task<List<Appointment>> GetAppointmentListAsync();
        public Task<Appointment> GetAppointmentByIdAsync(int Id);
        public Task<bool> IsAppointmentExistByIdAsync(int Id);
        public IQueryable<Appointment> FilterAppointmentPaginatedQuerable(string? DoctorName = null,
            string? PatientName = null, string? statusName = null);
    }
}
