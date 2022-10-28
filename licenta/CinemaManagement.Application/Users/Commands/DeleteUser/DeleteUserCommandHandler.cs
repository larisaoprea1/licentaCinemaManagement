using CinemaManagement.Application.Interfaces;
using MediatR;

namespace CinemaManagement.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetUserAsync(request.Id);
            _userRepository.DeleteUser(entity);
            await _userRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
