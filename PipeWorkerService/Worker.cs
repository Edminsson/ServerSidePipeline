using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PipeServices;
using PipeServices.PipeActions;
using PipeServices.Extensions;

namespace PipeWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHostApplicationLifetime lifetime;
        private readonly IPipeBuilder pipeBuilder;
        private readonly IPrimero primero;
        private readonly ISegundo segundo;

        public Worker(
            ILogger<Worker> logger, 
            IHostApplicationLifetime lifetime,
            IPipeBuilder pipeBuilder, 
            IPrimero primero, 
            ISegundo segundo)
        {
            _logger = logger;
            this.lifetime = lifetime;
            this.pipeBuilder = pipeBuilder;
            this.primero = primero;
            this.segundo = segundo;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            pipeBuilder.Add(primero.Handle);
            pipeBuilder.Add(segundo.Handle);

            var result = await StartAppis();

            lifetime.StopApplication();
        }

        private async Task<PipeModel> StartAppis()
        {
            var appis = pipeBuilder.Build();
            var model = new PipeModel();
            model.Result.Add("Start", "ExecuteAsync");
            await appis(model);
            return model;
        }
    }
}
