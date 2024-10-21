using AutoMapper;

namespace ClincProject.Core.Mapping.Authorizations
{
    public partial class AuthorizationProfile : Profile
    {
        public AuthorizationProfile()
        {
            GetRoleByIdMapping();
            GetRoleListMapping();
        }
    }
}
