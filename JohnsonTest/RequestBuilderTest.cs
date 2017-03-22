using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Requestors
{
    [TestClass]
    public class RequestBuilderTest
    {
        private RequestBuilder builder = new RequestBuilder();
        private IDictionary<int, object> dictionary;

        [TestInitialize]
        public void SetUp()
        {
            dictionary = new Dictionary<int, object>();
        }

        [TestMethod]
        public void ShouldReturnProperRequest()
        {
            double[] intervals = new double[] { 1, 2 };
            double[] frequencies = new double[] { 10, 20 };
            dictionary[0] = intervals;
            dictionary[1] = frequencies;
            Request request = builder.Create("Initial", dictionary);
            Assert.IsTrue(request is InitialRequest);
        }
    }
}
