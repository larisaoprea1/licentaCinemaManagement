using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly CinemaManagementContext _cinemaManagementContext;
        public RoomRepository(CinemaManagementContext cinemaManagementContext)
        {
            _cinemaManagementContext = cinemaManagementContext;
        }
        public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
            return await _cinemaManagementContext.Rooms.ToListAsync();
        }
        public async Task<Room> GetRoomAsync(Guid roomId)
        {
            return await _cinemaManagementContext.Rooms.Where(r => r.Id == roomId).FirstOrDefaultAsync();
        }
        public async Task<Room> CreateProductionAsync(Room room)
        {
            _cinemaManagementContext.Rooms.Add(room);
            return room;
        }
        public async Task UpdateRoomAsync(Room room)
        {
            _cinemaManagementContext.Rooms.Update(room);
        }
        public void DeleteRoom(Room room)
        {
            _cinemaManagementContext.Rooms.Remove(room);
        }
        public async Task SaveAsync()
        {
            await _cinemaManagementContext.SaveChangesAsync();
        }
    }
}
