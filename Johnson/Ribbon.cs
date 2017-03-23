using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;
using Requestors;
using System.Collections.Generic;

namespace Johnson
{
    public partial class Ribbon
    {
        ControllerFactory factory = new ControllerFactory();

        private void JohnsonRibbon_Load(object sender, RibbonUIEventArgs e) { }

        private void OnInitalButtonClick(object sender, RibbonControlEventArgs e)
        {
            dynamic input = GetUserInput();
            if (input is Excel.Range)
            {
                IDictionary<int, object> dictionary = ConvertRangeToArraysAndAddToDictionary(input);
                factory.Create("Initial", dictionary, new InitialPresenter(new InitialView())).Execute();
            }
        }

        private dynamic GetUserInput()
        {
            const int LIMIT_TYPE_TO_EXCEL_RANGE = 8;
            string Prompt = "Select two data columns (X, Freq) for analysis";
            string Title = "Select Histogram";
            var input = Globals.ThisAddIn.Application.InputBox(Prompt: Prompt, Title: Title, Type: LIMIT_TYPE_TO_EXCEL_RANGE);
            return input;
        }

        private IDictionary<int, object> ConvertRangeToArraysAndAddToDictionary(dynamic range)
        {
            IDictionary<int, object> dictionary = new Dictionary<int, object>();
            int size = (int)range.Count / 2;
            double[] intervals = new double[size];
            double[] frequencies = new double[size];
            for (int index = 1; index <= size; index++)
            {
                intervals[index - 1] = range.Value2[index, 1];
                frequencies[index - 1] = range.Value2[index, 2];
            }
            dictionary[0] = intervals;
            dictionary[1] = frequencies;
            return dictionary;
        }
    }
}
