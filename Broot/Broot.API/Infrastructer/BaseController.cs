using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Broot.API.Infrastructer
{
    public class BaseController : ControllerBase
    {
        private IMemoryCache memoryCache;

        public BaseController(IMemoryCache _memoryCache)
        {
            memoryCache = _memoryCache;
        }

        public Broot.Model.UserModel.UserLoginModel CurrentUser { get { return GetCurrentUser(); } }

        private Broot.Model.UserModel.UserLoginModel GetCurrentUser()
        {
            var response = new Broot.Model.UserModel.UserLoginModel();
            memoryCache.TryGetValue(CacheKeys.Login, out response);

            //if (memoryCache.TryGetValue(CacheKeys.Login, out Broot.Model.UserModel.UserLoginModel loginUser))
            //{
            //    response = loginUser;
            //}

            return response;
        }
    }
}
