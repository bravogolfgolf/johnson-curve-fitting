using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Johnson
{
    [TestClass]
    public class InitialPresenterTest
    {
        [TestMethod]
        public void ShouldCallGenerateView()
        {
            InitialViewDummy view = new InitialViewDummy();
            InitialPresenter presenter = new InitialPresenter(view);
            presenter.GernerateView();
            Assert.IsTrue(view.generateViewCalled);
        }
    }

    public class InitialViewDummy : IView
    {
        public bool generateViewCalled = false;

        public void GenerateView(object viewModel)
        {
            generateViewCalled = true;
        }
    }
}
