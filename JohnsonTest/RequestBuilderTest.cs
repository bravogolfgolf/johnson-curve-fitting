using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace Requestors
{
    [TestClass]
    public class RequestBuilderTest
    {
        [TestMethod]
        public void ShouldReturnProperRequest()
        {
            RequestBuilder builder = new RequestBuilder();
            IDictionary dictionary = new Dictionary<int, object>();
            double[] intervals = new double[] { 1, 2 };
            double[] frequencies = new double[] { 10, 20 };
            dictionary[0] = intervals;
            dictionary[1] = frequencies;
            Request request = builder.Create("Initial", dictionary);
            Assert.IsTrue(request is InitialRequest);
        }
    }
}
