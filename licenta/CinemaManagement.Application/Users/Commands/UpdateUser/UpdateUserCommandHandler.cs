using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CinemaManagement.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        public UpdateUserCommandHandler(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository=userRepository;
            _userManager=userManager;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.ProfileImageSrc = request.ProfileImageSrc;
            user.PhoneNumber = request.PhoneNumber;
            await _userManager.UpdateAsync(user);
            await _userRepository.SaveAsync();
            return user;
        }
    }
}
