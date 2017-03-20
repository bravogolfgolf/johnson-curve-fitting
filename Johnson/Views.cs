using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace Johnson
{
    public interface IView
    {
         void GenerateView();
    }

    public class InitialView : IView
    {
        public void GenerateView()
        {
            int count = Globals.ThisAddIn.Application.Sheets.Count;
            Excel.Worksheet lastWorksheet = Globals.ThisAddIn.Application.ActiveWorkbook.Sheets[count];
            Excel.Worksheet worksheet = Globals.ThisAddIn.Application.Worksheets.Add(After: lastWorksheet);
        }
    }
}
