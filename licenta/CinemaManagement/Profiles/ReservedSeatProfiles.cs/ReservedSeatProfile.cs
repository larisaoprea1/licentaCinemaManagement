using AutoMapper;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.ReservedSeatViewModels;

namespace CinemaManagement.Profiles.ReservedSeatProfiles.cs
{
    public class ReservedSeatProfile : Profile
    {
        public ReservedSeatProfile()
        {
            CreateMap<ReservedSeat, ReservedSeatViewModel>();
            CreateMap<ReservedSeatViewModel, ReservedSeat>();
        }
    }
}
