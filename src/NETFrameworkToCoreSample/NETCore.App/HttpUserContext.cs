using System;
using Microsoft.AspNetCore.Http;
using NETCore.App.Contracts;

namespace NETCore.App
{
    public class HttpUserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpUserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid? UserId
        {
            get
            {
                if (_httpContextAccessor != null && 
                    _httpContextAccessor.HttpContext != null &&
                    _httpContextAccessor.HttpContext.Request != null)
                {
                    if (Guid.TryParse(
                        _httpContextAccessor.HttpContext.Request.Headers[HttpHeaderKeys.AuthorizationUserIdKey]
                            .ToString(), out var userId))
                    {
                        return userId;
                    }
                }

                return null;
            }
        }
    }
}