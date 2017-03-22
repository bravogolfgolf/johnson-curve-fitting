using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;
using Controllers;
using Requestors;
using System.Collections;
using System.Collections.Generic;
using Microsoft.CSharp.RuntimeBinder;
using System.Windows.Forms;

namespace Johnson
{
    public partial class Ribbon
    {
        RequestBuilder builder = new RequestBuilder();

        private void JohnsonRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void OnInitalButtonClick(object sender, RibbonControlEventArgs e)
        {
            dynamic input = GetUserInput();
            if (input is Excel.Range)
            {
                Request request = TryProcessRangeIntoRequest(input);
                if (request.IsValid)
                    new InitialController(request, new Usecases.InitialUsecase(new Johnson.InitialPresenter(new InitialView()))).Execute();
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

        private Request TryProcessRangeIntoRequest(dynamic range)
        {
            IDictionary dictionary = new Dictionary<int, object>();
            try
            {
                dictionary = ConvertRangeToArraysAndAddToDictionary(range);
            }
            catch (RuntimeBinderException e)
            {
                MessageBox.Show("Range must contain values for each cell", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Request();
            }
            return builder.Create("Initial", dictionary);
        }

        private IDictionary ConvertRangeToArraysAndAddToDictionary(dynamic range)
        {
            IDictionary dictionary = new Dictionary<int, object>();
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
