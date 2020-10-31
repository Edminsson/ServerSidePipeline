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
            model.Result[PipeAction.EconomyValue] = economyResult.ToString();
            if (model.Result.ContainsKey(PipeAction.Primero))
            {
                model.Result[PipeAction.PrimeroValue] = model.Result[PipeAction.Primero];
            }
            await kontrollService.Check(model, "Segundo");
            await next();
        }
    }
}
