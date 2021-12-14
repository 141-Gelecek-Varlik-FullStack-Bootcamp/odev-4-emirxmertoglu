using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Broot.API.Infrastructer
{
    public class LoginFilter : Attribute, IActionFilter
    {
        private readonly IMemoryCache memoryCache;
        public LoginFilter(IMemoryCache _memoryCache)
        {
            memoryCache = _memoryCache;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!memoryCache.TryGetValue(CacheKeys.Login, out Broot.Model.UserModel.UserLoginModel response))
            {
                context.Result = new UnauthorizedObjectResult(value: "object is null");
            }
            return;
        }
    }
}
