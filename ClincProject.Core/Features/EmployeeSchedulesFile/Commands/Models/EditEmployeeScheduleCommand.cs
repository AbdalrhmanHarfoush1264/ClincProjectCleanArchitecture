using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.EmployeeSchedulesFile.Commands.Models
{
    public class EditEmployeeScheduleCommand : IRequest<CusResponse<string>>
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int DepartmentId { get; set; }

        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public bool IsActive { get; set; }

    }
}
