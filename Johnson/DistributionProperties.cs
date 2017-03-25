using System.Linq;

namespace Entities
{
    public static class DistributionProperties
    {
        public static double FirstMomentAboutOrigin(double[] xSeries, double[]ySeries, double n)
        {
            return xSeries.Zip(ySeries, (x, y) => x * y).Sum() / n;
        }
    }
}
