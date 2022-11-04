using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Actors.Commands.EditActor
{
    public class EditActorCommand : IRequest<Actor>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Information { get; set; }
        public string Nationality { get; set; }
        public string PictureSrc { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
