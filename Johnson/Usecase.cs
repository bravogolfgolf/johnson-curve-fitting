using System;
using Requests;

namespace Usecases
{
    public interface IUsecase
    {
        void Execute(IRequest request);
    }

    public class InitialUsecase : IUsecase
    {
        public void Execute(IRequest request)
        {
            throw new NotImplementedException();
        }
    }
}