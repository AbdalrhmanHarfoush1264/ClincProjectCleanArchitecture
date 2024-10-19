using ClincProject.Core.Features.StatusHistories.Commands.Models;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.StatusHistories
{
    public partial class StatusHistoryProfile
    {
        public void AddStatusHistoryMapping()
        {
            CreateMap<AddStatusHistoryCommand, StatusHistory>();
        }
    }
}
