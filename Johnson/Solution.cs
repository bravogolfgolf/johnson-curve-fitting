namespace Entities
{
    public abstract class Solution : Distribution
    {
        public abstract double[] YSeries { get; }

        public abstract double[] FunctionOfYSeries { get; }

        public abstract double[] ZEndSeries { get; }

        public abstract double[] CumNormalSeries { get; }

        public abstract double[] GraduationSeries { get; }

        public new abstract double FirstMomentAboutOrigin { get; }

        public new abstract double SecondMomentAboutOrigin { get; }

        public new abstract double ThirdMomentAboutOrigin { get; }

        public new abstract double FourthMomentAboutOrigin { get; }

        public new abstract double SecondMomentAboutMean { get; }

        public new abstract double ThirdMomentAboutMean { get; }

        public new abstract double FourthMomentAboutMean { get; }

        public new abstract double B1 { get; }

        public new abstract double B2 { get; }
    }
}