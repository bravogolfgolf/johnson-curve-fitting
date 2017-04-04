using System;
using Utilities;

namespace Entities
{
    public class SolutionSB : Solution
    {
        private Histogram histogram;
        private double firstY;
        private double lastY;
        private double[] ySeries;
        private double[] functionOfYSeries;
        private double[] zEndSeries;
        private double[] cumNormalSeries;
        private double[] graduationSeries;

        public SolutionSB(Histogram histogram, double firstY = 0.12526)
        {
            this.histogram = histogram;
            this.firstY = firstY;
            lastY = 1 - firstY;
            CalculateYSeries();
            CalculateFunctionOfYSeries();
            CalculateZEndSeries();
            CalculateCumNormalSeries();
            CalculateGraduationSeries();
        }

        private void CalculateYSeries()
        {
            double yIncrement = YIncrement();
            ySeries = new double[histogram.NumberOfEntries];
            ySeries[0] = firstY;
            for (int i = 1; i < ySeries.Length - 1; i++)
            {
                ySeries[i] = ySeries[i - 1] + yIncrement;
            }
            ySeries[ySeries.Length - 1] = lastY;

        }

        public override double[] YSeries
        {
            get
            {
                return ySeries;
            }
        }

        private double YIncrement()
        {
            return (lastY - firstY) / (histogram.NumberOfEntries - 1);
        }

        private void CalculateFunctionOfYSeries()
        {
            const double LOWER_FIT = .001;
            double upperfit = 1 - LOWER_FIT;
            functionOfYSeries = new double[histogram.NumberOfEntries];
            for (int i = 0; i < functionOfYSeries.Length; i++)
            {
                functionOfYSeries[i] = Math.Log(YSeries[i] / (1 - YSeries[i]));
            }
            if (lastY > upperfit)
                functionOfYSeries[functionOfYSeries.Length - 1] = Math.Log(upperfit / (1 - upperfit));

        }

        public override double[] FunctionOfYSeries
        {
            get
            {
                return functionOfYSeries;
            }
        }

        private void CalculateZEndSeries()
        {
            zEndSeries = new double[histogram.NumberOfEntries];
            double dY = YIncrement() / 2;
            for (int i = 0; i < zEndSeries.Length - 1; i++)
            {
                zEndSeries[i] = Math.Log((YSeries[i] + dY) / (1 - (YSeries[i] + dY))) * DOpt() + GOpt();
            }

        }

        public override double[] ZEndSeries
        {
            get
            {
                return zEndSeries;
            }
        }

        private double DOpt()
        {
            return 1 / SF();
        }

        private double SF()
        {
            return Math.Sqrt(Formulae.SecondMomentAboutOrigin(FunctionOfYSeries, histogram.Frequencies, histogram.N) - Math.Pow(Formulae.FirstMomentAboutOrigin(FunctionOfYSeries, histogram.Frequencies, histogram.N), 2));
        }

        private double GOpt()
        {
            return Math.Sign(histogram.ThirdMomentAboutMean) * Math.Abs(-Formulae.FirstMomentAboutOrigin(FunctionOfYSeries, histogram.Frequencies, histogram.N) / SF());
        }

        private void CalculateCumNormalSeries()
        {
            cumNormalSeries = new double[histogram.NumberOfEntries];
            for (int i = 0; i < cumNormalSeries.Length - 1; i++)
            {
                cumNormalSeries[i] = NormalDistributon(ZEndSeries[i]) * histogram.N;
            }
            cumNormalSeries[cumNormalSeries.Length - 1] = histogram.N;

        }

        public override double[] CumNormalSeries
        {
            get
            {
                return cumNormalSeries;
            }
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

        private void CalculateGraduationSeries()
        {
            graduationSeries = new double[histogram.NumberOfEntries];
            graduationSeries[0] = CumNormalSeries[0];
            for (int i = 1; i < graduationSeries.Length; i++)
            {
                graduationSeries[i] = CumNormalSeries[i] - CumNormalSeries[i - 1];
            }
        }

        public override double[] GraduationSeries
        {
            get
            {
                return graduationSeries;
            }
        }

        public override double FirstMomentAboutOrigin
        { get { return Formulae.FirstMomentAboutOrigin(YSeries, GraduationSeries, histogram.N); } }

        public override double SecondMomentAboutOrigin
        { get { return Formulae.SecondMomentAboutOrigin(YSeries, GraduationSeries, histogram.N); } }

        public override double ThirdMomentAboutOrigin
        { get { return Formulae.ThirdMomentAboutOrigin(YSeries, GraduationSeries, histogram.N); } }

        public override double FourthMomentAboutOrigin
        { get { return Formulae.FourthMomentAboutOrigin(YSeries, GraduationSeries, histogram.N); } }

        public override double SecondMomentAboutMean
        { get { return Formulae.SecondMomentAboutMean(FirstMomentAboutOrigin, SecondMomentAboutOrigin); } }

        public override double ThirdMomentAboutMean
        { get { return Formulae.ThirdMomentAboutMean(FirstMomentAboutOrigin, SecondMomentAboutOrigin, ThirdMomentAboutOrigin); } }

        public override double FourthMomentAboutMean
        { get { return Formulae.FourthMomentAboutMean(FirstMomentAboutOrigin, SecondMomentAboutOrigin, ThirdMomentAboutOrigin, FourthMomentAboutOrigin); } }

        public override double B1
        { get { return Formulae.B1(SecondMomentAboutMean, ThirdMomentAboutMean); } }

        public override double B2
        { get { return Formulae.B2(SecondMomentAboutMean, FourthMomentAboutMean); } }
    }
}