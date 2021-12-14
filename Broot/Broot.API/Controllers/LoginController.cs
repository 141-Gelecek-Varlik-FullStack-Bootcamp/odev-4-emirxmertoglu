using Broot.API.Infrastructer;
using Broot.Model;
using Broot.Service.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Broot.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMemoryCache memoryCache;
        private readonly IUserService userService;
        public LoginController(IMemoryCache _memoryCache, IUserService _userService)
        {
            memoryCache = _memoryCache;
            userService = _userService;
        }

        [HttpPost]
        public General<bool> Login([FromBody] Broot.Model.LoginModel.Login loginUser)
        {
            General<bool> response = new() { Entity= false};
            General<Broot.Model.UserModel.UserLoginModel> result = userService.Login(loginUser);
            if (result.IsSuccess)
            {
                if (!memoryCache.TryGetValue(CacheKeys.Login, out Broot.Model.UserModel.UserLoginModel _loginUser))
                {
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        AbsoluteExpiration = DateTime.Now.AddHours(1),
                        Priority = CacheItemPriority.Normal
                    };
                    
                    memoryCache.Set(CacheKeys.Login, result.Entity, cacheOptions);
                }
                response.Entity = true;
            }

            return response;
        }
    }
}
