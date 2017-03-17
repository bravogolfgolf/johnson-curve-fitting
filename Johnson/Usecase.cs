using Requests;
using Responders;

namespace Usecases
{
    public interface IUsecase
    {
        void Execute(IRequest request);
    }

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