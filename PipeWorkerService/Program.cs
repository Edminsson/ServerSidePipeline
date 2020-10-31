using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PipeServices;
using PipeServices.PipeActions;
using PipeServices.PipeServices;

namespace PipeWorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddTransient<IPrimero, Primero>();
                    services.AddTransient<ISegundo, Segundo>();
                    services.AddTransient<IKontrollService, KontrollService>();
                    services.AddTransient<IEconomyService, EconomyService>();
                    services.AddTransient<IPipeBuilder, PipeBuilder>();
                });
    }
}
