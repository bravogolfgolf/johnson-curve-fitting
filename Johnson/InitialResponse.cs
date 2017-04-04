using Responders;

namespace Usecases
{
    public class InitialResponse : IInitialResponse
    {
        private double histogramMean1stMomment;
        private double histogramMean2ndtMomment;
        private double histogramMean3rdMomment;
        private double histogramMean4thMomment;
        private double histogramN2;
        private double histogramN3;
        private double histogramN4;
        private double histogramB1;
        private double histogramB2;
        private double histogramW;
        private double histogramBeta1;
        private double histogramBeta2;
        private string histogramJohnsonType;

        private double solutionMean1stMomment;
        private double solutionMean2ndtMomment;
        private double solutionMean3rdMomment;
        private double solutionMean4thMomment;
        private double solutionN2;
        private double solutionN3;
        private double solutionN4;
        private double solutionB1;
        private double solutionB2;


        public double HistogramMean1stMomment { get => histogramMean1stMomment; set => histogramMean1stMomment = value; }
        public double HistogramMean2ndtMomment { get => histogramMean2ndtMomment; set => histogramMean2ndtMomment = value; }
        public double HistogramMean3rdMomment { get => histogramMean3rdMomment; set => histogramMean3rdMomment = value; }
        public double HistogramMean4thMomment { get => histogramMean4thMomment; set => histogramMean4thMomment = value; }
        public double HistogramN2 { get => histogramN2; set => histogramN2 = value; }
        public double HistogramN3 { get => histogramN3; set => histogramN3 = value; }
        public double HistogramN4 { get => histogramN4; set => histogramN4 = value; }
        public double HistogramB1 { get => histogramB1; set => histogramB1 = value; }
        public double HistogramB2 { get => histogramB2; set => histogramB2 = value; }
        public double HistogramW { get => histogramW; set => histogramW = value; }
        public double HistogramBeta1 { get => histogramBeta1; set => histogramBeta1 = value; }
        public double HistogramBeta2 { get => histogramBeta2; set => histogramBeta2 = value; }
        public string HistogramJohnsonType { get => histogramJohnsonType; set => histogramJohnsonType = value; }

        public double SolutionMean1stMomment { get => solutionMean1stMomment; set => solutionMean1stMomment = value; }
        public double SolutionMean2ndtMomment { get => solutionMean2ndtMomment; set => solutionMean2ndtMomment = value; }
        public double SolutionMean3rdMomment { get => solutionMean3rdMomment; set => solutionMean3rdMomment = value; }
        public double SolutionMean4thMomment { get => solutionMean4thMomment; set => solutionMean4thMomment = value; }
        public double SolutionN2 { get => solutionN2; set => solutionN2 = value; }
        public double SolutionN3 { get => solutionN3; set => solutionN3 = value; }
        public double SolutionN4 { get => solutionN4; set => solutionN4 = value; }
        public double SolutionB1 { get => solutionB1; set => solutionB1 = value; }
        public double SolutionB2 { get => solutionB2; set => solutionB2 = value; }
    }
}