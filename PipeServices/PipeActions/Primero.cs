using PipeServices.PipeServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PipeServices.PipeActions
{
    public class Primero : IPrimero
    {
        private readonly IKontrollService kontrollService;

        public Primero(IKontrollService kontrollService)
        {
            this.kontrollService = kontrollService;
        }
        public async Task Handle(PipeModel model, Func<Task> next)
        {
            model.Result.Add(PipeAction.Primero, "Wow");
            await kontrollService.Check(model, "Primero");
            await next();
        }
    }
}
