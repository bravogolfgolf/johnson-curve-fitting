using System.Linq;
using Utilities;

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

        public double[] Intervals { get { return intervals; } }

        public double[] Frequencies { get { return frequencies; } }

        public int NumberOfEntries
        { get { return frequencies.Length; } }

        public double N
        { get { return frequencies.Sum(); } }

        public double FirstMomentAboutOrigin
        { get { return Formulae.FirstMomentAboutOrigin(intervals, frequencies, N); } }

        public double SecondMomentAboutOrigin
        { get { return Formulae.SecondMomentAboutOrigin(intervals, frequencies, N); } }

        public double ThirdMomentAboutOrigin
        { get { return Formulae.ThirdMomentAboutOrigin(intervals, frequencies, N); } }

        public double FourthMomentAboutOrigin
        { get { return Formulae.FourthMomentAboutOrigin(intervals, frequencies, N); } }

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

        public double W
        { get { return Formulae.W(B1); } }

        public double Beta1
        { get { return Formulae.Beta1(W); } }

        public double Beta2
        { get { return Formulae.Beta2(W); } }

        public string JohnsonType
        { get { return Formulae.JohnsonType(B2, Beta2); } }
    }
}