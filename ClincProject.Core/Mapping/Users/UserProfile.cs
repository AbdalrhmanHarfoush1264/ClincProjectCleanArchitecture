using AutoMapper;

namespace ClincProject.Core.Mapping.Users
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            AddUserMapping();
        }
    }
}
