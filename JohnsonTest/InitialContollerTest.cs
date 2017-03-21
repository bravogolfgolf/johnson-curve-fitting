using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usecases;
using Requestors;

namespace Controllers
{
    [TestClass]
    public class InitialContollerTest : IUsecase
    {
        private bool executeMethodCalled = false;

        public void Execute(Request request)
        {
            executeMethodCalled = true;
        }

        [TestMethod]
        public void ShouldCallInitialUsecase()
        {
            Request request = new InitialRequest();
            InitialController controller = new InitialController(request, this);
            controller.Execute();
            Assert.IsTrue(executeMethodCalled);
        }
    }
}
