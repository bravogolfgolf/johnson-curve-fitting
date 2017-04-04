using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entities
{
    [TestClass]
    public class SoultionSBTest
    {
        private const double DELTA = .0001;
        private Solution solution;
        private double[] intervals = { 17.0, 22.0, 27.0, 32.0, 37.0, 42.0, 47.0, 52.0, 57.0, 62.0, 67.0, 72.0, 77.0, 82.0, 87.0 };
        private double[] frequencies = { 34.0, 145.00, 156.00, 145.00, 123.00, 103.00, 86.00, 71.00, 55.00, 37.00, 21.00, 13.00, 7.00, 3.00, 1.00 };
        private Histogram histogram;

        [TestInitialize]
        public void SetUp()
        {
            histogram = new Histogram(intervals, frequencies);
            solution = new SolutionSB(histogram);
        }

        [TestMethod]
        public void ShouldReturnYSeries()
        {
            double[] actuals = { 0.12526, 0.178794285714286, 0.232328571428571, 0.285862857142857, 0.339397142857143, 0.392931428571429, 0.446465714285714, 0.5, 0.553534285714286, 0.607068571428571, 0.660602857142857, 0.714137142857143, 0.767671428571429, 0.821205714285714, 0.87474 };
            double[] ySeries = solution.YSeries;
            for (int i = 0; i < ySeries.Length; i++)
            {
                Assert.AreEqual(actuals[i], ySeries[i], DELTA);
            }
        }

        [TestMethod]
        public void ShouldReturnFunctionOfYSeries()
        {
            double[] actuals = { -1.94353512224752, -1.52453774044223, -1.19520918834339, -0.915562845392304, -0.66598190347211, -0.435006637797279, -0.214961084052591, -1.11022302462516E-16, 0.214961084052591, 0.435006637797279, 0.66598190347211, 0.915562845392304, 1.19520918834339, 1.52453774044223, 1.94353512224752 };
            double[] functionOfYSeries = solution.FunctionOfYSeries;
            for (int i = 0; i < functionOfYSeries.Length; i++)
            {
                Assert.AreEqual(actuals[i], functionOfYSeries[i], DELTA);
            }
        }

        [TestMethod]
        public void ShouldReturnZEndSeries()
        {
            double[] actuals = { -1.50775774864882, -0.973746881328165, -0.535334234179658, -0.152804849869101, 0.195263444942707, 0.522303292501001, 0.837907625187367, 1.14987646068022, 1.46548079336658, 1.79252064092488, 2.14058893573669, 2.52311832004724, 2.96153096719575, 3.49554183451641 };
            double[] zEndSeries = solution.ZEndSeries;
            for (int i = 0; i < zEndSeries.Length - 1; i++)
            {
                Assert.AreEqual(actuals[i], zEndSeries[i], DELTA);
            }
        }

        [TestMethod]
        public void ShouldReturnCumNormalSeries()
        {
            double[] actuals = { 65.8082697319256, 165.091116735396, 296.209378863144, 439.276086505855, 577.406643540318, 699.270411437203, 798.958707048516, 874.902621329053, 928.605105620388, 963.475197085103, 983.846399089063, 994.184037200099, 998.469431456391, 999.763449858282, 1000 };
            double[] cumNormalSeries = solution.CumNormalSeries;
            for (int i = 0; i < cumNormalSeries.Length - 1; i++)
            {
                Assert.AreEqual(actuals[i], cumNormalSeries[i], DELTA);
            }
        }

        [TestMethod]
        public void ShouldReturnGraduationSeries()
        {
            const double DELTA = .001;
            double[] actuals = { 65.8082697319256, 99.2828470034707, 131.118262127748, 143.066707642711, 138.130557034463, 121.863767896885, 99.6882956113122, 75.943914280537, 53.7024842913354, 34.8700914647146, 20.3712020039601, 10.3376381110367, 4.28539425629151, 1.29401840189166, 0.236550141717544 };
            double[] graduationSeries = solution.GraduationSeries;
            for (int i = 0; i < graduationSeries.Length - 1; i++)
            {
                Assert.AreEqual(actuals[i], graduationSeries[i], DELTA);
            }
        }

        [TestMethod]
        public void ShouldReturnFirstMomentAboutOrigin()
        {
            Assert.AreEqual(0.35089272837, solution.FirstMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnSecondMomentAboutOrigin()
        {
            Assert.AreEqual(0.14360458020, solution.SecondMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnThirdMomentAboutOrigin()
        {
            Assert.AreEqual(0.06620194278, solution.ThirdMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnFourthMomentAboutOrigin()
        {
            Assert.AreEqual(0.03346138244, solution.FourthMomentAboutOrigin, DELTA);
        }

        [TestMethod]
        public void ShouldReturnSecondMomentOfAboutMean()
        {
            Assert.AreEqual(0.02047887337, solution.SecondMomentAboutMean, DELTA);
        }

        [TestMethod]
        public void ShouldReturnThirdMomentOfAboutMean()
        {
            Assert.AreEqual(0.00144036433, solution.ThirdMomentAboutMean, DELTA);
        }

        [TestMethod]
        public void ShouldReturnFourthMomentOfAboutMean()
        {
            Assert.AreEqual(0.00115093473, solution.FourthMomentAboutMean, DELTA);
        }

        [TestMethod]
        public void ShouldReturnB1()
        {
            Assert.AreEqual(0.24156083994, solution.B1, DELTA);
        }

        [TestMethod]
        public void ShouldReturnB2()
        {
            Assert.AreEqual(2.74434416181, solution.B2, DELTA);
        }
    }
}
