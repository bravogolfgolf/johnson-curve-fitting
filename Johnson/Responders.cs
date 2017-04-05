namespace Responders
{
    public interface IResponder { void GernerateView(); }

    public interface IInitialResponder : IResponder { void Present(IInitialResponse response); }

    public interface IInitialResponse
    {
        double[] Intervals { get; set; }
        double[] Frequencies { get; set; }

        double HistogramMean1stMomment { get; set; }
        double HistogramMean2ndtMomment { get; set; }
        double HistogramMean3rdMomment { get; set; }
        double HistogramMean4thMomment { get; set; }
        double HistogramN2 { get; set; }
        double HistogramN3 { get; set; }
        double HistogramN4 { get; set; }
        double HistogramB1 { get; set; }
        double HistogramB2 { get; set; }
        double HistogramW { get; set; }
        double HistogramBeta1 { get; set; }
        double HistogramBeta2 { get; set; }
        string HistogramJohnsonType { get; set; }

        double[] YSeries { get; set; }
        double[] FunctionOfYSeries { get; set; }
        double[] ZEndSeries { get; set; }
        double[] CumNormalSeries { get; set; }
        double[] GraduationSeries { get; set; }

        double SolutionMean1stMomment { get; set; }
        double SolutionMean2ndtMomment { get; set; }
        double SolutionMean3rdMomment { get; set; }
        double SolutionMean4thMomment { get; set; }
        double SolutionN2 { get; set; }
        double SolutionN3 { get; set; }
        double SolutionN4 { get; set; }
        double SolutionB1 { get; set; }
        double SolutionB2 { get; set; }
    }
}