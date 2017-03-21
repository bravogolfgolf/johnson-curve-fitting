using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;
using Controllers;
using Requestors;
using System.Collections;
using System.Collections.Generic;

namespace Johnson
{
    public partial class Ribbon
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
                RequestBuilder builder = new RequestBuilder();
                IDictionary dictionary = new Dictionary<int, object>();
                int size = (int) range.Count / 2;
                double[] intervals = new double[size];
                double[] frequencies = new double[size];
                for (int index = 1; index <= size; index++)
                {
                    intervals[index - 1] = range.Value2[index, 1];
                    frequencies[index - 1] = range.Value2[index, 2];
                }
                dictionary[0] = intervals;
                dictionary[1] = frequencies;
                Request request = builder.Create("Initial", dictionary);
                new InitialController(request, new Usecases.InitialUsecase(new Johnson.InitialPresenter(new InitialView()))).Execute();
            }
        }
    }
}
