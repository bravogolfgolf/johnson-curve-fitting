using Requests;
using Usecases;

namespace Controllers
{
    interface IController
    {
        void Execute();
    }

    public class InitialController : IController
    {
        private IUsecase usecase;
        private IRequest request;

        public InitialController(IRequest request, IUsecase usecase)
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
