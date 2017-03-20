using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;
using Controllers;
using Requestors;

namespace Johnson
{
    public partial class JohnsonRibbon
    {
        private void JohnsonRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void OnInitalButtonClick(object sender, RibbonControlEventArgs e)
        {
            const int LIMIT_TYPE_TO_EXCEL_RANGE = 8;
            string Prompt = "Select two data columns (X, Freq) for analysis";
            string Title = "Select Histogram";
            var range = Globals.ThisAddIn.Application.InputBox(Prompt: Prompt, Title: Title, Type: LIMIT_TYPE_TO_EXCEL_RANGE);
            if (range is Excel.Range)
            {
                InitialRequest request = new Requestors.InitialRequest();
                request.twoDimensionalArray = range.Value2;
                new InitialController(request, new Usecases.InitialUsecase(new Johnson.InitialPresenter(new InitialView()))).Execute();
            }
        }
    }
}
