using ClincProject.Core.Features.StatusHistories.Commands.Models;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.StatusHistories
{
    public partial class StatusHistoryProfile
    {
        public void EditStatusHistoryMapping()
        {
            CreateMap<EditStatusHistoryCommand, StatusHistory>().ForMember(dest => dest.StatusHistoryId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
