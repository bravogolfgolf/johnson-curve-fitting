using System;
using Responders;


namespace Johnson
{
    public class InitialPresenter : IResponder
    {
        private IView view;

        public InitialPresenter(IView view)
        {
            this.view = view;
        }

        public void Present()
        {
           view.GenerateView();
        }
    }
}