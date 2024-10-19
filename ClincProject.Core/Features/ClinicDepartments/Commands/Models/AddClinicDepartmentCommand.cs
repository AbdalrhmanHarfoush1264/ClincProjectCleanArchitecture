using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.ClinicDepartments.Commands.Models
{
    public class AddClinicDepartmentCommand : IRequest<CusResponse<string>>
    {
        public string DepartmentName { get; set; } = null!;
        public string? Description { get; set; }
        public int ClinicId { get; set; }
    }
}
