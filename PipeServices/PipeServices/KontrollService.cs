using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PipeServices.PipeServices
{
    public class KontrollService : IKontrollService
    {
        public async Task Check(PipeModel model, string source)
        {
            try
            {
                model.Result.Add(source, "KontrollService");
            }
            catch(Exception)
            {
                Console.WriteLine("problem med addande");
            }
            Console.WriteLine("hej");
            await Task.Delay(200);
        }
    }
}
