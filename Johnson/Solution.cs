namespace Utilites
{
    public abstract class Solution
    {
        public abstract double[] YSeries { get; }

        public abstract double[] FunctionOfYSeries { get; }

        public abstract double[] ZEndSeries { get; }

        public abstract double[] CumNormalSeries { get; }

        public abstract double[] GraduationSeries { get; }

        public abstract double FirstMomentAboutOrigin { get; }

        public abstract double SecondMomentAboutOrigin { get; }

        public abstract double ThirdMomentAboutOrigin { get; }

        public abstract double FourthMomentAboutOrigin { get; }

        public abstract double SecondMomentAboutMean { get; }

        public abstract double ThirdMomentAboutMean { get; }

        public abstract double FourthMomentAboutMean { get; }

        public abstract double B1 { get; }

        public abstract double B2 { get; }
    }
}