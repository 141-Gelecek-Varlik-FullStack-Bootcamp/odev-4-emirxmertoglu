using Broot.Model;
using Broot.Service.User;
using Microsoft.AspNetCore.Mvc;

namespace Broot.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpPost]
        [Route("Register")]
        public General<Broot.Model.UserModel.UserCreateModel> Insert([FromBody] Broot.Model.UserModel.UserCreateModel newUser)
        {
            return userService.Insert(newUser);
        }

        [HttpPost]
        [Route("Login")]
        public General<Broot.Model.UserModel.UserLoginModel> Login([FromBody] Broot.Model.UserModel.UserLoginModel loginUser)
        {
            return userService.Login(loginUser);
        }
    }
}
