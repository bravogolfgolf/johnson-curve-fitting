using System;
using System.Linq;

namespace Entities
{
    public abstract class Distribution
    {
        protected double FirstMomentAboutOrigin(double[] xSeries, double[] ySeries, double n)
        {
            return xSeries.Zip(ySeries, (x, y) => x * y).Sum() / n;
        }

        protected double SecondMomentAboutOrigin(double[] xSeries, double[] ySeries, double n)
        {
            return xSeries.Zip(ySeries, (x, y) => x * x * y).Sum() / n;
        }

        protected double ThirdMomentAboutOrigin(double[] xSeries, double[] ySeries, double n)
        {
            return xSeries.Zip(ySeries, (x, y) => x * x * x * y).Sum() / n;
        }

        protected double FourthMomentAboutOrigin(double[] xSeries, double[] ySeries, double n)
        {
            return xSeries.Zip(ySeries, (x, y) => x * x * x * x * y).Sum() / n;
        }

        protected double SecondMomentAboutMean(double firstMomentAboutOrigin, double secondMomentAboutOrigin)
        {
            return secondMomentAboutOrigin - Math.Pow(firstMomentAboutOrigin, 2);
        }

        protected double ThirdMomentAboutMean(double firstMomentAboutOrigin, double secondMomentAboutOrigin, double thirdMomentAboutOrigin)
        {
            return thirdMomentAboutOrigin - 3 * firstMomentAboutOrigin * secondMomentAboutOrigin + 2 * Math.Pow(firstMomentAboutOrigin, 3);
        }

        protected double FourthMomentAboutMean(double firstMomentAboutOrigin, double secondMomentAboutOrigin, double thirdMomentAboutOrigin, double fourthMomentAboutOrigin)
        {
            return fourthMomentAboutOrigin - 4 * firstMomentAboutOrigin * thirdMomentAboutOrigin + 6 * Math.Pow(firstMomentAboutOrigin, 2) * secondMomentAboutOrigin - 3 * Math.Pow(firstMomentAboutOrigin, 4);
        }

        protected double B1(double secondMomentAboutMean, double thirdMomentAboutMean)
        {
            return Math.Pow(thirdMomentAboutMean, 2) / Math.Pow(secondMomentAboutMean, 3);
        }

        protected double B2(double secondMomentAboutMean, double fourthMomentAboutMean)
        {
            return fourthMomentAboutMean / Math.Pow(secondMomentAboutMean, 2);
        }

        protected double W(double b1)
        {
            return (Math.Pow((1 + 0.5 * b1 + Math.Sqrt(b1 * (1 + 0.25 * b1))), (double)1 / 3) + Math.Pow((1 + 0.5 * b1 - Math.Sqrt(b1 * (1 + 0.25 * b1))), (double)1 / 3) - 1);
        }

        protected double Beta1(double w)
        {
            return (w - 1) * Math.Pow(w + 2, 2);
        }

        protected double Beta2(double w)
        {
            return Math.Pow(w, 4) + 2 * Math.Pow(w, 3) + 3 * Math.Pow(w, 2) - 3;
        }

        protected string JohnsonType(double b2, double beta2)
        {
            return (((beta2 - b2) / b2) < 0) ? "SU" : "SB";
        }
    }
}
