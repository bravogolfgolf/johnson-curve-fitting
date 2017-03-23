using Responders;

namespace Johnson
{
    public class InitialPresenter : IInitialResponder
    {
        private InitialViewModel viewModel = new InitialViewModel();
        private IView view;

        public InitialPresenter(IView view)
        {
            this.view = view;
        }

        public void GernerateView()
        {
            view.GenerateView(viewModel);
        }

        public void Present(IInitialResponse response)
        {
            viewModel.mean1stMomment = response.Mean1stMomment;
            viewModel.mean2ndtMomment = response.Mean2ndtMomment;
            viewModel.mean3rdMomment = response.Mean3rdMomment;
            viewModel.mean4thMomment = response.Mean4thMomment;
            viewModel.n2 = response.N2;
            viewModel.n3 = response.N3;
            viewModel.n4 = response.N4;
            viewModel.b1 = response.B1;
            viewModel.b2 = response.B2;
            viewModel.w = response.W;
            viewModel.beta1 = response.Beta1;
            viewModel.beta2 = response.Beta2;
            viewModel.johnsonType = response.JohnsonType;
        }
    }
}