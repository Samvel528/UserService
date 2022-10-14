using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using UserService.Application.Users.Commands.CreateUser;
using UserService.Application.Users.Commands.DeleteUser;
using UserService.Application.Users.Commands.UpdateUser;
using UserService.Application.Users.Queries.GetUsers;
using UserService.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace UserService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserListVM>> GetAll()
        {
            var query = new GetUsersQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDTO createUserDTO)
        {
            var command = _mapper.Map<CreateUserCommand>(createUserDTO);
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateUserDTO updateUserDTO)
        {
            var command = _mapper.Map<UpdateUserCommand>(updateUserDTO);
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
