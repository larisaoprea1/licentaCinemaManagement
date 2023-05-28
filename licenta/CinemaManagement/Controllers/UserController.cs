using AutoMapper;
using CinemaManagement.Application.DTOs;
using CinemaManagement.Application.Users.Commands.AddMovieToWatched;
using CinemaManagement.Application.Users.Commands.AssignRole;
using CinemaManagement.Application.Users.Commands.ChangePassword;
using CinemaManagement.Application.Users.Commands.DeleteUser;
using CinemaManagement.Application.Users.Commands.Login;
using CinemaManagement.Application.Users.Commands.Register;
using CinemaManagement.Application.Users.Commands.RemoveMovieFromWatched;
using CinemaManagement.Application.Users.Commands.RemoveRole;
using CinemaManagement.Application.Users.Commands.UpdateUser;
using CinemaManagement.Application.Users.Queries.CountUsers;
using CinemaManagement.Application.Users.Queries.GetAllUsers;
using CinemaManagement.Application.Users.Queries.GetUserByEmail;
using CinemaManagement.Application.Users.Queries.GetUserById;
using CinemaManagement.Application.Users.Queries.GetUserByUsername;
using CinemaManagement.Application.Users.Queries.GetUsersPaginated;
using CinemaManagement.Application.Users.Queries.GetUserWatchedMovies;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.MovieViewModels;
using CinemaManagement.ViewModels.UserViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CinemaManagement.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public UserController(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetUsers()
        {
            var usersToFind = await _mediator.Send(new GetAllUsersQuery());
            return Ok(_mapper.Map<IEnumerable<UserViewModel>>(usersToFind));
        }
       

        [HttpGet]
        [Route("page/{page}/pagesize/{pagesize}")]
        public async Task<IActionResult> GetUsersPaginated(int page, int pagesize)
        {
            var users = await _mediator.Send(new GetUsersPaginatedQuery
            {
                Page = page,
                PageSize = pagesize
            });

            var count = await _mediator.Send(new CountUsersQuery());
            var totalPages = ((double)count / (double)pagesize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            var result = _mapper.Map<IEnumerable<UserWithRolesDtoApi>>(users);
            return Ok(new PagedResponse<IEnumerable<UserWithRolesDtoApi>>(result, page, count, roundedTotalPages, pagesize));
        }

        [HttpGet]
        [Route("email/{email}")]
        public async Task<IActionResult> GetUserByEmail([FromRoute] string email)
        {
            var userByEmail = await _mediator.Send(new GetUserByEmailQuery
            {
                Email = email
            });
            return Ok(_mapper.Map<UserViewModel>(userByEmail));
        }
        [HttpGet]
        [Route("username/{username}")]
        public async Task<IActionResult> GetUserByUsername([FromRoute] string username)
        {
            var userByUsername = await _mediator.Send(new GetUserByUsernameQuery
            {
                UserName = username
            });
            return Ok(_mapper.Map<UserViewModel>(userByUsername));
        }
        [HttpGet]
        [Route("userId/{userId}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid userId)
        {
            var userById = await _mediator.Send(new GetUserByIdQuery
            {
                Id = userId
            });
            return Ok(_mapper.Map<UserViewModel>(userById));
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userUsername = await _mediator.Send(new GetUserByUsernameQuery
            {
                UserName = user.UserName
            });
            if (userUsername != null)
            {
                return BadRequest();
            }
            var userEmail = await _mediator.Send(new GetUserByEmailQuery
            {
                Email = user.Email
            });
            if (userEmail != null)
            {
                return BadRequest();
            }
            var usertToCreate = new User
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ProfileImageSrc = user.ProfileImageSrc
            };
            var result = await _mediator.Send(new RegisterCommand
            {
                User = usertToCreate,
                Password = user.Password,

            });
            var userToReturn = _mapper.Map<UserViewModel>(result);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(userToReturn);
        }
        [HttpPost]
        [Route("login")]
        public async Task<object> Login([FromBody] LoginViewModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _mediator.Send(new LoginCommand
            {
                Email = user.Email,
                Password = user.Password
            });
            if (result == "401")
            {
                return Unauthorized();
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("assign-role/user/{userName}/role/{roleName}")]
        public async Task<IActionResult> AssignRole(string userName, string roleName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _mediator.Send(new GetUserByUsernameQuery
            {
                UserName = userName,
            });
            if (user == null)
            {
                return NotFound("404");
            }
            var result = await _mediator.Send(new AssignRoleCommand
            {
                UserName = userName,
                RoleName = roleName
            });
            if (!result)
            {
                BadRequest();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("remove-role/user/{userName}/role/{roleName}")]
        public async Task<IActionResult> RemoveRoleFromUser(string userName, string roleName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var query = new GetUserByUsernameQuery
            {
                UserName = userName,
            };

            var userFound = await _mediator.Send(query);

            if (userFound == null)
                return BadRequest("User not found");

            var command = new RemoveRoleCommand
            {
                UserName = userName,
                RoleName = roleName
            };

            var result = await _mediator.Send(command);

            if (!result)
            {
                return BadRequest("Failed to remove role from user");
            }

            return Ok($"{userName} removed successfully from {roleName} role");
        }

        [HttpPost]
        [Route("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePassword)
        {
            string claim = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _mediator.Send(new ChangePasswordCommand
            {
                UserName = claim,
                oldPassword = changePassword.oldPassword,
                newPassword = changePassword.newPassword
            });
            if (result == false)
            {
                return BadRequest("400");
            }
            return Ok("200");
        }
        [HttpDelete]
        [Route("deleteuser/{userId}")]
        public async Task<ActionResult> DeleteUser([FromRoute] Guid userId)
        {
            await _mediator.Send(new DeleteUserCommand
            {
                Id = userId
            });
            return Ok("200");
        }

        [HttpPost]
        [Route("movie/{movieid}/user/{userid}")]
        public async Task<ActionResult> AddMovieToWatched(Guid movieid, Guid userid)
        {
            var command = new AddMovieToWatchedCommand
            {
                MovieId = movieid,
                UserId = userid
            };

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        [Route("movie/{movieid}/user/{userid}")]
        public async Task<ActionResult> RemoveMovieFromWatched(Guid movieid, Guid userid)
        {
            var command = new RemoveMovieFromWatchedCommand
            {
                MovieId = movieid,
                UserId = userid
            };

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("watchedmovies/{username}")]
        public async Task<ActionResult> GetWatchedMovies(string username)
        {
            var result = await _mediator.Send(new GetUserWatchedMoviesQuery { UserName = username });
            var mappedResult = _mapper.Map<IEnumerable<SimpleMovieViewModel>>(result);
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("edituser/{userId}")]
        public async Task<ActionResult<UserViewModel>> EditUser([FromRoute] Guid userId, UserToUpdateViewModel user)
        {
            var result = await _mediator.Send(new UpdateUserCommand
            {
                Id = userId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ProfileImageSrc = user.ProfileImageSrc,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                UserName = user.UserName,
            });

            var mappedResult = _mapper.Map<UserViewModel>(result);
            return Ok(mappedResult);
        }

    }
}
