using System;
using System.Linq;
using System.Collections.Generic;

namespace Entities
{
    public class SolutionSU : Solution
    {
        public SolutionSU(Histogram histogram, double lastY = 2.2334) : base(histogram)
        {
            CalculateFirstAndLastY(lastY);
            CalculateSeries();

            CalculateFirstAndLastY(lastY, ModeDifference());
            CalculateSeries();
        }


        private void CalculateFirstAndLastY(double lastY, double modeDifference = 0)
        {
            base.firstY = modeDifference - lastY;
            base.lastY = modeDifference + lastY;
        }

        private void CalculateSeries()
        {
            CalculateYSeries();
            CalculateFunctionOfYSeries();
            CalculateZEndSeries();
            CalculateCumNormalSeries();
            CalculateGraduationSeries();
        }

        private double ModeDifference()
        {
            return GraduationSeriesMode() - FrequenciesMode();
        }

        private double GraduationSeriesMode()
        {
            return YSeries[MaxGradIndex()];
        }

        private int MaxGradIndex()
        {
            return GraduationSeries.ToList().IndexOf(MaxGrad());
        }

        private double MaxGrad()
        {
            return GraduationSeries.Max();
        }

        private double FrequenciesMode()
        {
            List<int> maxFrequencyIndices = MaxFrequencyIndices();
            double sum = 0;
            foreach (int i in maxFrequencyIndices)
                sum = sum + YSeries[i];
            return sum / maxFrequencyIndices.Count;
        }

        private List<int> MaxFrequencyIndices()
        {
            double maxFrequency = MaxFrequency();
            List<int> maxFrequencyIndicesSeries = new List<int>();
            for (int i = 0; i < histogram.Frequencies.Length; i++)
                if (histogram.Frequencies[i] == maxFrequency)
                    maxFrequencyIndicesSeries.Add(i);
            return maxFrequencyIndicesSeries;
        }

        private double MaxFrequency()
        {
            return histogram.Frequencies.Max();
        }

        private void CalculateFunctionOfYSeries()
        {
            functionOfYSeries = new double[histogram.NumberOfEntries];
            for (int i = 0; i < functionOfYSeries.Length; i++)
                functionOfYSeries[i] = Math.Log(YSeries[i] + Math.Sqrt(YSeries[i] * YSeries[i] + 1));
        }

        private void CalculateZEndSeries()
        {
            double gOpt = -GOpt();
            double dOpt = DOpt();
            zEndSeries = new double[histogram.NumberOfEntries];
            double dY = YIncrement() / 2.0;
            for (int i = 0; i < zEndSeries.Length - 1; i++)
                zEndSeries[i] = Math.Log((YSeries[i] + dY) + Math.Sqrt((YSeries[i] + dY) * (YSeries[i] + dY) + 1)) * dOpt + gOpt;
        }
    }
}