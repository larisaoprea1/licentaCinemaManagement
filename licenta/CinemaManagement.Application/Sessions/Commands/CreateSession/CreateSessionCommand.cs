using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Sessions.Commands.CreateSession
{
    public class CreateSessionCommand : IRequest<string>
    {
        public Session Session { get; set; }
    }
}
