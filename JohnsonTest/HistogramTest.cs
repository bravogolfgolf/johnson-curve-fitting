using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entities
{
    [TestClass]
    public class HistogramTest
    {
        private Histogram histogram;

        [TestInitialize]
        public void SetUp()
        {
            double[] intervals = { 2875, 3025, 3175, 3325, 3475, 3625, 3775, 3925, 4075, 4225, 4375, 4525, 4675, 4825, 4975, 5125, 5275, 5425, 5575, 5725 };
            double[] frequencies = { 2, 1, 0, 1, 1, 8, 3, 8, 15, 19, 31, 21, 31, 27, 18, 9, 2, 1, 1, 1 };
            histogram = new Histogram(intervals, frequencies);

        }

        [TestMethod]
        public void ShouldReturnNumberOfEntriesOfFrequencies()
        {
            Assert.AreEqual(20, histogram.NumberOfEntries);
        }

        [TestMethod]
        public void ShouldReturnSumOfEntriesOfFrequencies()
        {
            Assert.AreEqual(200, histogram.N);
        }

        [TestMethod]
        public void ShouldReturnFirstMomentAboutOrigin()
        {
            Assert.AreEqual(4487.5, histogram.FirstMomentAboutOrigin);
        }

        [TestMethod]
        public void ShouldReturnSecondMomentAboutOrigin()
        {
            Assert.AreEqual(20342350, histogram.SecondMomentAboutOrigin);
        }

        [TestMethod]
        public void ShouldReturnThirdMomentAboutOrigin()
        {
            Assert.AreEqual(93060609062.5, histogram.ThirdMomentAboutOrigin);
        }

        [TestMethod]
        public void ShouldReturnFourthMomentAboutOrigin()
        {
            const double DELTA = .1;
            Assert.AreEqual(429308429921875.0, histogram.FourthMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnSecondMomentOfAboutMean()
        {
            Assert.AreEqual(204693.75, histogram.SecondMomentAboutMean);
        }

        [TestMethod]
        public void ShouldReturnThirdMomentOfAboutMean()
        {
            Assert.AreEqual(-62812968.75, histogram.ThirdMomentAboutMean);
        }

        [TestMethod]
        public void ShouldReturnFourthMomentOfAboutMean()
        {
            Assert.AreEqual(178409223632.75, histogram.FourthMomentAboutMean);
        }

        [TestMethod]
        public void ShouldReturnB1()
        {
            const double DELTA = .001;
            Assert.AreEqual(0.460028664027421, histogram.B1, DELTA);
        }

        [
            TestMethod]
        public void ShouldReturnB2()
        {
            const double DELTA = .001;
            Assert.AreEqual(4.25802432972137, histogram.B2, DELTA);
        }

        [TestMethod]
        public void ShouldReturnW()
        {
            const double DELTA = .001;
            Assert.AreEqual(1.04946936586057, histogram.W, DELTA);
        }

        [TestMethod]
        public void ShouldReturnBeta1()
        {
            const double DELTA = .001;
            Assert.AreEqual(0.460028664027421, histogram.Beta1, DELTA);
        }

        [TestMethod]
        public void ShouldReturnBeta2()
        {
            const double DELTA = .001;
            Assert.AreEqual(3.828950489, histogram.Beta2, DELTA);
        }

        [TestMethod]
        public void ShouldReturnJohnsonType()
        {
            Assert.AreEqual("SU", histogram.JohnsonType);
        }
    }
}