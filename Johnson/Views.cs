using System;

namespace Johnson
{
    public interface IView
    {
         void GenerateView();
    }

    public class InitialView : IView
    {
        public void GenerateView()
        {
            throw new NotImplementedException();
        }
    }
}
