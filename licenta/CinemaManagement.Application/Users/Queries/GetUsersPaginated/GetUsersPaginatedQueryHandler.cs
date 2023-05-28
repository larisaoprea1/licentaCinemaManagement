using CinemaManagement.Application.DTOs;
using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Application.Users.Queries.GetUsersPaginated
{
    public class GetUsersPaginatedQueryHandler : IRequestHandler<GetUsersPaginatedQuery, IEnumerable<UserWithRolesDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        public GetUsersPaginatedQueryHandler(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository=userRepository;
            _userManager=userManager;
        }

        public async Task<IEnumerable<UserWithRolesDto>> Handle(GetUsersPaginatedQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsersPaginatedAsync(request.Page, request.PageSize);
            var usersToReturn = new List<UserWithRolesDto>();
            foreach (var user in users)
            {
                var role = (await _userManager.GetRolesAsync(user)).ToList();
                var userWithRoles = new UserWithRolesDto
                {
                    User = user,
                    Roles = role
                };
                usersToReturn.Add(userWithRoles);
            }
            return usersToReturn;
        }
    }
}
