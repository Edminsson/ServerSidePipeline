using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PipeServices.PipeServices
{
    public class EconomyService : IEconomyService
    {
        public async Task<int> GetEconomyResult()
        {
            await Task.Delay(200);
            return 23;
        }
    }
}
