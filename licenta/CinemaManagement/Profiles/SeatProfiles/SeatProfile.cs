using AutoMapper;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.SeatViewModels;

namespace CinemaManagement.Profiles.SeatProfiles
{
    public class SeatProfile : Profile
    {
        public SeatProfile()
        {
            CreateMap<Seat, SeatViewModel>();
            CreateMap<SeatViewModel, Seat>();
        }
    }
}
