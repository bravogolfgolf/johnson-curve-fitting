using Usecases;

namespace Controllers
{
    interface IController
    {
        void Execute();
    }

    public class InitialController : IController
    {
        IUsecase usecase;

        public InitialController(IUsecase usecase)
        {
            this.usecase = usecase;
        }

        public void Execute()
        {
            usecase.Execute();
        }
    }
}
