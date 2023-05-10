using CinemaManagement.Domain.Models;

namespace CinemaManagement.Application.Interfaces
{
    public interface IRoomRepository
    {
        Task<int> CountAsync();
        Task<Room> CreateRoomAsync(Room room);
        void DeleteRoom(Room room);
        Task<Room> GetRoomAsync(Guid roomId);
        Task<IEnumerable<Room>> GetRoomsAsync(int? page, int pageSize);
        Task<IEnumerable<Room>> GetRoomsByCinema(Guid cinemaId);
        Task<IEnumerable<Room>> GetRoomsWithoutPagination();
        Task SaveAsync();
        Task UpdateRoomAsync(Room room);
    }
}
