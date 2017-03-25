using System;
using System.Linq;

namespace Entities
{
    public class SoultionSB : Solution
    {
        private double firstY;
        private double lastY;

        public SoultionSB(double[] frequencies, double firstY = .1253) : base(frequencies)
        {
            this.firstY = firstY;
            lastY = 1 - firstY;
        }

        public override double FirstMomentAboutOrigin()
        {
            return DistributionProperties.FirstMomentAboutOrigin(YSeries, frequencies, N);
        }

        public override double[] YSeries
        {
            get
            {
                double yIncrement = GetYIncrement();
                double[] ySeries = new double[frequencies.Length];
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
            return (lastY - firstY) / (NumberOfEntries - 1);
        }

        public override double[] FunctionOfYSeries
        {
            get
            {
                const double LOWER_FIT = .001;
                double upperfit = 1 - LOWER_FIT;
                double[] functionOfYSeries = new double[frequencies.Length];
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
                double[] zEndSeries = new double[frequencies.Length];
                double dY = GetYIncrement() / 2;
                for (int i = 0; i < zEndSeries.Length - 1; i++)
                {
                    zEndSeries[i] = Math.Log((YSeries[i] + dY) / (1 - (YSeries[i] + dY)));
                }
                return zEndSeries;
            }
        }
    }
}