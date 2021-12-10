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
        public General<Broot.Model.UserModel.User> Insert([FromBody] Broot.Model.UserModel.User newUser)
        {
            return userService.Insert(newUser);
        }
    }
}
