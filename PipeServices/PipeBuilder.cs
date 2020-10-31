using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipeServices
{
    public delegate Task MyPipeDelegate(PipeModel model);

    public interface IPipeBuilder
    {
        MyPipeDelegate Build();
        IPipeBuilder Use(Func<MyPipeDelegate, MyPipeDelegate> middleware);
    }

    public class PipeBuilder : IPipeBuilder
    {
        private readonly IList<Func<MyPipeDelegate, MyPipeDelegate>> _components = new List<Func<MyPipeDelegate, MyPipeDelegate>>();

        public IPipeBuilder Use(Func<MyPipeDelegate, MyPipeDelegate> middleware)
        {
            _components.Add(middleware);
            return this;
        }

        public MyPipeDelegate Build()
        {
            MyPipeDelegate app = model =>
            {
                model.Result[PipeAction.End] = "PipeBuilder";
                return Task.CompletedTask;
            };

            foreach (var component in _components.Reverse())
            {
                app = component(app);
            }

            return app;
        }
    }
}

