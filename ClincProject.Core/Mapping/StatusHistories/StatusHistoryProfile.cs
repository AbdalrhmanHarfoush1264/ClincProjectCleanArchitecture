using AutoMapper;

namespace ClincProject.Core.Mapping.StatusHistories
{
    public partial class StatusHistoryProfile : Profile
    {
        public StatusHistoryProfile()
        {
            AddStatusHistoryMapping();
            EditStatusHistoryMapping();
            GetStatusHistoryListMapping();
            GetStatusHistoryByIdMapping();
        }
    }
}
