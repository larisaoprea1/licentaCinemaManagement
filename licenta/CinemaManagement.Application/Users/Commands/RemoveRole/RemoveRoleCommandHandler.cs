using CinemaManagement.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CinemaManagement.Application.Users.Commands.RemoveRole
{
    public class RemoveRoleCommandHandler : IRequestHandler<RemoveRoleCommand, bool>
    {
        private readonly RoleManager<UserRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public RemoveRoleCommandHandler(UserManager<User> userManager, RoleManager<UserRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<bool> Handle(RemoveRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            var removeRole = await _userManager.RemoveFromRoleAsync(user, request.RoleName);

            return removeRole.Succeeded;
        }
    }
}
