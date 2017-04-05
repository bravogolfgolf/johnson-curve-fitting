using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace Johnson
{
    public interface IView { void GenerateView(object viewModel); }

    public class InitialView : IView
    {
        private InitialViewModel viewModel;

        public void GenerateView(object viewModel)
        {
            this.viewModel = (InitialViewModel)viewModel;
            ScreenShouldUpdate(false);
            CreatePropertiesSheet();
            CreateDataSheet();
            ScreenShouldUpdate(true);
        }

        private void ScreenShouldUpdate(bool setting)
        {
            Globals.ThisAddIn.Application.ScreenUpdating = setting;
        }

        private void CreatePropertiesSheet()
        {
            AddWorksheet();
            EnterPropertyLabels();
            EnterHistogramValues();
            EnterSolutionValues();
            FormatPropertySheet();
        }

        private void CreateDataSheet()
        {
            AddWorksheet();
            EnterDataLabels();
            EnterDataValues();
            FormatDataSheet();
        }

        private void AddWorksheet()
        {
            Excel.Worksheet lastWorksheet = getLastWorksheetInWorkbook();
            AddNewWorksheetAfter(lastWorksheet);
        }

        private Excel.Worksheet getLastWorksheetInWorkbook()
        {
            int count = Globals.ThisAddIn.Application.Sheets.Count;
            Excel.Worksheet lastWorksheet = Globals.ThisAddIn.Application.ActiveWorkbook.Sheets[count];
            return lastWorksheet;
        }

        private void AddNewWorksheetAfter(Excel.Worksheet lastWorksheet)
        {
            Globals.ThisAddIn.Application.Worksheets.Add(After: lastWorksheet);
        }

        private void EnterPropertyLabels()
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

        private void EnterHistogramValues()
        {
            const String CELL = "C1";
            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(0).Value = "From Histogram";

            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(2).Value = viewModel.histogtamMean1stMomment;
            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(3).Value = viewModel.histogtamMean2ndtMomment;
            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(4).Value = viewModel.histogtamMean3rdMomment;
            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(5).Value = viewModel.histogtamMean4thMomment;

            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(7).Value = viewModel.histogtamN2;
            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(8).Value = viewModel.histogtamN3;
            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(9).Value = viewModel.histogtamN4;

            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(11).Value = viewModel.histogtamB1;
            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(12).Value = viewModel.histogtamB2;

            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(14).Value = viewModel.histogtamW;
            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(15).Value = viewModel.histogtamBeta1;
            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(16).Value = viewModel.histogtamBeta2;
            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(17).Value = viewModel.histogtamJohnsonType;
        }

        private void EnterSolutionValues()
        {
            const String CELL = "D1";
            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(0).Value = "From Fit";

            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(2).Value = viewModel.solutionMean1stMomment;
            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(3).Value = viewModel.solutionMean2ndtMomment;
            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(4).Value = viewModel.solutionMean3rdMomment;
            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(5).Value = viewModel.solutionMean4thMomment;

            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(7).Value = viewModel.solutionN2;
            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(8).Value = viewModel.solutionN3;
            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(9).Value = viewModel.solutionN4;

            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(11).Value = viewModel.solutionB1;
            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(12).Value = viewModel.solutionB2;

            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(14).Value = "N/A";
            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(15).Value = "N/A";
            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(16).Value = "N/A";
            Globals.ThisAddIn.Application.ActiveSheet.Range(CELL).Offset(17).Value = "N/A";
        }

        private void FormatPropertySheet()
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

            selection = Globals.ThisAddIn.Application.ActiveSheet.Columns("C:D");
            selection.HorizontalAlignment = Excel.Constants.xlRight;

            selection = Globals.ThisAddIn.Application.ActiveSheet.Range("A1");
        }

        private void EnterDataLabels()
        {
            Globals.ThisAddIn.Application.ActiveSheet.Range("A1").Value = "X";
            Globals.ThisAddIn.Application.ActiveSheet.Range("B1").Value = "Frequency";
            Globals.ThisAddIn.Application.ActiveSheet.Range("C1").Value = "Y";
            Globals.ThisAddIn.Application.ActiveSheet.Range("D1").Value = "F(Y)";
            Globals.ThisAddIn.Application.ActiveSheet.Range("E1").Value = "Z End";
            Globals.ThisAddIn.Application.ActiveSheet.Range("F1").Value = "Cum Normal";
            Globals.ThisAddIn.Application.ActiveSheet.Range("G1").Value = "Graduation";
        }

        private void EnterDataValues()
        {
            for (int i = 0; i < viewModel.intervals.Length; i++)
            {
                int row = i + 2;
                Globals.ThisAddIn.Application.ActiveSheet.Range("A" + row).Value = viewModel.intervals[i];
                Globals.ThisAddIn.Application.ActiveSheet.Range("B" + row).Value = viewModel.frequencies[i];
                Globals.ThisAddIn.Application.ActiveSheet.Range("C" + row).Value = viewModel.ySeries[i];
                Globals.ThisAddIn.Application.ActiveSheet.Range("D" + row).Value = viewModel.functionOfYSeries[i];
                if (i != viewModel.intervals.Length - 1)
                    Globals.ThisAddIn.Application.ActiveSheet.Range("E" + row).Value = viewModel.zEndSeries[i];
                Globals.ThisAddIn.Application.ActiveSheet.Range("F" + row).Value = viewModel.cumNormalSeries[i];
                Globals.ThisAddIn.Application.ActiveSheet.Range("G" + row).Value = viewModel.graduationSeries[i];
            }
        }

        private void FormatDataSheet()
        {
            Excel.Range selection = Globals.ThisAddIn.Application.ActiveSheet.Cells;
            selection.Style = "Comma";
            selection.NumberFormat = "_(* #,##0.0000_);_(* -#,##0.0000_);_(@_)";
            selection.ColumnWidth = 20;
            selection.HorizontalAlignment = Excel.Constants.xlRight;
            selection = Globals.ThisAddIn.Application.ActiveSheet.Range("A1");
        }
    }
}
