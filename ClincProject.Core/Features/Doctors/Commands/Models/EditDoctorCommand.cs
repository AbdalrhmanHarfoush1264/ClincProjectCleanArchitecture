using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.Doctors.Commands.Models
{
    public class EditDoctorCommand : IRequest<CusResponse<string>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
    }
}
