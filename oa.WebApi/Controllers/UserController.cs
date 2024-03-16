using Microsoft.AspNetCore.Mvc;
using oa.Application.Core.Services;
using oa.Application.Interfaces;
using oa.Application.Models.Requests;
using oa.Application.Models.Responses;
using oa.Domain.Core.Repositories;
using oa.Infrastructure.Data;

namespace oa.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        public async Task<ActionResult<CreateUserRes>> CreateUser(CreateUserReq user)
        {
            var result = await _userService.CreateUser(user);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ValidateUserRes>> ValidateUser(ValidateUserReq req)
        {
            var result = await _userService.ValidateUser(req);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<GetAllActiveUsersRes>> GetAllActiveUsers()
        {
            var result = await _userService.GetAllActiveUsers();
            return Ok(result);
        }
    }
    
    
}
