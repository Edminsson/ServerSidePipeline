using System;
using System.Threading.Tasks;

namespace PipeServices.Extensions
{
    public static class PipeExtensions
    {
        public static IPipeBuilder Add(this IPipeBuilder app, Func<PipeModel, Func<Task>, Task> middleware)
        {
            return app.Use(next =>
            {
                return model =>
                {
                    Func<Task> simpleNext = () => next(model);
                    return middleware(model, simpleNext);
                };
            });
        }
    }
}
