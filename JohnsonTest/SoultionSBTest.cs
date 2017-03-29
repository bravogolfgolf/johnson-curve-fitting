using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Utilites
{
    [TestClass]
    public class SoultionSBTest
    {
        private SoultionSB solution;
        private double[] intervals = { 17.0, 22.0, 27.0, 32.0, 37.0, 42.0, 47.0, 52.0, 57.0, 62.0, 67.0, 72.0, 77.0, 82.0, 87.0 };
        private double[] frequencies = { 34.0, 145.00, 156.00, 145.00, 123.00, 103.00, 86.00, 71.00, 55.00, 37.00, 21.00, 13.00, 7.00, 3.00, 1.00 };
        private Histogram histogram;

        [TestInitialize]
        public void SetUp()
        {
            histogram = new Histogram(intervals, frequencies);
            solution = new SoultionSB(histogram);
        }

        [TestMethod]
        public void ShouldReturnYSeries()
        {
            const double DELTA = .001;
            double[] actuals = { 0.1253, 0.1788, 0.2323, 0.2859, 0.3394, 0.3929, 0.4465, 0.5000, 0.5535, 0.6071, 0.6606, 0.7141, 0.7677, 0.8212, 0.8747 };
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
            double[] actuals = { -1.9435, -1.5245, -1.1952, -0.9156, -0.6660, -0.4350, -0.2150, 0.0000, 0.2150, 0.4350, 0.6660, 0.9156, 1.1952, 1.5245, 1.9435 };
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
            double[] actuals = { -1.5078, -0.9737, -0.5353, -0.1528, 0.1953, 0.5223, 0.8379, 1.1499, 1.4655, 1.7925, 2.1406, 2.5231, 2.9615, 3.4955 };
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
            double[] actuals = { 65.80826973, 165.0911167, 296.2093789, 439.2760865, 577.4066435, 699.2704114, 798.958707, 874.9026213, 928.6051056, 963.4751971, 983.8463991, 994.1840372, 998.4694315, 999.7634499, 1000 };
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
            double[] actuals = { 65.80826973, 99.282847, 131.1182621, 143.0667076, 138.130557, 121.8637679, 99.68829561, 75.94391428, 53.70248429, 34.87009146, 20.371202, 10.33763811, 4.285394256, 1.294018402, 0.236550142 };
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
            Assert.AreEqual(0.350892728, solution.FirstMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnSecondMomentAboutOrigin()
        {
            const double DELTA = .001;
            Assert.AreEqual(0.14360458, solution.SecondMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnThirdMomentAboutOrigin()
        {
            const double DELTA = .001;
            Assert.AreEqual(0.066201943, solution.ThirdMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnFourthMomentAboutOrigin()
        {
            const double DELTA = .001;
            Assert.AreEqual(0.033461382, solution.FourthMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnSecondMomentOfAboutMean()
        {
            const double DELTA = .001;
            Assert.AreEqual(0.020478873, solution.SecondMomentAboutMean, DELTA);
        }

        [TestMethod]
        public void ShouldReturnThirdMomentOfAboutMean()
        {
            const double DELTA = .001;
            Assert.AreEqual(0.001440364, solution.ThirdMomentAboutMean, DELTA);
        }

        [TestMethod]
        public void ShouldReturnFourthMomentOfAboutMean()
        {
            const double DELTA = .001;
            Assert.AreEqual(0.001150935, solution.FourthMomentAboutMean, DELTA);
        }

        [TestMethod]
        public void ShouldReturnB1()
        {
            const double DELTA = .001;
            Assert.AreEqual(0.24156084, solution.B1, DELTA);
        }

        [TestMethod]
        public void ShouldReturnB2()
        {
            const double DELTA = .001;
            Assert.AreEqual(2.744344162, solution.B2, DELTA);
        }
    }
}
