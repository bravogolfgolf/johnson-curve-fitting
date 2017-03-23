using Requestors;
using Responders;

namespace Controllers
{
    public class InitialController : Controller
    {
        private Usecase usecase;
        private Request request;
        private IResponder responder;

        public InitialController(Request request, Usecase usecase, IResponder responder)
        {
            this.usecase = usecase;
            this.request = request;
            this.responder = responder;
        }

        public override void Execute()
        {
            usecase.Execute(request);
            responder.GernerateView();
        }
    }
}
