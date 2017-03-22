using System;
using Responders;
using Usecases;

namespace Johnson
{
    public class InitialPresenter : IInitialResponder
    {
        private IView view;

        public InitialPresenter(IView view)
        {
            this.view = view;
        }

        public void Present(IInitialResponse response)
        {
            view.GenerateView();
        }
    }
}