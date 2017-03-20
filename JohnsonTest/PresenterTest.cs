using Microsoft.VisualStudio.TestTools.UnitTesting;
using Johnson;
using System;

namespace Johnson
{
    [TestClass]
    public class PresenterTest : IView
    {
        private bool generateViewCalled = false;

        public void GenerateView()
        {
            generateViewCalled = true;
        }

        [TestMethod]
        public void ShouldCallGenerateView()
        {
            InitialPresenter presenter = new InitialPresenter(this);
            presenter.Present();
            Assert.IsTrue(generateViewCalled);
        }
    }
}
