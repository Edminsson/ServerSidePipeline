using Microsoft.AspNetCore.Builder.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PipeConsole.Actions;
using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Threading.Tasks;

namespace PipeConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var appBuilder = new Appbyggare().GetPipeBuilder();
            var appis = appBuilder.Build();
            var result = new Dictionary<string, string>();
            result.Add("Main", "Main");
            var pipeModel = new PipeModel { Result = result };
            await appis(pipeModel); ;

            //var appBuilder = new Appbyggare().GetApplicationBuilder();
            //var appis = appBuilder.Build();
            //await appis(new DefaultHttpContext());
        }


        private async Task Test()
        {
            ServiceCollection services = new ServiceCollection();
            var provider = services.BuildServiceProvider();
            Microsoft.AspNetCore.Builder.Internal.ApplicationBuilder app = new Microsoft.AspNetCore.Builder.Internal.ApplicationBuilder(provider);
            //RequestDelegate requestDelegate1 = ctx =>
            //{
            //    Console.WriteLine("Del1");
            //    return Task.CompletedTask;
            //};
            //Func<RequestDelegate, RequestDelegate> app1 = del => requestDelegate1;
            //app.Use(app1);

            //RequestDelegate requestDelegate2 = ctx =>
            //{
            //    Console.WriteLine("Del2");
            //    return Task.CompletedTask;
            //};
            //Func<RequestDelegate, RequestDelegate> app2 = del => requestDelegate2;
            //app.Use(app2);

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
            var appis = app.Build();
            await appis(new DefaultHttpContext());

            Console.WriteLine("Hello World!");
            //var pipeHandler = new PipeHandler();
            //var result1 = await pipeHandler.Start(3);
            //var result2 = await pipeHandler.Start(10);
            //var result3 = await pipeHandler.Start(45);

        }

    }
}
