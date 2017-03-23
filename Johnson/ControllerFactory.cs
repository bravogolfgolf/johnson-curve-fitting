using System.Collections.Generic;
using System;

namespace Requestors
{
    public class Controller { public virtual void Execute() { } }

    public class ControllerFactory
    {
        private RequestBuilder builder = new RequestBuilder();
        private UsecaseFactory factory = new UsecaseFactory();

        public Controller Create(string type, IDictionary<int, object> dictionary, object responder)
        {
            if (type.Equals("Initial"))
            {
                Request request = builder.Create(type, dictionary);
                Usecase usecase = factory.Create(type, responder);
                return (Controller)Activator.CreateInstance(Type.GetType("Controllers.InitialController"), new object[] { request, usecase, responder });
            }
            else
                return null;
        }
    }
}
