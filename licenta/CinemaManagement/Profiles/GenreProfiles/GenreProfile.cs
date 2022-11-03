using AutoMapper;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.GenreViewModels;

namespace CinemaManagement.Profiles.GenreProfiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreViewModel>();
            CreateMap<GenreViewModel, Genre>();
            CreateMap<GenreForCreateViewModel, Genre>();

        }
    }
}
