using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Controllers;
using Usecases;
using Responders;

namespace Requestors
{
    [TestClass]
    public class ControllerFactoryTest
    {
        private ControllerFactory factory = new ControllerFactory(new RequestBuilderStub(),new UsecaseFactoryStub());
        private IDictionary<int, object> dictionary = new Dictionary<int, object>();

        [TestMethod]
        public void ShouldReturnProperController()
        {
            Controller controller = factory.Create("Initial", dictionary, new InitialPresenterDummy());
            Assert.IsTrue(controller is InitialController);
        }
    }

    public class RequestBuilderStub : RequestBuilder
    {
        public override Request Create(string type, IDictionary<int, object> dictionary)
        {
            return new Request();
        }
    }

    public class UsecaseFactoryStub : UsecaseFactory
    {
        public override Usecase Create(string type, IResponder responser)
        {
            return new InitialUsecase(new InitialPresenterDummy());
        }
    }
}
