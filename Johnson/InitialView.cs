using Excel = Microsoft.Office.Interop.Excel;

namespace Johnson
{
    public interface IView
    {
        void GenerateView(object viewModel);
    }

    public class InitialView : IView
    {
        public void GenerateView(object viewModel)
        {
            ScreenShouldUpdate(false);
            AddWorksheet();
            EnterLabels();
            EnterHistogramProperties((InitialViewModel)viewModel);
            FormatSheet();
            ScreenShouldUpdate(true);
        }

        private static void ScreenShouldUpdate(bool setting)
        {
            Globals.ThisAddIn.Application.ScreenUpdating = setting;
        }

        private static void AddWorksheet()
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

        private void EnterLabels()
        {
            Globals.ThisAddIn.Application.ActiveSheet.Range("A1").Offset(1).Value = "Moments about origin";
            Globals.ThisAddIn.Application.ActiveSheet.Range("B1").Offset(2).Value = "1st moment";
            Globals.ThisAddIn.Application.ActiveSheet.Range("B1").Offset(3).Value = "2nd moment";
            Globals.ThisAddIn.Application.ActiveSheet.Range("B1").Offset(4).Value = "3rd moment";
            Globals.ThisAddIn.Application.ActiveSheet.Range("B1").Offset(5).Value = "4th moment";
            Globals.ThisAddIn.Application.ActiveSheet.Range("A1").Offset(6).Value = "Moments about mean";
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

        private void EnterHistogramProperties(InitialViewModel viewModel)
        {
            Globals.ThisAddIn.Application.ActiveSheet.Range("C1").Offset(0).Value = "From Histogram";

            Globals.ThisAddIn.Application.ActiveSheet.Range("C1").Offset(2).Value = viewModel.mean1stMomment;
            Globals.ThisAddIn.Application.ActiveSheet.Range("C1").Offset(3).Value = viewModel.mean2ndtMomment;
            Globals.ThisAddIn.Application.ActiveSheet.Range("C1").Offset(4).Value = viewModel.mean3rdMomment;
            Globals.ThisAddIn.Application.ActiveSheet.Range("C1").Offset(5).Value = viewModel.mean4thMomment;

            Globals.ThisAddIn.Application.ActiveSheet.Range("C1").Offset(7).Value = viewModel.n2;
            Globals.ThisAddIn.Application.ActiveSheet.Range("C1").Offset(8).Value = viewModel.n3;
            Globals.ThisAddIn.Application.ActiveSheet.Range("C1").Offset(9).Value = viewModel.n4;

            Globals.ThisAddIn.Application.ActiveSheet.Range("C1").Offset(11).Value = viewModel.b1;
            Globals.ThisAddIn.Application.ActiveSheet.Range("C1").Offset(12).Value = viewModel.b2;

            Globals.ThisAddIn.Application.ActiveSheet.Range("C1").Offset(14).Value = viewModel.w;
            Globals.ThisAddIn.Application.ActiveSheet.Range("C1").Offset(15).Value = viewModel.beta1;
            Globals.ThisAddIn.Application.ActiveSheet.Range("C1").Offset(16).Value = viewModel.beta2;
            Globals.ThisAddIn.Application.ActiveSheet.Range("C1").Offset(17).Value = viewModel.johnsonType;
        }

        private void FormatSheet()
        {
            Excel.Range selection = Globals.ThisAddIn.Application.ActiveSheet.Cells;
            selection.Style = "Comma";
            selection.NumberFormat = "_(* #,##0.0000_);_(* -#,##0.0000_);_(@_)";
            selection.ColumnWidth = 24;

            selection = Globals.ThisAddIn.Application.ActiveSheet.Columns("A");
            selection.ColumnWidth = 5;


            selection = Globals.ThisAddIn.Application.ActiveSheet.Columns("B");
            selection.ColumnWidth = 19;


            selection = Globals.ThisAddIn.Application.ActiveSheet.Columns("A:B");
            selection.HorizontalAlignment = Excel.Constants.xlLeft;
            selection.VerticalAlignment = Excel.Constants.xlBottom;
            selection.WrapText = false;
            selection.Orientation = 0;
            selection.AddIndent = false;
            selection.IndentLevel = 0;
            selection.ShrinkToFit = false;
            selection.ReadingOrder = (int)Excel.Constants.xlContext;
            selection.MergeCells = false;

            selection = Globals.ThisAddIn.Application.ActiveSheet.Columns("C:D");
            selection.HorizontalAlignment = Excel.Constants.xlRight;
            selection.VerticalAlignment = Excel.Constants.xlBottom;
            selection.WrapText = false;
            selection.Orientation = 0;
            selection.AddIndent = false;
            selection.IndentLevel = 0;
            selection.ShrinkToFit = false;
            selection.ReadingOrder = (int)Excel.Constants.xlContext;
            selection.MergeCells = false;

            selection = Globals.ThisAddIn.Application.ActiveSheet.Range("A1");
        }
    }
}
