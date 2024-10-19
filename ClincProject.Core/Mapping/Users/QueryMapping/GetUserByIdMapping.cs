using ClincProject.Core.Features.Users.Queries.Responses;
using ClincProject.Data.Entities.Identities;

namespace ClincProject.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void GetUserByIdMapping()
        {
            CreateMap<User, GetUserByIdResponse>();
        }
    }
}
