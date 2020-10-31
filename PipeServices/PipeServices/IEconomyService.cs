using System.Threading.Tasks;

namespace PipeServices.PipeServices
{
    public interface IEconomyService
    {
        Task<int> GetEconomyResult();
    }
}