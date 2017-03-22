using System;
using System.Collections.Generic;

namespace Requestors
{
    public class Request
    {
    }

    public class RequestBuilder
    {
        public virtual Request Create(string type, IDictionary<int, object> dictionary)
        {
            if (type.Equals("Initial"))
            {
                InitialRequest request = new InitialRequest();
                request.intervals = (double[])dictionary[0];
                request.frequencies = (double[])dictionary[1];
                return request;
            }
            else
                return null;
        }
    }

    public class Usecase
    {
        public virtual void Execute(Request request) {; }
    }
}
