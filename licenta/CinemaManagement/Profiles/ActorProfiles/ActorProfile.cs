using AutoMapper;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.ActorViewModels;

namespace CinemaManagement.Profiles.ActorProfiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ActorViewModel>();
            CreateMap<ActorViewModel, Actor>();
            CreateMap<ActorForCreateViewModel, Actor>();
            CreateMap<Actor, ActorForPopulateViewModel>();

        }
    }
}
