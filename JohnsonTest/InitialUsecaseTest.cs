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

        public void GernerateView()
        {
            ;
        }

        public void Present(IInitialResponse response)
        {
            presentMethodCalled = true;
        }

        private InitialRequest request = new InitialRequest();
        private double[] intervals = new double[] { 1, 2 };
        private double[] frequencies = new double[] { 10, 20 };

        [TestInitialize]
        public void SetUp()
        {
            request.intervals = intervals;
            request.frequencies = frequencies;
        }

        [TestMethod]
        public void ShouldCallInitialReponder()
        {
            InitialUsecase usecase = new InitialUsecase(this);
            usecase.Execute(request);
            Assert.IsTrue(presentMethodCalled);
        }
    }
}
