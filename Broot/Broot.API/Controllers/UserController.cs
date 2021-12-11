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

        // Get all users
        [HttpGet]
        public General<Broot.Model.UserModel.UserGetModel> Get()
        {
            return userService.Get();
        }

        // Register a user
        [HttpPost]
        [Route("Register")]
        public General<Broot.Model.UserModel.UserCreateModel> Insert([FromBody] Broot.Model.UserModel.UserCreateModel newUser)
        {
            return userService.Insert(newUser);
        }


        // Login a user
        [HttpPost]
        [Route("Login")]
        public General<Broot.Model.UserModel.UserLoginModel> Login([FromBody] Broot.Model.UserModel.UserLoginModel loginUser)
        {
            return userService.Login(loginUser);
        }


        // Update a user
        [HttpPut("{id}")]
        public General<Broot.Model.UserModel.UserUpdateModel> Update([FromBody] Broot.Model.UserModel.UserUpdateModel updatedUser, int id, int updater)
        {
            return userService.Update(updatedUser, id, updater);
        }


        // Delete a user
        [HttpDelete("{id}")]
        public General<Broot.Model.UserModel.UserDeleteModel> Delete(int id, int updater)
        {
            return userService.Delete(id, updater);
        }



    }
}
