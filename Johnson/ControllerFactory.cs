using Responders;
using System.Collections.Generic;

namespace Requestors
{
    public class Controller
    {
        public virtual void Execute() {; }
    }

    public class ControllerFactory
    {
        private RequestBuilder builder;
        private UsecaseFactory factory;

        public ControllerFactory(RequestBuilder builder, UsecaseFactory factory)
        {
            this.builder = builder;
            this.factory = factory;
        }

        public Controller Create(string type, IDictionary<int, object> dictionary, IResponder responder)
        {
            if (type.Equals("Initial"))
            {
                Request request = builder.Create(type, dictionary);
                Usecase usecase = factory.Create(type, (IInitialResponder) responder);
                return new Controllers.InitialController(request, usecase, (IInitialResponder) responder);
            }
            else
                return null;
        }
    }
}
