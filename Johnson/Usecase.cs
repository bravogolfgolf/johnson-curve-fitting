namespace Usecases
{
    public interface IUsecase
    {
        void Execute();
    }

    public class InitialUsecase : IUsecase
    {
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}