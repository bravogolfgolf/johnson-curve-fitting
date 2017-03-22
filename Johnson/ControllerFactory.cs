using Responders;
using System;
using System.Collections.Generic;
using Usecases;

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
                Usecase usecase = factory.Create(type, responder);
                return new Controllers.InitialController(request, usecase);
            }
            else
                return null;
        }
    }
}
