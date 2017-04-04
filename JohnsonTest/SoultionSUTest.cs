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
            double[] actuals = { -2.70361368421053, -2.46851684210526, -2.23342, -1.99832315789474, -1.76322631578947, -1.52812947368421, -1.29303263157895, -1.05793578947368, -0.822838947368421, -0.587742105263158, -0.352645263157894, -0.117548421052631, 0.117548421052632, 0.352645263157895, 0.587742105263158, 0.822838947368422, 1.05793578947368, 1.29303263157895, 1.52812947368421, 1.76322631578947 };
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
            double[] actuals = { -1.72030619756382, -1.63547470090389, -1.54340338641427, -1.44288531699841, -1.33244122271135, -1.21026603251311, -1.07419581622742, -0.921752860671035, -0.750403302142408, -0.558285460535683, -0.345717277415679, -0.117279383784053, 0.117279383784054, 0.345717277415679, 0.558285460535684, 0.750403302142409, 0.921752860671036, 1.07419581622742, 1.21026603251311, 1.33244122271135 };
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
            double[] actuals = { -2.61431260499347, -2.46429299267164, -2.30100217737942, -2.12217033282867, -1.92501845974085, -1.70617764704497, -1.46168093510822, -1.18718012188132, -0.878714478938664, -0.534560840755667, -0.158454039445557, 0.237309956747426, 0.633073952940409, 1.00918075425052, 1.35333439243352, 1.66180003537617, 1.93630084860307, 2.18079756053982, 2.3996383732357 };
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
            double[] actuals = { 0.894071914961327, 1.37283838551035, 2.13915080059076, 3.38234368888308, 5.42270488829752, 8.79750092192305, 14.3828663998251, 23.5156579947369, 37.9556106096777, 59.2953568008893, 87.4099034260512, 118.758366166536, 147.331464919707, 168.711204513368, 182.405117338534, 190.344712483797, 194.716913506738, 197.080160690565, 198.358872419738, 200 };
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
            double[] actuals = { 0.894071914961327, 0.478766470549024, 0.76631241508041, 1.24319288829232, 2.04036119941444, 3.37479603362553, 5.58536547790208, 9.13279159491173, 14.4399526149409, 21.3397461912116, 28.1145466251619, 31.3484627404847, 28.5730987531706, 21.379739593661, 13.693912825167, 7.93959514526264, 4.37220102294037, 2.36324718382784, 1.27871172917273, 1.64112758026192 };
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
            Assert.AreEqual(-0.16724180196, solution.FirstMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnSecondMomentAboutOrigin()
        {
            const double DELTA = .0001;
            Assert.AreEqual(0.51597075816, solution.SecondMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnThirdMomentAboutOrigin()
        {
            const double DELTA = .0001;
            Assert.AreEqual(-0.35536406152, solution.ThirdMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnFourthMomentAboutOrigin()
        {
            const double DELTA = .0001;
            Assert.AreEqual(1.09875841152, solution.FourthMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnSecondMomentOfAboutMean()
        {
            const double DELTA = .0001;
            Assert.AreEqual(0.48800093784, solution.SecondMomentAboutMean, DELTA);
        }

        [TestMethod]
        public void ShouldReturnThirdMomentOfAboutMean()
        {
            const double DELTA = .0001;
            Assert.AreEqual(-0.10584386976, solution.ThirdMomentAboutMean, DELTA);
        }

        [TestMethod]
        public void ShouldReturnFourthMomentOfAboutMean()
        {
            const double DELTA = .0001;
            Assert.AreEqual(0.94527423136, solution.FourthMomentAboutMean, DELTA);
        }

        [TestMethod]
        public void ShouldReturnB1()
        {
            const double DELTA = .0001;
            Assert.AreEqual(0.09639831652, solution.B1, DELTA);
        }

        [TestMethod]
        public void ShouldReturnB2()
        {
            const double DELTA = .0001;
            Assert.AreEqual(3.96932359467, solution.B2, DELTA);
        }
    }
}
