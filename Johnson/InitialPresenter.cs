using Responders;

namespace Johnson
{
    public class InitialPresenter : IInitialResponder
    {
        private InitialViewModel viewModel = new InitialViewModel();
        private IView view;

        public InitialPresenter(IView view)
        {
            this.view = view;
        }

        public void GernerateView()
        {
            view.GenerateView(viewModel);
        }

        public void Present(IInitialResponse response)
        {
            viewModel.intervals = response.Intervals;
            viewModel.frequencies = response.Frequencies;

            viewModel.histogtamMean1stMomment = response.HistogramMean1stMomment;
            viewModel.histogtamMean2ndtMomment = response.HistogramMean2ndtMomment;
            viewModel.histogtamMean3rdMomment = response.HistogramMean3rdMomment;
            viewModel.histogtamMean4thMomment = response.HistogramMean4thMomment;
            viewModel.histogtamN2 = response.HistogramN2;
            viewModel.histogtamN3 = response.HistogramN3;
            viewModel.histogtamN4 = response.HistogramN4;
            viewModel.histogtamB1 = response.HistogramB1;
            viewModel.histogtamB2 = response.HistogramB2;
            viewModel.histogtamW = response.HistogramW;
            viewModel.histogtamBeta1 = response.HistogramBeta1;
            viewModel.histogtamBeta2 = response.HistogramBeta2;
            viewModel.histogtamJohnsonType = response.HistogramJohnsonType;

            viewModel.ySeries = response.YSeries;
            viewModel.functionOfYSeries = response.FunctionOfYSeries;
            viewModel.zEndSeries = response.ZEndSeries;
            viewModel.cumNormalSeries = response.CumNormalSeries;
            viewModel.graduationSeries = response.GraduationSeries;

            viewModel.solutionMean1stMomment = response.SolutionMean1stMomment;
            viewModel.solutionMean2ndtMomment = response.SolutionMean2ndtMomment;
            viewModel.solutionMean3rdMomment = response.SolutionMean3rdMomment;
            viewModel.solutionMean4thMomment = response.SolutionMean4thMomment;
            viewModel.solutionN2 = response.SolutionN2;
            viewModel.solutionN3 = response.SolutionN3;
            viewModel.solutionN4 = response.SolutionN4;
            viewModel.solutionB1 = response.SolutionB1;
            viewModel.solutionB2 = response.SolutionB2;
        }
    }
}