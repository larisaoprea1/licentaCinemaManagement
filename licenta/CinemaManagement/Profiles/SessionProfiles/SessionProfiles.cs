using AutoMapper;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.SessionViewModels;

namespace CinemaManagement.Profiles.SessionProfiles
{
    public class SessionProfiles : Profile
    {
        public SessionProfiles()
        {
            CreateMap<Session, SessionViewModel>();
            CreateMap<SessionViewModel, Session>();
            CreateMap<SessionForCreateViewModel, Session>();
            CreateMap<Session, SessionForCreateViewModel>();
        }
    }
}
