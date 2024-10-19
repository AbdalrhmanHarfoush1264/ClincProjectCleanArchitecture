using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.Users.Commands.Models
{
    public class EditUserCommand : IRequest<CusResponse<string>>
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
    }
}
