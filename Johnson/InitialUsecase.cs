using Requestors;
using Responders;

namespace Usecases
{
    public class InitialUsecase : Usecase
    {
        private IResponder responder;

        public InitialUsecase(IResponder responder)
        {
            this.responder = responder;
        }

        public override void Execute(Request request)
        {
            responder.Present();
        }
    }
}