using Requestors;
using Responders;
using Entities;

namespace Usecases
{
    public class InitialUsecase : Usecase
    {
        private Histogram histogram;
        private IInitialResponder responder;

        public InitialUsecase(IInitialResponder responder)
        {
            this.responder = responder;
        }

        public override void Execute(Request request)
        {
            InitialRequest r = (InitialRequest)request;
            histogram = new Histogram(r.intervals, r.frequencies);
            IInitialResponse response = CreateResponse();
            responder.Present(response);
        }

        private IInitialResponse CreateResponse()
        {
            IInitialResponse response = new InitialResponse();
            response.Mean1stMomment = histogram.FirstMomentAboutOrigin;
            response.Mean2ndtMomment = histogram.SecondMomentAboutOrigin;
            response.Mean3rdMomment = histogram.ThirdMomentAboutOrigin;
            response.Mean4thMomment = histogram.FourthMomentAboutOrigin;
            response.N2 = histogram.SecondMomentAboutMean;
            response.N3 = histogram.ThirdMomentAboutMean;
            response.N4 = histogram.FourthMomentAboutMean;
            response.B1 = histogram.B1;
            response.B2 = histogram.B2;
            response.W = histogram.W;
            response.Beta1 = histogram.Beta1;
            response.Beta2 = histogram.Beta2;
            response.JohnsonType = histogram.JohnsonType;
            return response;
        }
    }
}