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
            Excel.Worksheet lastWorksheet = getLastWorksheetInWorkbook();
            Excel.Worksheet worksheet = AddNewWorksheetAfter(lastWorksheet);
        }

        private static Excel.Worksheet getLastWorksheetInWorkbook()
        {
            int count = Globals.ThisAddIn.Application.Sheets.Count;
            Excel.Worksheet lastWorksheet = Globals.ThisAddIn.Application.ActiveWorkbook.Sheets[count];
            return lastWorksheet;
        }

        private static Excel.Worksheet AddNewWorksheetAfter(Excel.Worksheet lastWorksheet)
        {
            return Globals.ThisAddIn.Application.Worksheets.Add(After: lastWorksheet);
        }
    }
}
