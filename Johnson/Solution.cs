using System;
using Utilities;

namespace Entities
{
    public class Solution
    {
        protected Histogram histogram;
        protected double firstY;
        protected double lastY;
        protected double[] ySeries;
        protected double[] functionOfYSeries;
        protected double[] zEndSeries;
        protected double[] cumNormalSeries;
        protected double[] graduationSeries;

        public Solution(Histogram histogram)
        {
            this.histogram = histogram;
        }

        public double[] YSeries
        { get { return ySeries; } }

        public double[] FunctionOfYSeries
        { get { return functionOfYSeries; } }

        public double[] ZEndSeries
        { get { return zEndSeries; } }

        public double[] CumNormalSeries
        { get { return cumNormalSeries; } }

        public double[] GraduationSeries { get { return graduationSeries; } }

        public double FirstMomentAboutOrigin
        { get { return Formulae.FirstMomentAboutOrigin(YSeries, GraduationSeries, histogram.N); } }

        public double SecondMomentAboutOrigin
        { get { return Formulae.SecondMomentAboutOrigin(YSeries, GraduationSeries, histogram.N); } }

        public double ThirdMomentAboutOrigin
        { get { return Formulae.ThirdMomentAboutOrigin(YSeries, GraduationSeries, histogram.N); } }

        public double FourthMomentAboutOrigin
        { get { return Formulae.FourthMomentAboutOrigin(YSeries, GraduationSeries, histogram.N); } }

        public double SecondMomentAboutMean
        { get { return Formulae.SecondMomentAboutMean(FirstMomentAboutOrigin, SecondMomentAboutOrigin); } }

        public double ThirdMomentAboutMean
        { get { return Formulae.ThirdMomentAboutMean(FirstMomentAboutOrigin, SecondMomentAboutOrigin, ThirdMomentAboutOrigin); } }

        public double FourthMomentAboutMean
        { get { return Formulae.FourthMomentAboutMean(FirstMomentAboutOrigin, SecondMomentAboutOrigin, ThirdMomentAboutOrigin, FourthMomentAboutOrigin); } }

        public double B1
        { get { return Formulae.B1(SecondMomentAboutMean, ThirdMomentAboutMean); } }

        public double B2
        { get { return Formulae.B2(SecondMomentAboutMean, FourthMomentAboutMean); } }

        protected void CalculateYSeries()
        {
            double yIncrement = YIncrement();
            ySeries = new double[histogram.NumberOfEntries];
            ySeries[0] = firstY;
            for (int i = 1; i < ySeries.Length - 1; i++)
                ySeries[i] = ySeries[i - 1] + yIncrement;
            ySeries[ySeries.Length - 1] = lastY;
        }

        protected double YIncrement()
        {
            return (lastY - firstY) / (histogram.NumberOfEntries - 1);
        }

        protected double DOpt()
        {
            return 1 / SF();
        }

        protected double SF()
        {
            return Math.Sqrt(Formulae.SecondMomentAboutOrigin(FunctionOfYSeries, histogram.Frequencies, histogram.N) - Math.Pow(Formulae.FirstMomentAboutOrigin(FunctionOfYSeries, histogram.Frequencies, histogram.N), 2));
        }

        protected double GOpt()
        {
            return Math.Sign(histogram.ThirdMomentAboutMean) * Math.Abs(-Formulae.FirstMomentAboutOrigin(FunctionOfYSeries, histogram.Frequencies, histogram.N) / SF());
        }

        protected void CalculateCumNormalSeries()
        {
            double n = histogram.N;
            cumNormalSeries = new double[histogram.NumberOfEntries];
            for (int i = 0; i < cumNormalSeries.Length - 1; i++)
                cumNormalSeries[i] = NormalDistributon(ZEndSeries[i]) * n;
            cumNormalSeries[cumNormalSeries.Length - 1] = n;
        }

        private double NormalDistributon(double zEnd)
        {
            return 0.5 * (1.0 + (Math.Sign(zEnd) * ErrorFunction(Math.Abs(zEnd) / Math.Sqrt(2.0))));
        }

        private double ErrorFunction(double x)
        {
            const double a1 = 0.254829592;
            const double a2 = -0.284496736;
            const double a3 = 1.421413741;
            const double a4 = -1.453152027;
            const double a5 = 1.061405429;
            const double p = 0.3275911;

            double t = 1 / (1 + p * x);
            return 1 - ((((((a5 * t + a4) * t) + a3) * t + a2) * t) + a1) * t * Math.Exp(-1 * Math.Pow(x, 2));
        }

        protected void CalculateGraduationSeries()
        {
            graduationSeries = new double[histogram.NumberOfEntries];
            graduationSeries[0] = CumNormalSeries[0];
            for (int i = 1; i < graduationSeries.Length; i++)
                graduationSeries[i] = CumNormalSeries[i] - CumNormalSeries[i - 1];
        }
    }
}