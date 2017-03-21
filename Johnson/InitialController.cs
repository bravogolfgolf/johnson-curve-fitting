using Requestors;

namespace Controllers
{
    public class InitialController : Controller
    {
        private Usecase usecase;
        private Request request;

        public InitialController(Request request, Usecase usecase)
        {
            this.usecase = usecase;
            this.request = request;
        }

        public override void Execute()
        {
            usecase.Execute(request);
        }
    }
}
