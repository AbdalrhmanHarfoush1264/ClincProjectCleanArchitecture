using AutoMapper;
using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Users.Commands.Models;
using ClincProject.Data.Entities.Identities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ClincProject.Core.Features.Users.Commands.Handlers
{
    public class UserCommandHandler : CusResponseHandler,
        IRequestHandler<AddUserCommand, CusResponse<string>>,
        IRequestHandler<EditUserCommand, CusResponse<string>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        #endregion

        #region Constructors
        public UserCommandHandler(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        #endregion

        #region Functions

        public async Task<CusResponse<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //write this logic if program is needed.
                var IsUserExistByEmail = await _userManager.FindByEmailAsync(request.Email);
                if (IsUserExistByEmail != null)
                    return BadRequest<string>("this email already before used.");

                //write this logic if program is needed.
                var IsUserExistByUserName = await _userManager.FindByNameAsync(request.UserName);
                if (IsUserExistByUserName != null) return BadRequest<string>("this username already before used.");

                var user = _mapper.Map<User>(request);
                var result = await _userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    string errorMessage = "Errors occurred while creating the user: ";
                    foreach (var error in result.Errors)
                    {
                        errorMessage += "\n" + $"{error.Description}";
                    }
                    return new CusResponse<string>(errorMessage);
                }

                //Here you should add role for people.
                //..................


                return Created<string>("User Added Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<CusResponse<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var oldUser = await _userManager.FindByIdAsync(request.Id.ToString());
                if (oldUser == null)
                    return NotFound<string>($"User with id: {request.Id} not found!");

                var IsUserExistByEmail = await _userManager.FindByEmailAsync(request.Email);
                if (IsUserExistByEmail != null && IsUserExistByEmail.Id != request.Id)
                    return BadRequest<string>("this email already before used.");

                var IsUserExistByUserName = await _userManager.FindByNameAsync(request.UserName);
                if (IsUserExistByUserName != null && IsUserExistByUserName.UserName != request.UserName)
                    return BadRequest<string>("this username already before used.");

                // استخدم الـ Mapper لتحديث الحقول فقط على الكائن القديم
                var userMapper = _mapper.Map(request, oldUser);

                //في الحالة ده هو ببنشالك كائن جديد من user مما يسبب بعض المشاكل 
                //var UserMapper = _mapper.Map<User>(request);

                var result = await _userManager.UpdateAsync(userMapper);
                if (!result.Succeeded)
                    return BadRequest<string>(result.Errors.FirstOrDefault()?.Description);

                return Success("Updated User is Successfully");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }
        #endregion




    }
}
