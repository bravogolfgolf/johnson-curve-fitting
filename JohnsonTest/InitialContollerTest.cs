using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Requestors;
using Responders;

namespace Controllers
{
    [TestClass]
    public class InitialContollerTest
    {
        [TestMethod]
        public void ShouldCallInitialUsecase()
        {
            Request request = new InitialRequest();
            InitialPresenterStub responder = new InitialPresenterStub();
            InitialUsecaseStub usecase = new InitialUsecaseStub();
            InitialController controller = new InitialController(request, usecase, responder);
            controller.Execute();
            Assert.IsTrue(usecase.executeMethodCalled);
            Assert.IsTrue(responder.gernerateViewCalled);
        }
    }

    public class InitialPresenterStub : IInitialResponder
    {
        public bool gernerateViewCalled = false;

        public void GernerateView()
        {
            gernerateViewCalled = true;
        }

        public void Present(IInitialResponse response)
        {
            throw new NotImplementedException();
        }
    }

    public class InitialUsecaseStub : Usecase
    {
        public bool executeMethodCalled = false;

        public override void Execute(Request request)
        {
            executeMethodCalled = true;
        }
    }
}
