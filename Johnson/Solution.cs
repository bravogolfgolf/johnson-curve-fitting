using System;
using System.Linq;

namespace Entities
{
    public abstract class Solution
    {
        protected double[] frequencies;

        public Solution(double[] frequencies)
        {
            this.frequencies = frequencies;
        }

        public int NumberOfEntries
        {
            get
            {
                return frequencies.Length;
            }
        }

        public double N
        {
            get
            {
                return frequencies.Sum();
            }
        }

        public abstract double[] YSeries { get; }

        public abstract double[] FunctionOfYSeries { get; }

        public abstract double[] ZEndSeries { get; }

        public abstract double FirstMomentAboutOrigin();
    }
}