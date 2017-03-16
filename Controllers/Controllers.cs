using System;

namespace Controllers
{
    public interface Controller
    {
        void Execute();
    }

    public class InitialController : Controller
    {
        public void Execute()
        {
            ;
        }
    }
}
