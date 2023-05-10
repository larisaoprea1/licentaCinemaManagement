using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace CinemaManagement.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly CinemaManagementContext _cinemaManagementContext;
        public RoomRepository(CinemaManagementContext cinemaManagementContext)
        {
            _cinemaManagementContext = cinemaManagementContext;
        }
        public async Task<IEnumerable<Room>> GetRoomsWithoutPagination()
        {
            return await _cinemaManagementContext.Rooms.Include(c => c.Cinema).Include(s => s.Seats).ToListAsync();
        }
        public async Task<IEnumerable<Room>> GetRoomsAsync(int? page, int pageSize)
        {
            int pageNumber = (page ?? 1);
            return await _cinemaManagementContext.Rooms.Include(c => c.Cinema).Include(s => s.Seats).ToPagedListAsync(pageNumber, pageSize);
        }
        public async Task<IEnumerable<Room>> GetRoomsByCinema(Guid cinemaId)
        {
            return await _cinemaManagementContext.Rooms.Include(s => s.Seats).Include(c => c.Cinema).Where(id => id.CinemaId == cinemaId).ToListAsync();
        }
        public async Task<Room> GetRoomAsync(Guid roomId)
        {
            return await _cinemaManagementContext.Rooms.Include(c => c.Cinema).Include(s => s.Seats).Where(r => r.Id == roomId).FirstOrDefaultAsync();
        }
        public async Task<Room> CreateRoomAsync(Room room)
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
        public async Task<int> CountAsync()
        {
            return await _cinemaManagementContext.Rooms.CountAsync();
        }
        public async Task SaveAsync()
        {
            await _cinemaManagementContext.SaveChangesAsync();
        }
    }
}
