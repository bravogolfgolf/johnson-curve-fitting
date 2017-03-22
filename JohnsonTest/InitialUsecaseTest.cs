using Microsoft.VisualStudio.TestTools.UnitTesting;
using Requestors;
using Usecases;
using Responders;
using System;

namespace Johnson
{
    [TestClass]
    public class InitialUsecaseTest : IInitialResponder
    {
        private bool presentMethodCalled = false;
        
        public void Present(IInitialResponse response)
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
