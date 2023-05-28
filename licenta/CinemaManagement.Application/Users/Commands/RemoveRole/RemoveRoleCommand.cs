using MediatR;

namespace CinemaManagement.Application.Users.Commands.RemoveRole
{
    public class RemoveRoleCommand : IRequest<bool>
    {
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
