using ClincProject.Data.Entities;

namespace ClincProject.Service.Abstracts
{
    public interface IAppointmentStatusService
    {
        public Task<List<AppointmentStatus>> GetAppointmentStatusListAsync();
        public Task<bool> IsAppointmentStatusByIdAsync(int Id);
        public Task<bool> IsAppointmentStatusByNameAsync(string statusName);
        public Task<AppointmentStatus> GetAppointmentStatusByIdAsync(int Id);
        public Task<bool> DeleteAppointmentStatusAsync(AppointmentStatus appointmentStatus);
        public Task<bool> EditAppointmentStatusAsync(AppointmentStatus appointmentStatus);
        public Task<bool> CreateAppointmentStatusAsync(AppointmentStatus appointmentStatus);
    }
}
