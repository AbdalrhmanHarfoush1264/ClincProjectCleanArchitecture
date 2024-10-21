using ClincProject.Data.Entities.Identities;
using ClincProject.Data.Helpers;
using ClincProject.Infrastructure.Data;
using ClincProject.Service.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClincProject.Service.Implementations
{
    public class AuthorizationService : IAuthorizationService
    {
        #region Fileds
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AuthorizationService> _logger;
        private readonly AppDbContext _dbContext;
        #endregion

        #region Constructors
        public AuthorizationService(RoleManager<Role> roleManager, UserManager<User> userManager,
           ILogger<AuthorizationService> logger, AppDbContext dbContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
            _dbContext = dbContext;
        }
        #endregion

        #region Functions

        public async Task<bool> AddRoleAsync(string roleName)
        {
            try
            {
                var role = new Role();
                role.Name = roleName.ToLower();

                var result = await _roleManager.CreateAsync(role);

                if (!result.Succeeded)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in AddRoleAsync");
                throw;
            }
        }
        public async Task<bool> EditRoleById(int Id, string roleName)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(Id.ToString());
                if (role == null)
                    return false;

                role.Name = roleName;
                var result = await _roleManager.UpdateAsync(role);
                if (!result.Succeeded)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in EditRoleById");
                throw;
            }
        }
        public async Task<bool> DeleteRoleById(Role role)
        {
            try
            {
                var users = await _userManager.GetUsersInRoleAsync(role.Name!);
                if (users != null && users.Count() > 0)
                    return false;


                var result = await _roleManager.DeleteAsync(role);
                if (!result.Succeeded)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in DeleteRoleById");
                throw;
            }
        }
        public async Task<bool> IsRoleNameExist(string rolename)
        {
            try
            {
                var result = await _roleManager.RoleExistsAsync(rolename.ToLower());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in IsRoleNameExist");
                throw;
            }
        }
        public async Task<Role> GetRoleByID(int Id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(Id.ToString());
                return role;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetRoleByID");
                throw;
            }
        }
        public async Task<List<Role>> GetRoleListAsync()
        {
            try
            {
                var roles = await _roleManager.Roles.ToListAsync();
                return roles;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetRoleListAsync");
                throw;
            }
        }
        public async Task<ManagerUserRolesResponse> GetManagerUsersRolesData(User user)
        {
            try
            {
                var userRoles = new List<UserRoles>();
                var response = new ManagerUserRolesResponse();

                var rolesForUser = await _userManager.GetRolesAsync(user);
                var rolesInSystem = await _roleManager.Roles.ToListAsync();


                foreach (var role in rolesInSystem)
                {
                    var userRole = new UserRoles();
                    userRole.Id = role.Id;
                    userRole.Name = role.Name!;
                    userRole.HasRole = rolesForUser.Contains(role.Name!);
                    userRoles.Add(userRole);
                }

                response.UserId = user.Id;
                response.UserRoles = userRoles;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetManagerUsersRolesData");
                throw;
            }
        }
        public async Task<string> UpdateUserRoles(EditUserRolesRequest request)
        {

            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId.ToString());
                if (user == null)
                {
                    return "UserNotFound";
                }

                var rolesForUser = await _userManager.GetRolesAsync(user);
                if (rolesForUser == null)
                {
                    var IsDeleted = await _userManager.RemoveFromRolesAsync(user, rolesForUser);
                    if (!IsDeleted.Succeeded)
                        return "FailedDeleted";

                }

                var newRoles = request.UserRoles.Where(x => x.HasRole == true).Select(x => x.Name);
                var IsAdded = await _userManager.AddToRolesAsync(user, newRoles);

                if (!IsAdded.Succeeded)
                    return "FailedAdded";

                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in UpdateUserRoles");
                await trans.RollbackAsync();
                return "FaildAdded";
                throw;
            }
        }
        #endregion
    }
}
