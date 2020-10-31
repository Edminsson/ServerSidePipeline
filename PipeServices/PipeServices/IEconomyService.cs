using System.Threading.Tasks;

namespace PipeServices.PipeActions
{
    public interface IEconomyService
    {
        Task<int> GetEconomyResult();
    }
}