using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.Clinics.Queries.Models
{
    public class IsClinicExistByIdQuery : IRequest<CusResponse<string>>
    {
        public int Id { get; set; }

        public IsClinicExistByIdQuery(int id)
        {
            Id = id;
        }
    }
}
