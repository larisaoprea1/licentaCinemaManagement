using CinemaManagement.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Application.Users.Queries.CountUsers
{
    public class CountUsersQueryHandler : IRequestHandler<CountUsersQuery, int>
    {
        private readonly IUserRepository _userRepository;

        public CountUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }
        public async Task<int> Handle(CountUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.CountAsync();
        }
    }
}
