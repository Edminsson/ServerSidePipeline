//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace PipeConsole.Actions
//{
//    public class PipeModel
//    {
//        public Dictionary<string, string> Result { get; set; }
//    }
//    public delegate Task MyPipeDelegate(PipeModel model);
//    static class PipeExtensions
//    {
//        public static IPipeBuilder Use(this IPipeBuilder app, Func<PipeModel, Func<Task>, Task> middleware)
//        {
//            return app.Use(next =>
//            {
//                return model =>
//                {
//                    Func<Task> simpleNext = () => next(model);
//                    return middleware(model, simpleNext);
//                };
//            });
//        }
//    }
//    public interface IPipeBuilder
//    {
//        MyPipeDelegate Build();
//        IPipeBuilder Use(Func<MyPipeDelegate, MyPipeDelegate> middleware);
//    }

//    public class PipeBuilder : IPipeBuilder
//    {
//        private readonly IList<Func<MyPipeDelegate, MyPipeDelegate>> _components = new List<Func<MyPipeDelegate, MyPipeDelegate>>();

//        public IPipeBuilder Use(Func<MyPipeDelegate, MyPipeDelegate> middleware)
//        {
//            _components.Add(middleware);
//            return this;
//        }

//        public MyPipeDelegate Build()
//        {
//            MyPipeDelegate app = model =>
//            {
//                if (model.Result is null)
//                {
//                    model.Result = new Dictionary<string, string>();
//                }
//                model.Result.Add("Default", "hej");
//                return Task.CompletedTask;
//            };

//            foreach (var component in _components.Reverse())
//            {
//                app = component(app);
//            }

//            return app;
//        }
//    }
//}
