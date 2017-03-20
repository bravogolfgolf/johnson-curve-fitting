using Requestors;
using Responders;

namespace Usecases
{
    public class InitialUsecase : IUsecase
    {
        private IResponder responder;

        public InitialUsecase(IResponder responder)
        {
            this.responder = responder;
        }

        public void Execute(IRequest request)
        {
            responder.Present();
        }
    }
}