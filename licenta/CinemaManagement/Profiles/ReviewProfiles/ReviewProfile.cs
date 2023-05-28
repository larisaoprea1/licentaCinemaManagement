using AutoMapper;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.ReviewViewModels;

namespace CinemaManagement.Profiles.ReviewProfiles
{
    public class ReviewProfile: Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewViewModel>();
            CreateMap<ReviewViewModel, Review>();
            CreateMap<Review, ReviewToCreateViewModel>();
            CreateMap<ReviewToCreateViewModel, Review>();
        }
    }
}
