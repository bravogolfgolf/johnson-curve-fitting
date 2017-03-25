namespace Entities
{
    public abstract class Solution : Distribution
    {
        public abstract double[] YSeries { get; }

        public abstract double[] FunctionOfYSeries { get; }

        public abstract double[] ZEndSeries { get; }
    }
}