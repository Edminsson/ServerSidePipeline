using PipeServices.PipeServices;
using System;
using System.Threading.Tasks;

namespace PipeServices.PipeActions
{
    public class Segundo : ISegundo
    {
        private readonly IEconomyService economyService;
        private readonly IKontrollService kontrollService;

        public Segundo(IEconomyService economyService, IKontrollService kontrollService)
        {
            this.economyService = economyService;
            this.kontrollService = kontrollService;
        }

        public async Task Handle(PipeModel model, Func<Task> next)
        {
            var economyResult = await economyService.GetEconomyResult();
            model.Result.Add("EconomyResult", economyResult.ToString());
            if (model.Result.ContainsKey("First Own"))
            {
                model.Result.Add("Segund found primeros key", "First Own");
            }
            await kontrollService.Check(model, "Segundo");
            await next();
        }
    }
}
