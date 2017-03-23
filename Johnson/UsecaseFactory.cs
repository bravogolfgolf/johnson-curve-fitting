using Responders;
using Usecases;

namespace Requestors
{
    public class Usecase
    {
        public virtual void Execute(Request request) {; }
    }

    public class UsecaseFactory
    {
        public virtual Usecase Create(string type, IInitialResponder responser)
        {
            if (type.Equals("Initial"))
                return new InitialUsecase(responser);
            else
                return null;
        }
    }
}