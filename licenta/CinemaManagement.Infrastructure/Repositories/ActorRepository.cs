using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Infrastructure.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly CinemaManagementContext _cinemaManagementContext;
        public ActorRepository(CinemaManagementContext cinemaManagementContext)
        {
            _cinemaManagementContext = cinemaManagementContext;
        }
        public async Task<IEnumerable<Actor>> GetActorsAsync()
        {
            return await _cinemaManagementContext.Actors.ToListAsync();
        }
        public async Task<Actor> GetActorAsync(Guid actorId)
        {
            return await _cinemaManagementContext.Actors.Include(m=>m.Movies).Where(g => g.Id == actorId).FirstOrDefaultAsync();
        }
        public async Task<Actor> CreateActorAsync(Actor actor)
        {
            _cinemaManagementContext.Actors.Add(actor);
            return actor;
        }
        public async Task AddActorToMovieAsync(Movie movie, Actor actor)
        {
            movie.Actors.Add(actor);
        }
        public async Task UpdateActorAsync(Actor actor)
        {
            _cinemaManagementContext.Actors.Update(actor);
        }
         public void DeleteActor(Actor actor)
        {
            _cinemaManagementContext.Actors.Remove(actor);
        }
        public async Task SaveAsync()
        {
            await _cinemaManagementContext.SaveChangesAsync();
        }
    }
}
