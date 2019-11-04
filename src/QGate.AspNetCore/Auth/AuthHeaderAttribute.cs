using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;

namespace QGate.AspNetCore.Auth
{
    public class AuthHeaderAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _secret;
        private readonly string _headerName;
        public AuthHeaderAttribute(string secret, string headerName = "X-Api-Key")
        {
            _secret = secret;
            _headerName = headerName;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context?.HttpContext?.Request?.Headers != null)
            {
                if (context.HttpContext.Request.Headers.TryGetValue(_headerName, out StringValues header))
                {
                    if (header.ToString() == _secret)
                    {
                        return;
                    }
                }
            }



            context.Result = new UnauthorizedResult();
        }
    }
}
