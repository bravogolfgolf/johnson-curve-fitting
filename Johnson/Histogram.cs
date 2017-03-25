using System.Linq;

namespace Entities
{
    public class Histogram : Distribution
    {
        private double[] intervals;
        private double[] frequencies;

        public Histogram(double[] intervals, double[] frequencies)
        {
            this.intervals = intervals;
            this.frequencies = frequencies;
        }

        public double[] Frequencies { get { return frequencies; } }

        public int NumberOfEntries
        { get { return frequencies.Length; } }

        public double N
        { get { return frequencies.Sum(); } }

        public new double FirstMomentAboutOrigin
        { get { return FirstMomentAboutOrigin(intervals, frequencies, N); } }

        public new double SecondMomentAboutOrigin
        { get { return SecondMomentAboutOrigin(intervals, frequencies, N); } }

        public new double ThirdMomentAboutOrigin
        { get { return ThirdMomentAboutOrigin(intervals, frequencies, N); } }

        public new double FourthMomentAboutOrigin
        { get { return FourthMomentAboutOrigin(intervals, frequencies, N); } }

        public new double SecondMomentAboutMean
        { get { return SecondMomentAboutMean(FirstMomentAboutOrigin, SecondMomentAboutOrigin); } }

        public new double ThirdMomentAboutMean
        { get { return ThirdMomentAboutMean(FirstMomentAboutOrigin, SecondMomentAboutOrigin, ThirdMomentAboutOrigin); } }

        public new double FourthMomentAboutMean
        { get { return FourthMomentAboutMean(FirstMomentAboutOrigin, SecondMomentAboutOrigin, ThirdMomentAboutOrigin, FourthMomentAboutOrigin); } }

        public new double B1
        { get { return B1(SecondMomentAboutMean, ThirdMomentAboutMean); } }

        public new double B2
        { get { return B2(SecondMomentAboutMean, FourthMomentAboutMean); } }

        public new double W
        { get { return W(B1); } }

        public new double Beta1
        { get { return Beta1(W); } }

        public new double Beta2
        { get { return Beta2(W); } }

        public new string JohnsonType
        { get { return JohnsonType(B2, Beta2); } }
    }
}