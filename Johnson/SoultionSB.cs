using System;
using System.Linq;

namespace Entities
{
    public class SoultionSB : Solution
    {
        private Histogram histogram;
        private double firstY;
        private double lastY;

        public SoultionSB(Histogram histogram, double firstY = .1253)
        {
            this.histogram = histogram;
            this.firstY = firstY;
            lastY = 1 - firstY;
        }

        public override double[] YSeries
        {
            get
            {
                double yIncrement = GetYIncrement();
                double[] ySeries = new double[histogram.NumberOfEntries];
                ySeries[0] = firstY;
                for (int i = 1; i < ySeries.Length - 1; i++)
                {
                    ySeries[i] = ySeries[i - 1] + yIncrement;
                }
                ySeries[ySeries.Length - 1] = lastY;
                return ySeries;
            }
        }

        private double GetYIncrement()
        {
            return (lastY - firstY) / (histogram.NumberOfEntries - 1);
        }

        public override double[] FunctionOfYSeries
        {
            get
            {
                const double LOWER_FIT = .001;
                double upperfit = 1 - LOWER_FIT;
                double[] functionOfYSeries = new double[histogram.NumberOfEntries];
                for (int i = 0; i < functionOfYSeries.Length; i++)
                {
                    functionOfYSeries[i] = Math.Log(YSeries[i] / (1 - YSeries[i]));
                }
                if (lastY > upperfit)
                    functionOfYSeries[functionOfYSeries.Length - 1] = Math.Log(upperfit / (1 - upperfit));
                return functionOfYSeries;
            }
        }

        public override double[] ZEndSeries
        {
            get
            {
                double[] zEndSeries = new double[histogram.NumberOfEntries];
                double dY = GetYIncrement() / 2;
                for (int i = 0; i < zEndSeries.Length - 1; i++)
                {
                    zEndSeries[i] = Math.Log((YSeries[i] + dY) / (1 - (YSeries[i] + dY))) * DOpt() + GOpt();
                }
                return zEndSeries;
            }
        }

        private double DOpt()
        {
            return 1 / SF();
        }

        private double SF()
        {
            return Math.Sqrt(SecondMomentAboutOrigin(FunctionOfYSeries, histogram.Frequencies, histogram.N) - Math.Pow(FirstMomentAboutOrigin(FunctionOfYSeries, histogram.Frequencies, histogram.N), 2));
        }

        private double GOpt()
        {
            return Math.Sign(histogram.ThirdMomentAboutMean) * Math.Abs(-FirstMomentAboutOrigin(FunctionOfYSeries, histogram.Frequencies, histogram.N) / SF());
        }

    }
}