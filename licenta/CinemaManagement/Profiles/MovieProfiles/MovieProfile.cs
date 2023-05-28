using AutoMapper;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.MovieViewModels;

namespace CinemaManagement.Profiles.MovieProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieViewModel>();
            CreateMap<MovieViewModel, Movie>();
            CreateMap<MovieForCreateViewModel, Movie>();
            CreateMap<MovieForUpdateViewModel, Movie>();
            CreateMap<SimpleMovieViewModel, Movie>();
            CreateMap<Movie, SimpleMovieViewModel>();
        }
    }
}
