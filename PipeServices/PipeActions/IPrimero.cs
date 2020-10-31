using System;
using System.Threading.Tasks;

namespace PipeServices.PipeActions
{
    public interface IPrimero
    {
        Task Handle(PipeModel model, Func<Task> next);
    }
}