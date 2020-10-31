using System;
using System.Threading.Tasks;

namespace PipeServices.PipeActions
{
    public interface ISegundo
    {
        Task Handle(PipeModel model, Func<Task> next);
    }
}