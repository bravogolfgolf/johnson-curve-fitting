using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usecases;

namespace Controllers
{
    [TestClass]
    public class InitialContollerTest : IUsecase
    {
        private bool executeMethodCalled = false;

        void IUsecase.Execute()
        {
            executeMethodCalled = true;
        }

        [TestMethod]
        public void ShouldCallInitialUsecase()
        {
            InitialController controller = new InitialController(this);
            controller.Execute();
            Assert.IsTrue(executeMethodCalled);
        }

        
    }
}
