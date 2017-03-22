using Responders;
using Usecases;

namespace Requestors
{
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