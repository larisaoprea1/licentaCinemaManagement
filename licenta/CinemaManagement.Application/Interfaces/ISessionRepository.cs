using CinemaManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Application.Interfaces
{
    public interface ISessionRepository
    {
        Task<IEnumerable<Session>> CheckForSessionOverlap(Session newSession);
        Task<Session> CreateSessionAsyc(Session session);
        void DeleteSession(Session session);
        Task<Session> GetSessionAsync(Guid sessionId);
        Task<IEnumerable<Session>> GetSessionByMovieAndCinema(Guid movieId, Guid cinemaId);
        Task<IEnumerable<Session>> GetSessions();
        Task<IEnumerable<Session>> GetSessionsByMovie(Guid movieId);
        Task<IEnumerable<Session>> GetSessionsByRoom(Guid roomId);
        Task SaveAsync();
        Task UpdateSessionAsync(Session session);
    }
}
