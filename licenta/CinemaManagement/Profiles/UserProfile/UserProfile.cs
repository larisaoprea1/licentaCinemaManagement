﻿using AutoMapper;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.UserViewModels;

namespace CinemaManagement.Profiles.UserProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
            CreateMap<RegisterViewModel, User>();
            CreateMap<LoginViewModel, User>();
        }
    }
}
