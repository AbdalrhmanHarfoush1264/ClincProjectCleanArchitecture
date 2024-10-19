using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.Doctors.Commands.Models
{
    public class DeleteDoctorCommand : IRequest<CusResponse<string>>
    {
        public int Id { get; set; }
        public DeleteDoctorCommand(int id)
        {
            Id = id;
        }
    }
}
