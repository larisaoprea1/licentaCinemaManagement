using CinemaManagement.Domain.Models;

namespace CinemaManagement.Application.Interfaces
{
    public interface IActorRepository
    {
        Task<IEnumerable<Actor>> GetActorsAsync(int? page, int pageSize);
        Task<Actor> GetActorAsync(Guid actorId);
        Task<Actor> CreateActorAsync(Actor actor);
        Task AddActorToMovieAsync(Movie movie, Actor actor);
        Task UpdateActorAsync(Actor actor);
        void DeleteActor(Actor actor);
        Task SaveAsync();
        Task<ICollection<Actor>> GetActorsById(List<Guid> ids);
        Task<int> CountAsync();
        Task<IEnumerable<Actor>> GetActorsWithoutPagination();
    }
}
