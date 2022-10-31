using AutoMapper;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.MovieViewModel;

namespace CinemaManagement.Profiles.MovieProfile
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieViewModel>();
            CreateMap<MovieViewModel, Movie>();
        }
    }
}
