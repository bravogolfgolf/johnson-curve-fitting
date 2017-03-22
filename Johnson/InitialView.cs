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
            EnterLabels();
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

        private void EnterLabels()
        {
            Globals.ThisAddIn.Application.ActiveSheet.Range("A1").Offset(1).Value = "Moments about origin";
            Globals.ThisAddIn.Application.ActiveSheet.Range("B1").Offset(2).Value = "1st moment";
            Globals.ThisAddIn.Application.ActiveSheet.Range("B1").Offset(3).Value = "2nd moment";
            Globals.ThisAddIn.Application.ActiveSheet.Range("B1").Offset(4).Value = "3rd moment";
            Globals.ThisAddIn.Application.ActiveSheet.Range("B1").Offset(5).Value = "4th moment";
            Globals.ThisAddIn.Application.ActiveSheet.Range("A1").Offset(6).Value = "Moment about mean";
            Globals.ThisAddIn.Application.ActiveSheet.Range("B1").Offset(7).Value = "2nd moment";
            Globals.ThisAddIn.Application.ActiveSheet.Range("B1").Offset(8).Value = "3rd moment";
            Globals.ThisAddIn.Application.ActiveSheet.Range("B1").Offset(9).Value = "4th moment";
            Globals.ThisAddIn.Application.ActiveSheet.Range("A1").Offset(10).Value = "Betas";
            Globals.ThisAddIn.Application.ActiveSheet.Range("B1").Offset(11).Value = "B1";
            Globals.ThisAddIn.Application.ActiveSheet.Range("B1").Offset(12).Value = "B2";
            Globals.ThisAddIn.Application.ActiveSheet.Range("A1").Offset(13).Value = "Determine Johnson type";
            Globals.ThisAddIn.Application.ActiveSheet.Range("B1").Offset(14).Value = "W";
            Globals.ThisAddIn.Application.ActiveSheet.Range("B1").Offset(15).Value = "Beta1";
            Globals.ThisAddIn.Application.ActiveSheet.Range("B1").Offset(16).Value = "Beta2";
            Globals.ThisAddIn.Application.ActiveSheet.Range("B1").Offset(17).Value = "Johnson Type";
            Globals.ThisAddIn.Application.ActiveSheet.Range("B1").Offset(18).Value = "Pearson Type";
            Globals.ThisAddIn.Application.ActiveSheet.Range("B1").Offset(19).Value = "Shape";
        }
    }
}
