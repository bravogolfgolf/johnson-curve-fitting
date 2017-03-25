using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entities
{
    [TestClass]
    public class SoultionSBTest
    {
        Entities.SoultionSB solution;
        double[] frequencies = { 34.0, 145.00, 156.00, 145.00, 123.00, 103.00, 86.00, 71.00, 55.00, 37.00, 21.00, 13.00, 7.00, 3.00, 1.00 };


        [TestInitialize]
        public void SetUp()
        {
            solution = new Entities.SoultionSB(frequencies);
        }

        [TestMethod]
        public void ShouldReturnNumberOfEntriesOfFrequencies()
        {
            Assert.AreEqual(15, solution.NumberOfEntries);
        }

        [TestMethod]
        public void ShouldReturnSumOfEntriesOfFrequencies()
        {
            Assert.AreEqual(1000, solution.N);
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
        [Ignore]
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
        [Ignore]
        public void ShouldReturnFirstMomentAboutOrigin()
        {
            Assert.AreEqual(37.8750, solution.FirstMomentAboutOrigin());
        }
    }
}
