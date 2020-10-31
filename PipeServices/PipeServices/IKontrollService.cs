using System.Threading.Tasks;

namespace PipeServices.PipeServices
{
    public interface IKontrollService
    {
        Task Check(PipeModel model, string source);
    }
}