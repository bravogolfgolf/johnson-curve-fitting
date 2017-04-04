using Entities;
using Requestors;
using Responders;

namespace Usecases
{
    public class InitialUsecase : Usecase
    {
        private Histogram histogram;
        private Solution solution;
        private IInitialResponder responder;

        public InitialUsecase(IInitialResponder responder)
        {
            this.responder = responder;
        }

        public override void Execute(Request request)
        {
            InitialRequest r = (InitialRequest)request;
            histogram = new Histogram(r.intervals, r.frequencies);
            solution = Solution.Create(histogram);
            IInitialResponse response = CreateResponse();
            responder.Present(response);
        }

        private IInitialResponse CreateResponse()
        {
            IInitialResponse response = new InitialResponse()
            {
                HistogramMean1stMomment = histogram.FirstMomentAboutOrigin,
                HistogramMean2ndtMomment = histogram.SecondMomentAboutOrigin,
                HistogramMean3rdMomment = histogram.ThirdMomentAboutOrigin,
                HistogramMean4thMomment = histogram.FourthMomentAboutOrigin,
                HistogramN2 = histogram.SecondMomentAboutMean,
                HistogramN3 = histogram.ThirdMomentAboutMean,
                HistogramN4 = histogram.FourthMomentAboutMean,
                HistogramB1 = histogram.B1,
                HistogramB2 = histogram.B2,
                HistogramW = histogram.W,
                HistogramBeta1 = histogram.Beta1,
                HistogramBeta2 = histogram.Beta2,
                HistogramJohnsonType = histogram.JohnsonType,

                SolutionMean1stMomment = solution.FirstMomentAboutOrigin,
                SolutionMean2ndtMomment = solution.SecondMomentAboutOrigin,
                SolutionMean3rdMomment = solution.ThirdMomentAboutOrigin,
                SolutionMean4thMomment = solution.FourthMomentAboutOrigin,
                SolutionN2 = solution.SecondMomentAboutMean,
                SolutionN3 = solution.ThirdMomentAboutMean,
                SolutionN4 = solution.FourthMomentAboutMean,
                SolutionB1 = solution.B1,
                SolutionB2 = solution.B2
            };
            return response;
        }
    }
}