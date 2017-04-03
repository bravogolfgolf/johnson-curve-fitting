using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entities
{
    [TestClass]
    public class SoultionSUTest
    {
        private SolutionSU solution;
        private double[] intervals = { 2875, 3025, 3175, 3325, 3475, 3625, 3775, 3925, 4075, 4225, 4375, 4525, 4675, 4825, 4975, 5125, 5275, 5425, 5575, 5725 };
        private double[] frequencies = { 2, 1, 0, 1, 1, 8, 3, 8, 15, 19, 31, 21, 31, 27, 18, 9, 2, 1, 1, 1 };
        private Histogram histogram;

        [TestInitialize]
        public void SetUp()
        {
            histogram = new Histogram(intervals, frequencies);
            solution = new SolutionSU(histogram);
        }

        [TestMethod]
        public void ShouldReturnYSeries()
        {
            const double DELTA = .001;
            double[] actuals = { -2.2334, -1.9983, -1.7632, -1.5281, -1.2930, -1.0579, -0.8228, -0.5877, -0.3526, -0.1175, 0.1175, 0.3526, 0.5877, 0.8228, 1.0579, 1.2930, 1.5281, 1.7632, 1.9983, 2.2334 };
            double[] ySeries = solution.YSeries;
            for (int i = 0; i < ySeries.Length; i++)
            {
                Assert.AreEqual(actuals[i], ySeries[i], DELTA);
            }
        }

        [TestMethod]
        public void ShouldReturnFunctionOfYSeries()
        {
            const double DELTA = .001;
            double[] actuals = { -1.5434, -1.4429, -1.3324, -1.2103, -1.0742, -0.9218, -0.7504, -0.5583, -0.3457, -0.1173, 0.1173, 0.3457, 0.5583, 0.7504, 0.9218, 1.0742, 1.2103, 1.3324, 1.4429, 1.5434 };
            double[] functionOfYSeries = solution.FunctionOfYSeries;
            for (int i = 0; i < functionOfYSeries.Length; i++)
            {
                Assert.AreEqual(actuals[i], functionOfYSeries[i], DELTA);
            }
        }

        [TestMethod]
        public void ShouldReturnZEndSeries()
        {
            const double DELTA = .001;
            double[] actuals = { -2.0616, -1.8849, -1.6902, -1.4740, -1.2325, -0.9613, -0.6566, -0.3166, 0.0549, 0.4459, 0.8368, 1.2084, 1.5483, 1.8531, 2.1242, 2.3657, 2.5819, 2.7767, 2.9533 };
            double[] zEndSeries = solution.ZEndSeries;
            for (int i = 0; i < zEndSeries.Length - 1; i++)
            {
                Assert.AreEqual(actuals[i], zEndSeries[i], DELTA);
            }
        }

        [TestMethod]
        public void ShouldReturnCumNormalSeries()
        {
            const double DELTA = .1;
            double[] actuals = { 3.92, 5.94, 9.10, 14.05, 21.78, 33.64, 51.14, 75.15, 104.38, 134.43, 159.73, 177.31, 187.85, 193.61, 196.63, 198.20, 199.02, 199.45, 199.69, 200.00 };
            double[] cumNormalSeries = solution.CumNormalSeries;
            for (int i = 0; i < cumNormalSeries.Length - 1; i++)
            {
                Assert.AreEqual(actuals[i], cumNormalSeries[i], DELTA);
            }
        }

        [TestMethod]
        public void ShouldReturnGraduationSeries()
        {
            const double DELTA = .01;
            double[] actuals = { 3.92, 2.02, 3.16, 4.95, 7.73, 11.86, 17.50, 24.01, 29.23, 30.05, 25.30, 17.58, 10.54, 5.77, 3.02, 1.57, 0.82, 0.43, 0.23, 0.31 };
            double[] graduationSeries = solution.GraduationSeries;
            for (int i = 0; i < graduationSeries.Length - 1; i++)
            {
                Assert.AreEqual(actuals[i], graduationSeries[i], DELTA);
            }
        }

        [TestMethod]
        public void ShouldReturnFirstMomentAboutOrigin()
        {
            const double DELTA = .001;
            Assert.AreEqual(-0.3115, solution.FirstMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnSecondMomentAboutOrigin()
        {
            const double DELTA = .001;
            Assert.AreEqual(0.6062, solution.SecondMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnThirdMomentAboutOrigin()
        {
            const double DELTA = .001;
            Assert.AreEqual(-0.5886, solution.ThirdMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnFourthMomentAboutOrigin()
        {
            const double DELTA = .001;
            Assert.AreEqual(1.3385, solution.FourthMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnSecondMomentOfAboutMean()
        {
            const double DELTA = .001;
            Assert.AreEqual(0.5092, solution.SecondMomentAboutMean, DELTA);
        }

        [TestMethod]
        public void ShouldReturnThirdMomentOfAboutMean()
        {
            const double DELTA = .001;
            Assert.AreEqual(-0.0825, solution.ThirdMomentAboutMean, DELTA);
        }

        [TestMethod]
        public void ShouldReturnFourthMomentOfAboutMean()
        {
            const double DELTA = .001;
            Assert.AreEqual(0.9298, solution.FourthMomentAboutMean, DELTA);
        }

        [TestMethod]
        public void ShouldReturnB1()
        {
            const double DELTA = .001;
            Assert.AreEqual(0.0515, solution.B1, DELTA);
        }

        [TestMethod]
        public void ShouldReturnB2()
        {
            const double DELTA = .001;
            Assert.AreEqual(3.5867, solution.B2, DELTA);
        }
    }
}
