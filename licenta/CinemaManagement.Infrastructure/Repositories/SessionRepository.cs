using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Infrastructure.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly CinemaManagementContext _cinemaManagementContext;

        public SessionRepository(CinemaManagementContext cinemaManagementContext)
        {
            _cinemaManagementContext=cinemaManagementContext;
        }
        public async Task<IEnumerable<Session>> GetSessions()
        {
            return await _cinemaManagementContext.Sessions               
                .Include(r => r.ReservedSeats).ThenInclude(s => s.Seat).
                ToListAsync();
        }

        public async Task<IEnumerable<Session>> GetSessionsByRoom(Guid roomId)
        {
            return await _cinemaManagementContext.Sessions.Include(r => r.Room).Where(ri => ri.RoomId == roomId).ToListAsync();
        }

        public async Task<IEnumerable<Session>> GetSessionsByMovie(Guid movieId)
        {
            return await _cinemaManagementContext.Sessions
                .Include(m => m.Movie)
                .Include(r => r.ReservedSeats).ThenInclude(s => s.Seat)
                .Where(mi => mi.MovieId == movieId).ToListAsync();
        }
        public async Task<IEnumerable<Session>> GetSessionByMovieAndCinema(Guid movieId, Guid cinemaId)
        {
            return await _cinemaManagementContext.Sessions
                .Include(m => m.Movie)
                .Include(r => r.Room).ThenInclude(c => c.Cinema)
                .Include(r => r.ReservedSeats).ThenInclude(s => s.Seat)
                .Where(mi => mi.MovieId == movieId && mi.Room.CinemaId == cinemaId && mi.SessionStart >= DateTime.UtcNow)
                .OrderBy(s => s.SessionStart)
                .ToListAsync();
        }
        public async Task<Session> GetSessionAsync(Guid sessionId)
        {
            return await _cinemaManagementContext.Sessions
                .Include(r=>r.Room).ThenInclude(s => s.Seats)
                .Include(r => r.Room).ThenInclude(c => c.Cinema)
                .Include(r => r.ReservedSeats).ThenInclude(s => s.Seat)
                .Include(m=>m.Movie)
                .Where(s => s.Id == sessionId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Session>> CheckForSessionOverlap(Session newSession)
        {
            var overlappingSessions = await _cinemaManagementContext.Sessions
                .Where(s => s.RoomId == newSession.RoomId
                    && s.SessionEnd >= newSession.SessionStart
                    && s.SessionStart <= newSession.SessionEnd)
                .ToListAsync();

            return overlappingSessions;
        }

        public async Task<Session> CreateSessionAsyc(Session session)
        {
            _cinemaManagementContext.Sessions.Add(session);
            return session;
        }
        public async Task UpdateSessionAsync(Session session)
        {
            _cinemaManagementContext.Sessions.Update(session);
        }
        public void DeleteSession(Session session)
        {
            _cinemaManagementContext.Sessions.Remove(session);
        }
        public async Task SaveAsync()
        {
            await _cinemaManagementContext.SaveChangesAsync();
        }
    }
}
