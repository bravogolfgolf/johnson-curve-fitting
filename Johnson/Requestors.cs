namespace Requestors
{
    public interface IController
    {
        void Execute();
    }

    public interface IRequest
    {
    }

    public interface IUsecase
    {
        void Execute(IRequest request);
    }
}