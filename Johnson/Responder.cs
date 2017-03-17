using System;

namespace Responders
{
    public interface IResponder
    {
        void Present();
    }

    public class InitialResponder : IResponder
    {
        public void Present()
        {
            throw new NotImplementedException();
        }
    }
}