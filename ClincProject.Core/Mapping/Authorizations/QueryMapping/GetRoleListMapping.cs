using ClincProject.Core.Features.Authorizations.Queries.Responses;
using ClincProject.Data.Entities.Identities;

namespace ClincProject.Core.Mapping.Authorizations
{
    public partial class AuthorizationProfile
    {
        public void GetRoleListMapping()
        {
            CreateMap<Role, GetRoleListResponse>()
                .ForMember(dest => dest.roleName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
