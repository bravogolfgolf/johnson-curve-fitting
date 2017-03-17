using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usecases;
using Requests;

namespace Controllers
{
    [TestClass]
    public class InitialContollerTest : IUsecase
    {
        private bool executeMethodCalled = false;

        public void Execute(IRequest request)
        {
            executeMethodCalled = true;
        }

        [TestMethod]
        public void ShouldCallInitialUsecase()
        {
            IRequest request = new InitialRequest();
            InitialController controller = new InitialController(request, this);
            controller.Execute();
            Assert.IsTrue(executeMethodCalled);
        }
    }
}
