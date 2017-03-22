using System;
using System.Collections;

namespace Requestors
{
    public class Request
    {
        private bool isValid = false;

        public bool IsValid { get => isValid; set => isValid = value; }
    }

    public class RequestBuilder
    {
        public Request Create(string requestType, IDictionary dictionary)
        {
            if (requestType.Equals("Initial"))
            {
                InitialRequest request = new InitialRequest();
                request.intervals = (double[])dictionary[0];
                request.frequencies = (double[])dictionary[1];
                request.IsValid = true;
                return request;
            }
            else
            {
                return new Request();
            }
        }
    }

    public class Usecase
    {
        public virtual void Execute(Request request) {; }
    }
}
