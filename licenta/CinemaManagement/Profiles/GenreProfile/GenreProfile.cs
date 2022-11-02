using AutoMapper;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.GenreViewModel;

namespace CinemaManagement.Profiles.GenreProfile
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
