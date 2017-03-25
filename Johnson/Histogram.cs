using System;
using System.Linq;

namespace Entities
{
    public class Histogram
    {
        private double[] intervals;
        private double[] frequencies;

        public Histogram(double[] intervals, double[] frequencies)
        {
            this.intervals = intervals;
            this.frequencies = frequencies;
        }

        public int NumberOfEntries() { return frequencies.Length; }

        public double N { get { return frequencies.Sum(); } }

        public double FirstMomentAboutOrigin() { return DistributionProperties.FirstMomentAboutOrigin(intervals, frequencies, N); }

        public double SecondMomentAboutOrigin() { return intervals.Zip(frequencies, (i, f) => i * i * f).Sum() / N; }

        public double ThirdMomentAboutOrigin() { return intervals.Zip(frequencies, (i, f) => i * i * i * f).Sum() / N; }

        public double FourthMomentAboutOrigin() { return intervals.Zip(frequencies, (i, f) => i * i * i * i * f).Sum() / N; }

        public double SecondMomentAboutMean() { return SecondMomentAboutOrigin() - System.Math.Pow(FirstMomentAboutOrigin(), 2); }

        public double ThirdMomentAboutMean() { return ThirdMomentAboutOrigin() - 3 * FirstMomentAboutOrigin() * SecondMomentAboutOrigin() + 2 * System.Math.Pow(FirstMomentAboutOrigin(), 3); }

        public double FourthMomentAboutMean() { return FourthMomentAboutOrigin() - 4 * FirstMomentAboutOrigin() * ThirdMomentAboutOrigin() + 6 * System.Math.Pow(FirstMomentAboutOrigin(), 2) * SecondMomentAboutOrigin() - 3 * System.Math.Pow(FirstMomentAboutOrigin(), 4); }

        public double B1() { return System.Math.Pow(ThirdMomentAboutMean(), 2) / System.Math.Pow(SecondMomentAboutMean(), 3); }

        public double B2() { return FourthMomentAboutMean() / System.Math.Pow(SecondMomentAboutMean(), 2); }

        public double W() { return (Math.Pow((1 + 0.5 * B1() + Math.Sqrt(B1() * (1 + 0.25 * B1()))), .333333) + Math.Pow((1 + 0.5 * B1() - Math.Sqrt(B1() * (1 + 0.25 * B1()))), .333333) - 1); }

        public double Beta1() { return (W() - 1) * Math.Pow(W() + 2, 2); }

        public double Beta2() { return Math.Pow(W(), 4) + 2 * Math.Pow(W(), 3) + 3 * Math.Pow(W(), 2) - 3; }

        public string JohnsonType() { return (((Beta2() - B2()) / B2()) < 0) ? "SU" : "SB"; }
    }
}