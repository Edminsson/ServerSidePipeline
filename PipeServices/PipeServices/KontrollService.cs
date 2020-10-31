using System;
using System.Threading.Tasks;

namespace PipeServices.PipeServices
{
    public class KontrollService : IKontrollService
    {
        public async Task Check(PipeModel model, string source)
        {
            try
            {
                model.Result[PipeAction.Control] = source;
            }
            catch(Exception)
            {
                Console.WriteLine("problem med addande");
            }
            model.Errors.Add(new Models.PipeError { ErrorType = Enums.ErrorType.Standard, ErrorMessage = source });
            Console.WriteLine("hej");
            await Task.Delay(200);
        }
    }
}
