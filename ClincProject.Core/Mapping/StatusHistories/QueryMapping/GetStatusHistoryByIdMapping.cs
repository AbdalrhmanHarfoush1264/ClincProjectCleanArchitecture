using ClincProject.Core.Features.StatusHistories.Querires.Responses;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.StatusHistories
{
    public partial class StatusHistoryProfile
    {
        public void GetStatusHistoryByIdMapping()
        {
            CreateMap<StatusHistory, GetSingleStatusHistoryResponse>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StatusHistoryId))
              .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.AppointmentStatus.StatusName));
        }
    }
}
