using System;
using System.Linq;

namespace Utilities
{
    public static class Formulae
    {
        public static double FirstMomentAboutOrigin(double[] xSeries, double[] ySeries, double n)
        {
            return xSeries.Zip(ySeries, (x, y) => x * y).Sum() / n;
        }

        public static double SecondMomentAboutOrigin(double[] xSeries, double[] ySeries, double n)
        {
            return xSeries.Zip(ySeries, (x, y) => x * x * y).Sum() / n;
        }

        public static double ThirdMomentAboutOrigin(double[] xSeries, double[] ySeries, double n)
        {
            return xSeries.Zip(ySeries, (x, y) => x * x * x * y).Sum() / n;
        }

        public static double FourthMomentAboutOrigin(double[] xSeries, double[] ySeries, double n)
        {
            return xSeries.Zip(ySeries, (x, y) => x * x * x * x * y).Sum() / n;
        }

        public static double SecondMomentAboutMean(double firstMomentAboutOrigin, double secondMomentAboutOrigin)
        {
            return secondMomentAboutOrigin - Math.Pow(firstMomentAboutOrigin, 2);
        }

        public static double ThirdMomentAboutMean(double firstMomentAboutOrigin, double secondMomentAboutOrigin, double thirdMomentAboutOrigin)
        {
            return thirdMomentAboutOrigin - 3 * firstMomentAboutOrigin * secondMomentAboutOrigin + 2 * Math.Pow(firstMomentAboutOrigin, 3);
        }

        public static double FourthMomentAboutMean(double firstMomentAboutOrigin, double secondMomentAboutOrigin, double thirdMomentAboutOrigin, double fourthMomentAboutOrigin)
        {
            return fourthMomentAboutOrigin - 4 * firstMomentAboutOrigin * thirdMomentAboutOrigin + 6 * Math.Pow(firstMomentAboutOrigin, 2) * secondMomentAboutOrigin - 3 * Math.Pow(firstMomentAboutOrigin, 4);
        }

        public static double B1(double secondMomentAboutMean, double thirdMomentAboutMean)
        {
            return Math.Pow(thirdMomentAboutMean, 2) / Math.Pow(secondMomentAboutMean, 3);
        }

        public static double B2(double secondMomentAboutMean, double fourthMomentAboutMean)
        {
            return fourthMomentAboutMean / Math.Pow(secondMomentAboutMean, 2);
        }

        public static double W(double b1)
        {
            return (Math.Pow((1 + 0.5 * b1 + Math.Sqrt(b1 * (1 + 0.25 * b1))), (double)1 / 3) + Math.Pow((1 + 0.5 * b1 - Math.Sqrt(b1 * (1 + 0.25 * b1))), (double)1 / 3) - 1);
        }

        public static double Beta1(double w)
        {
            return (w - 1) * Math.Pow(w + 2, 2);
        }

        public static double Beta2(double w)
        {
            return Math.Pow(w, 4) + 2 * Math.Pow(w, 3) + 3 * Math.Pow(w, 2) - 3;
        }

        public static string JohnsonType(double b2, double beta2)
        {
            return (((beta2 - b2) / b2) < 0) ? "SU" : "SB";
        }
    }
}
