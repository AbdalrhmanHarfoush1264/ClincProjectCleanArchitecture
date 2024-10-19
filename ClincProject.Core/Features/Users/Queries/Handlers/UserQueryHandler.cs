using AutoMapper;
using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Users.Queries.Models;
using ClincProject.Core.Features.Users.Queries.Responses;
using ClincProject.Core.Wappers;
using ClincProject.Data.Entities.Identities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClincProject.Core.Features.Users.Queries.Handlers
{
    public class UserQueryHandler : CusResponseHandler,
        IRequestHandler<GetUserPaginatedListQuery, PaginatedResult<GetUserPaginatedListResponse>>,
        IRequestHandler<GetUserByIdQuery, CusResponse<GetUserByIdResponse>>
    {
        #region Fields
        private readonly ILogger<UserQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        #endregion

        #region Constructors
        public UserQueryHandler(ILogger<UserQueryHandler> logger, IMapper mapper, UserManager<User> userManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }
        #endregion

        #region Functions
        public async Task<PaginatedResult<GetUserPaginatedListResponse>> Handle(GetUserPaginatedListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = _userManager.Users.AsQueryable();
                if (!users.Any())
                {
                    return new PaginatedResult<GetUserPaginatedListResponse>(new());
                }

                var paginatedList = await _mapper.ProjectTo<GetUserPaginatedListResponse>(users)
                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);

                return paginatedList;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetUserPaginatedListQuery");
                throw;
            }
        }

        public async Task<CusResponse<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (user == null)
                    return NotFound<GetUserByIdResponse>($"User with Id: {request.Id} not found!");

                var usermapper = _mapper.Map<GetUserByIdResponse>(user);
                return Success(usermapper);
            }
            catch (Exception ex)
            {

                return ServerError<GetUserByIdResponse>(ex.Message);
            }
        }



        #endregion

    }
}
