using ClincProject.Data.Entities.Identities;
using ClincProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ClincProject.Infrastructure.InfrastructureBases
{
    public class RefreshTokenRepository : GenericRepository<UserRefreshToken>, IRefreshTokenRepository
    {
        #region Fields
        private readonly DbSet<UserRefreshToken> _userRefreshTokens;
        #endregion

        #region Constructors
        public RefreshTokenRepository(AppDbContext context) : base(context)
        {
            _userRefreshTokens = context.Set<UserRefreshToken>();
        }
        #endregion

    }
}
