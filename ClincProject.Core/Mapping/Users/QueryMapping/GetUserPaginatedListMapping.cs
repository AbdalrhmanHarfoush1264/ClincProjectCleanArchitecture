using ClincProject.Core.Features.Users.Queries.Responses;
using ClincProject.Data.Entities.Identities;

namespace ClincProject.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void GetUserPaginatedListMapping()
        {
            CreateMap<User, GetUserPaginatedListResponse>();
        }
    }
}
