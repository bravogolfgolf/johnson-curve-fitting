using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Controllers;
using Johnson;

namespace Requestors
{
    [TestClass]
    public class ControllerFactoryTest
    {
        private ControllerFactory factory = new ControllerFactory();
        private IDictionary<int, object> dictionary;

        [TestInitialize]
        public void SetUp()
        {
            dictionary = new Dictionary<int, object>();
        }

        [TestMethod]
        public void ShouldReturnProperController()
        {
            double[] intervals = new double[] { 1, 2 };
            double[] frequencies = new double[] { 10, 20 };
            dictionary[0] = intervals;
            dictionary[1] = frequencies;
            Controller controller = factory.Create("Initial", dictionary, new InitialPresenter(new InitialView()));
            Assert.IsTrue(controller is InitialController);
        }
    }
}
