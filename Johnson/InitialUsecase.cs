using Requestors;
using Responders;
using Entities;

namespace Usecases
{
    public class InitialUsecase : Usecase
    {
        private IInitialResponder responder;

        public InitialUsecase(IInitialResponder responder)
        {
            this.responder = responder;
        }

        public override void Execute(Request request)
        {
            InitialRequest r = (InitialRequest)request;
            Histogram histogram = new Histogram(r.intervals, r.frequencies);
            InitialResponse response = new InitialResponse();
            responder.Present(response);
        }
    }
}