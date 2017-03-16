using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    interface IController
    {
        void Execute();
    }

    public class InitialController : IController
    {
        public void Execute()
        {
            ;
        }
    }
}
