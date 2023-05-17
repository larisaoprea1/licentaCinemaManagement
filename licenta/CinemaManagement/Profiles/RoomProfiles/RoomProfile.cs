using AutoMapper;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.RoomViewModels;

namespace CinemaManagement.Profiles.ProductionProfiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomViewModel>();
            CreateMap<RoomViewModel, Room>();
            CreateMap<RoomForCreateViewModel, Room>();
            CreateMap<Room, RoomForCreateViewModel>();
            CreateMap<Room, SimpleRoomViewModel>();
            CreateMap<SimpleRoomViewModel, Room>();
        }
    }
}
