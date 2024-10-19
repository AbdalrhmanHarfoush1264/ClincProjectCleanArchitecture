using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.Doctors.Commands.Models
{
    public class AddDoctorCommand : IRequest<CusResponse<string>>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }



    }
}
