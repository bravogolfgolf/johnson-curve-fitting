using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
