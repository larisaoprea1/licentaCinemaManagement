using AutoMapper;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.CinemaViewModels;

namespace CinemaManagement.Profiles.CinemaProfiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<Cinema, CinemaViewModel>();
            CreateMap<CinemaViewModel, Cinema>();
            CreateMap<CinemaForCreateViewModel, Cinema>();
        }
    }
}
