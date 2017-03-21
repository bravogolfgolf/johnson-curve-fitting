using Requestors;

namespace Controllers
{
    public class InitialController : Controller
    {
        private IUsecase usecase;
        private Request request;

        public InitialController(Request request, IUsecase usecase)
        {
            this.usecase = usecase;
            this.request = request;
        }

        public void Execute()
        {
            usecase.Execute(request);
        }
    }
}
