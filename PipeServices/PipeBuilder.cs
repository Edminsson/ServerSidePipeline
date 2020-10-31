using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipeServices
{
    public class PipeModel
    {
        public Dictionary<string, string> Result { get; set; } = new Dictionary<string, string>();
    }
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
                if (model.Result is null)
                {
                    model.Result = new Dictionary<string, string>();
                }
                model.Result.Add("Default", "PipeBuilder");
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

