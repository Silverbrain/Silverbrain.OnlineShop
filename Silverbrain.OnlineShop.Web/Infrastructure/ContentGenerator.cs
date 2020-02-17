using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Silverbrain.OnlineShop.Web.Infrastructure
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ContentGenerator
    {
        private readonly RequestDelegate _next;

        public ContentGenerator(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if(httpContext.Request.Path.ToString().ToLower().Contains("middleware"))
            {
                return httpContext.Response.WriteAsync("hello middleware...");
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ContentGeneratorExtensions
    {
        public static IApplicationBuilder UseContentGenerator(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ContentGenerator>();
        }
    }
}
