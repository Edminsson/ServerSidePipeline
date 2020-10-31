using Microsoft.AspNetCore.Builder.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PipeServices;
using PipeServices.Extensions;
using System;
using System.Threading.Tasks;

namespace PipeConsole.Actions
{
    public class Appbyggare
    {
        public ApplicationBuilder GetApplicationBuilder()
        {
            ServiceCollection services = new ServiceCollection();
            var provider = services.BuildServiceProvider();
            ApplicationBuilder app = new ApplicationBuilder(provider);

            app.AxelsUse(async (http, next) =>
            {
                Console.WriteLine("Axels Use 1");
                await next();
            });
            app.AxelsUse(async (http, next) =>
            {
                Console.WriteLine("Axels Use 2");
                await next();
            });

            return app;
        }

        public PipeBuilder GetPipeBuilder()
        {
            PipeBuilder app = new PipeBuilder();

            app.Add(async (model, next) =>
            {
                model.Result.Add(PipeAction.Primero, "Wow");
                await next();
            });
            app.Add(async (model, next) =>
            {
                model.Result.Add(PipeAction.Segundo, "Wow");
                await next();
            });

            return app;
        }


        public ApplicationBuilder GetApplicationBuilderTest()
        {
            ServiceCollection services = new ServiceCollection();
            var provider = services.BuildServiceProvider();
            Microsoft.AspNetCore.Builder.Internal.ApplicationBuilder app = new Microsoft.AspNetCore.Builder.Internal.ApplicationBuilder(provider);
            RequestDelegate requestDelegate1 = ctx =>
            {
                Console.WriteLine("Del1");
                return Task.CompletedTask;
            };
            Func<RequestDelegate, RequestDelegate> app1 = del => requestDelegate1;
            app.Use(app1);

            RequestDelegate requestDelegate2 = ctx =>
            {
                Console.WriteLine("Del2");
                return Task.CompletedTask;
            };
            Func<RequestDelegate, RequestDelegate> app2 = del => requestDelegate2;
            app.Use(app2);

            app.AxelsUse(async (http, next) =>
            {
                Console.WriteLine("Axels Use");
                await next();
            });

            return app;
        }

    }
}
