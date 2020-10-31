using PipeConsole.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PipeConsole.Actions
{
    class PipeHandler
    {
        private readonly List<Func<PipeItemResult, Task<PipeItemResult>>> pipe = new List<Func<PipeItemResult, Task<PipeItemResult>>>();
        public PipeHandler()
        {
            pipe.Add(FirstStep);
            pipe.Add(SecondStep);
        }

        public async Task<PipeItemResult> Start(int startValue)
        {
            var pipeItemResult = new PipeItemResult { CustomerId = startValue };
            foreach (var fn in pipe)
            {
                if (pipeItemResult.ErrorResult == null)
                {
                    pipeItemResult = await fn(pipeItemResult);
                }

            }
            return pipeItemResult;
        }

        private async Task<PipeItemResult> FirstStep(PipeItemResult itemResult)
        {
            if (itemResult.CustomerId == 10)
            {
                itemResult.ErrorResult = new ErrorResult { ErrorType = 1, ErrorMessage = "Value is 10" };
                return itemResult;
            }
            itemResult.CustomerId = 22;
            await Task.Delay(2000);
            return itemResult;
        }
        private async Task<PipeItemResult> SecondStep(PipeItemResult itemResult)
        {
            itemResult.OrderId = 454;
            await Task.Delay(2000);
            return itemResult;
        }
    }
}
