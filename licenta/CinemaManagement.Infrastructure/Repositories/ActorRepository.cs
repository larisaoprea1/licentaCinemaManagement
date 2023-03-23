using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace CinemaManagement.Infrastructure.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly CinemaManagementContext _cinemaManagementContext;
        public ActorRepository(CinemaManagementContext cinemaManagementContext)
        {
            _cinemaManagementContext = cinemaManagementContext;
        }
        public async Task<IEnumerable<Actor>> GetActorsAsync(int? page, int pageSize)
        {
            int pageNumber = (page ?? 1);
            return await _cinemaManagementContext.Actors.ToPagedListAsync(pageNumber, pageSize);
        }
        public async Task<IEnumerable<Actor>> GetActorsWithoutPagination()
        {
            return await _cinemaManagementContext.Actors.ToListAsync();
        }
        public async Task<ICollection<Actor>> GetActorsById(List<Guid> ids)
        {
            return await _cinemaManagementContext.Actors.Where(actor => ids.Contains(actor.Id)).ToListAsync();
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
        public async Task<int> CountAsync()
        {
            return await _cinemaManagementContext.Actors.CountAsync();
        }
        public async Task SaveAsync()
        {
            await _cinemaManagementContext.SaveChangesAsync();
        }
    }
}
