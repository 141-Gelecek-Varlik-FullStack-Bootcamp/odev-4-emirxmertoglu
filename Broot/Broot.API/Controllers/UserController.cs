using Broot.API.Infrastructer;
using Broot.Model;
using Broot.Service.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Broot.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService, IMemoryCache _memoryCache) : base(_memoryCache)
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
        [ServiceFilter(typeof(LoginFilter))]
        //[LoginFilter]
        public General<Broot.Model.UserModel.UserCreateModel> Insert([FromBody] Broot.Model.UserModel.UserCreateModel newUser)
        {
            General<Broot.Model.UserModel.UserCreateModel> response = new();
            return userService.Insert(newUser);
        }


        // Login a user
        //[HttpPost]
        //[Route("Login")]
        //public General<Broot.Model.UserModel.UserLoginModel> Login([FromBody] Broot.Model.UserModel.UserLoginModel loginUser)
        //{
        //    return userService.Login(loginUser);
        //}


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
