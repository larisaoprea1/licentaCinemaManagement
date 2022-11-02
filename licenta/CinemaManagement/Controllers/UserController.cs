using AutoMapper;
using CinemaManagement.Application.Users.Commands.AssignRole;
using CinemaManagement.Application.Users.Commands.ChangePassword;
using CinemaManagement.Application.Users.Commands.DeleteUser;
using CinemaManagement.Application.Users.Commands.Login;
using CinemaManagement.Application.Users.Commands.Register;
using CinemaManagement.Application.Users.Queries.GetAllUsers;
using CinemaManagement.Application.Users.Queries.GetUserByEmail;
using CinemaManagement.Application.Users.Queries.GetUserById;
using CinemaManagement.Application.Users.Queries.GetUserByUsername;
using CinemaManagement.Domain.Models;
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
        [Route("assign-role")]
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
    }
}
