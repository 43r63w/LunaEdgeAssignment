using LunaTask.BLL.Dtos.User;
using LunaTask.BLL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LunaTask.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserController(IUserService userService,
            IHttpContextAccessor contextAccessor)

        {
            _userService = userService;
            _contextAccessor = contextAccessor;
        }

        [HttpPost("/register")]
        public async Task<ActionResult> Register(UserCreateDto userCreateDto)
        {
            var result = await _userService.Register(userCreateDto);

            if (result.IsSuccsed)
                return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpPost("/login")]
        public async Task<ActionResult> Login(UserLoginDto userLoginDto)
        {

            var result = await _userService.Login(userLoginDto);


            if (result.IsSuccsed)
            {
                _contextAccessor.HttpContext.Response.Cookies.Append("Token", result.Data.ToString());
                return Ok(result);
            }


            return BadRequest(result.Message);
        }
    }
}
