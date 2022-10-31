using CinemaManagement.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CinemaManagement.Application.Users.Commands.AssignRole
{
    public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommand, bool>
    {
        private readonly RoleManager<UserRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public AssignRoleCommandHandler(UserManager<User> userManager, RoleManager<UserRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<bool> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            var role = await _roleManager.FindByNameAsync(request.RoleName);
            if (role == null)
            {
                var roleAdded = await _roleManager.CreateAsync(new()
                {
                    Name = request.RoleName
                });
            }
            var addrole = await _userManager.AddToRoleAsync(user, request.RoleName);
            return addrole.Succeeded;
        }
    }
}
