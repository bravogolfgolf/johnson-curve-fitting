using Microsoft.VisualStudio.TestTools.UnitTesting;
using Requestors;
using Usecases;
using Responders;

namespace Johnson
{
    [TestClass]
    public class InitialUsecaseTest : IResponder
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
            Request request = new InitialRequest();
            usecase.Execute(request);
            Assert.IsTrue(presentMethodCalled);
        }
    }
}
