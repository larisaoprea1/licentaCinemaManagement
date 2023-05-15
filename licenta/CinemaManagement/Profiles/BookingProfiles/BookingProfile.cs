using AutoMapper;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.BookingViewModels;

namespace CinemaManagement.Profiles.BookingProfiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingViewModel>();
            CreateMap<BookingViewModel, Booking>();
        }
    }
}
