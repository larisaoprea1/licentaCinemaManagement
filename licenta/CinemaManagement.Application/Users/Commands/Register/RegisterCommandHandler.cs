using CinemaManagement.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CinemaManagement.Application.Users.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, User>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<UserRole> _roleManager;
        public RegisterCommandHandler(UserManager<User> userManager, RoleManager<UserRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<User> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _userManager.FindByNameAsync(request.User.UserName);

            var usertToCreate = new User
            {
                UserName = request.User.UserName,
                FirstName = request.User.FirstName,
                LastName = request.User.LastName,
                Email = request.User.Email,
                PhoneNumber = request.User.PhoneNumber,
                ProfileImageSrc = request.User.ProfileImageSrc,

            };
            var result = await _userManager.CreateAsync(usertToCreate, request.Password);
            var addRoleToUser = await _userManager.AddToRoleAsync(usertToCreate, "User");
            return usertToCreate;

        }
    }
}
