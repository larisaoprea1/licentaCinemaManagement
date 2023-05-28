using AutoMapper;
using CinemaManagement.Application.DTOs;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.UserViewModels;

namespace CinemaManagement.Profiles.UserProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
            CreateMap<RegisterViewModel, User>();
            CreateMap<LoginViewModel, User>();

            CreateMap<UserWithRolesDtoApi, UserWithRolesDto>();
            CreateMap<UserWithRolesDto, UserWithRolesDtoApi>();
        }
    }
}
