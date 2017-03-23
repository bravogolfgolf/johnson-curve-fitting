using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Responders;
using Usecases;

namespace Requestors
{
    [TestClass]
    public class UsecaseFactoryTest
    {
        [TestMethod]
        public void ShouldReturnProperUsecase()
        {
            IInitialResponder responser = new InitialPresenterDummy();
            UsecaseFactory factory = new UsecaseFactory();
            Usecase usecase = factory.Create("Initial", responser);
            Assert.IsTrue(usecase is InitialUsecase);
        }
    }

    public class InitialPresenterDummy : IInitialResponder
    {
        public void GernerateView()
        {
            ;
        }

        public void Present(IInitialResponse response)
        {
            ;
        }
    }
}
