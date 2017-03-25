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

        public int NumberOfEntries { get { return DistributionProperties.NumberOfEntries(frequencies); } }

        public double N { get { return DistributionProperties.N(frequencies); } }

        public double FirstMomentAboutOrigin { get { return DistributionProperties.FirstMomentAboutOrigin(intervals, frequencies, N); } }

        public double SecondMomentAboutOrigin { get { return DistributionProperties.SecondMomentAboutOrigin(intervals, frequencies, N); } }

        public double ThirdMomentAboutOrigin { get { return DistributionProperties.ThirdMomentAboutOrigin(intervals, frequencies, N); } }

        public double FourthMomentAboutOrigin { get { return DistributionProperties.FourthMomentAboutOrigin(intervals, frequencies, N); } }

        public double SecondMomentAboutMean { get { return DistributionProperties.SecondMomentAboutMean(FirstMomentAboutOrigin, SecondMomentAboutOrigin); } }

        public double ThirdMomentAboutMean { get { return DistributionProperties.ThirdMomentAboutMean(FirstMomentAboutOrigin, SecondMomentAboutOrigin, ThirdMomentAboutOrigin); } }

        public double FourthMomentAboutMean { get { return DistributionProperties.FourthMomentAboutMean(FirstMomentAboutOrigin, SecondMomentAboutOrigin, ThirdMomentAboutOrigin, FourthMomentAboutOrigin); } }

        public double B1 { get { return DistributionProperties.B1(SecondMomentAboutMean, ThirdMomentAboutMean); } }

        public double B2 { get { return DistributionProperties.B2(SecondMomentAboutMean, FourthMomentAboutMean); } }

        public double W { get { return DistributionProperties.W(B1); } }

        public double Beta1 { get { return DistributionProperties.Beta1(W); } }

        public double Beta2 { get { return DistributionProperties.Beta2(W); } }

        public string JohnsonType { get { return DistributionProperties.JohnsonType(B2, Beta2); } }
    }
}