using System;

namespace Entities
{
    public class SolutionSB : Solution
    {
        public SolutionSB(Histogram histogram, double firstY = 0.12526) : base(histogram)
        {
            CalculateFirstAndLastY(firstY);
            CalculateSeries();
        }

        private void CalculateFirstAndLastY(double firstY)
        {
            base.firstY = firstY;
            base.lastY = 1 - firstY;
        }

        private void CalculateSeries()
        {
            CalculateYSeries();
            CalculateFunctionOfYSeries();
            CalculateZEndSeries();
            CalculateCumNormalSeries();
            CalculateGraduationSeries();
        }

        private void CalculateFunctionOfYSeries()
        {
            const double UPPER_FIT = .999;
            functionOfYSeries = new double[histogram.NumberOfEntries];
            for (int i = 0; i < functionOfYSeries.Length; i++)
                functionOfYSeries[i] = Math.Log(YSeries[i] / (1 - YSeries[i]));
            if (lastY > UPPER_FIT)
                functionOfYSeries[functionOfYSeries.Length - 1] = Math.Log(UPPER_FIT / (1 - UPPER_FIT));
        }

        private void CalculateZEndSeries()
        {
            double gOpt = GOpt();
            double dOpt = DOpt();
            zEndSeries = new double[histogram.NumberOfEntries];
            double dY = YIncrement() / 2;
            for (int i = 0; i < zEndSeries.Length - 1; i++)
                zEndSeries[i] = Math.Log((YSeries[i] + dY) / (1 - (YSeries[i] + dY))) * dOpt + gOpt;
        }
    }
}