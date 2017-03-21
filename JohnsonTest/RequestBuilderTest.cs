using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace Requestors
{
    [TestClass]
    public class RequestBuilderTest
    {
        private RequestBuilder builder;
        private IDictionary dictionary;

        [TestInitialize]
        public void SetUp()
        {
            builder = new RequestBuilder();
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
