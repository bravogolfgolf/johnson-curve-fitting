using Usecases;
namespace Responders
{
    public interface IInitialResponder
    {
        void Present(IInitialResponse response);
    }

    public interface IInitialResponse
    {
        double[] Intervals { get; set; }
        double[] Frequencies { get; set; }
        double Mean1stMomment { get; set; }
        double Mean2ndtMomment { get; set; }
        double Mean3rdMomment { get; set; }
        double Mean4thMomment { get; set; }
        double N2 { get; set; }
        double N3 { get; set; }
        double N4 { get; set; }
        double B1 { get; set; }
        double B2 { get; set; }
        double W { get; set; }
        double Beta1 { get; set; }
        double Beta2 { get; set; }
        double LeastSquare { get; set; }
        string JohnsonType { get; set; }
        string PearsonType { get; set; }
        string Shape { get; set; }
    }
}