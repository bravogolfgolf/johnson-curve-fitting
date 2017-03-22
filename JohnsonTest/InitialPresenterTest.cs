using Microsoft.VisualStudio.TestTools.UnitTesting;
using Responders;
using Usecases;

namespace Johnson
{
    [TestClass]
    public class InitialPresenterTest : IView
    {
        private bool generateViewCalled = false;

        public void GenerateView()
        {
            generateViewCalled = true;
        }

        [TestMethod]
        public void ShouldCallGenerateView()
        {
            IInitialResponse response = new InitialResponse();
            InitialPresenter presenter = new InitialPresenter(this);
            presenter.Present(response);
            Assert.IsTrue(generateViewCalled);
        }
    }
}
