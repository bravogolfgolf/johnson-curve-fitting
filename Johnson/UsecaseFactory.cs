using System;

namespace Requestors
{
    public class Usecase { public virtual void Execute(Request request) { } }

    public class UsecaseFactory
    {
        public virtual Usecase Create(string type, object responser)
        {
            if (type.Equals("Initial"))
            {
                return (Usecase)Activator.CreateInstance(Type.GetType("Usecases.InitialUsecase"), new object[] { responser });
            }
            else
                return null;
        }
    }
}