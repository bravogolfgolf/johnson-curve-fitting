using Microsoft.VisualStudio.TestTools.UnitTesting;
using Requests;
using Usecases;

namespace Responders
{
    [TestClass]
    public class UsecaseTest : IResponder
    {
        private bool presentMethodCalled = false;

        public void Present()
        {
            presentMethodCalled = true;
        }

        [TestMethod]
        public void ShouldCallInitialReponder()
        {
            InitialUsecase usecase = new InitialUsecase(this);
            IRequest request = new InitialRequest();
            usecase.Execute(request);
            Assert.IsTrue(presentMethodCalled);
        }
    }
}
