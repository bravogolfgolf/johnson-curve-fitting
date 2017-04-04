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
            const double DELTA = .0001;
            double[] actuals = { -2.7036136842105300, -2.4685168421052600, -2.2334200000000000, -1.9983231578947400, -1.7632263157894700, -1.5281294736842100, -1.2930326315789500, -1.0579357894736800, -0.8228389473684210, -0.5877421052631580, -0.3526452631578940, -0.1175484210526310, 0.1175484210526320, 0.3526452631578950, 0.5877421052631580, 0.8228389473684220, 1.0579357894736800, 1.2930326315789500, 1.5281294736842100, 1.7632263157894700 };
            double[] ySeries = solution.YSeries;
            for (int i = 0; i < ySeries.Length; i++)
            {
                Assert.AreEqual(actuals[i], ySeries[i], DELTA);
            }
        }

        [TestMethod]
        public void ShouldReturnFunctionOfYSeries()
        {
            const double DELTA = .0001;
            double[] actuals = { -1.720297799, -1.635466401, -1.543395213, -1.442877309, -1.332433433, -1.210258539, -1.074188733, -0.921746353, -0.750397612, -0.558280923, -0.345714299, -0.117278338, 0.117278338, 0.345714299, 0.558280923, 0.750397612, 0.921746353, 1.074188733, 1.210258539, 1.332433433 };
            double[] functionOfYSeries = solution.FunctionOfYSeries;
            for (int i = 0; i < functionOfYSeries.Length; i++)
            {
                Assert.AreEqual(actuals[i], functionOfYSeries[i], DELTA);
            }
        }

        [TestMethod]
        public void ShouldReturnZEndSeries()
        {
            const double DELTA = .0001;
            double[] actuals = { -2.614318197, -2.464297727, -2.301006016, -2.122173244, -1.925020425, -1.706178674, -1.461681078, -1.187179513, -0.878713369, -0.534559621, -0.158453184, 0.237310095, 0.633073374, 1.009179811, 1.353333558, 1.661799702, 1.936301267, 2.180798864, 2.399640615 };
            double[] zEndSeries = solution.ZEndSeries;
            for (int i = 0; i < zEndSeries.Length - 1; i++)
            {
                Assert.AreEqual(actuals[i], zEndSeries[i], DELTA);
            }
        }

        [TestMethod]
        public void ShouldReturnCumNormalSeries()
        {
            const double DELTA = .0001;
            double[] actuals = { 0.89405728, 1.372820251, 2.139129104, 3.382319251, 5.422680299, 8.797481803, 14.38286249, 23.51568202, 37.95567082, 59.29544113, 87.40997079, 118.7583769, 147.3314271, 168.7111593, 182.4050907, 190.3447058, 194.7169186, 197.0801703, 198.3588825, 200 };
            double[] cumNormalSeries = solution.CumNormalSeries;
            for (int i = 0; i < cumNormalSeries.Length - 1; i++)
            {
                Assert.AreEqual(actuals[i], cumNormalSeries[i], DELTA);
            }
        }

        [TestMethod]
        public void ShouldReturnGraduationSeries()
        {
            const double DELTA = .0001;
            double[] actuals = { 0.89405728, 0.478762971, 0.766308853, 1.243190146, 2.040361049, 3.374801504, 5.585380683, 9.132819532, 14.4399888, 21.33977031, 28.11452966, 31.34840608, 28.57305024, 21.37973217, 13.69393142, 7.939615101, 4.372212831, 2.363251701, 1.278712134, 1.641117532 };
            double[] graduationSeries = solution.GraduationSeries;
            for (int i = 0; i < graduationSeries.Length - 1; i++)
            {
                Assert.AreEqual(actuals[i], graduationSeries[i], DELTA);
            }
        }

        [TestMethod]
        public void ShouldReturnFirstMomentAboutOrigin()
        {
            const double DELTA = .0001;
            Assert.AreEqual(-0.167240338, solution.FirstMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnSecondMomentAboutOrigin()
        {
            const double DELTA = .0001;
            Assert.AreEqual(0.515961271, solution.SecondMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnThirdMomentAboutOrigin()
        {
            const double DELTA = .0001;
            Assert.AreEqual(-0.355353119, solution.ThirdMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnFourthMomentAboutOrigin()
        {
            const double DELTA = .0001;
            Assert.AreEqual(1.098714178, solution.FourthMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnSecondMomentOfAboutMean()
        {
            const double DELTA = .0001;
            Assert.AreEqual(0.48799194, solution.SecondMomentAboutMean, DELTA);
        }

        [TestMethod]
        public void ShouldReturnThirdMomentOfAboutMean()
        {
            const double DELTA = .0001;
            Assert.AreEqual(-0.105839708, solution.ThirdMomentAboutMean, DELTA);
        }

        [TestMethod]
        public void ShouldReturnFourthMomentOfAboutMean()
        {
            const double DELTA = .0001;
            Assert.AreEqual(0.945236373, solution.FourthMomentAboutMean, DELTA);
        }

        [TestMethod]
        public void ShouldReturnB1()
        {
            const double DELTA = .0001;
            Assert.AreEqual(0.096396067, solution.B1, DELTA);
        }

        [TestMethod]
        public void ShouldReturnB2()
        {
            const double DELTA = .0001;
            Assert.AreEqual(3.96931099, solution.B2, DELTA);
        }
    }
}
