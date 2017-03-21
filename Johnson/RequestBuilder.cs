using System;
using System.Collections;

namespace Requestors
{
    public class Controller
    {
        void Execute() {; }
    }

    public class Request
    {
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
                return request;
            }
            else
            {
                return null;
            }
        }
    }

    public interface IUsecase
    {
        void Execute(Request request);
    }
}
