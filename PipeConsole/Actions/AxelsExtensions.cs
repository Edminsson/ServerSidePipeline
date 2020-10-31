using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace PipeConsole.Actions
{
    static class AxelsExtensions
    {
        public static IApplicationBuilder AxelsUse(this IApplicationBuilder app, Func<HttpContext, Func<Task>, Task> middleware)
        {
            return app.Use(next =>
            {
                return context =>
                {
                    Func<Task> simpleNext = () => next(context);
                    return middleware(context, simpleNext);
                };
            });
        }
    }

}
