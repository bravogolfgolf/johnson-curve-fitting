using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace Johnson
{
    public interface IView { void GenerateView(object viewModel); }

    public class InitialView : IView
    {
        private const String GRADUATION_VALUES = "Graduation_Values";
        private const String FREQUENCIES_VALUES = "Frequencies_Values";
        private const String X_VALUES = "X_Values";
        private InitialViewModel viewModel;
        private Excel.Worksheet dataSheet;
        private Excel.Chart chartSheet;

        public void GenerateView(object viewModel)
        {
            this.viewModel = (InitialViewModel)viewModel;
            ScreenShouldUpdate(false);
            CreatePropertiesSheet();
            CreateDataSheet();
            CreateChartSheet();
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
            dataSheet = AddWorksheet();
            EnterDataLabels();
            CreateNamedRanges();
            EnterDataValues();
            FormatDataSheet();
        }

        private void CreateChartSheet()
        {
            AddChartSheet();
            MoveChartSheet();
            AddSeriesToChart();
        }

        private Excel.Worksheet AddWorksheet()
        {
            int count = WorksheetsCount();
            return Globals.ThisAddIn.Application.Worksheets.Add(After: Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets[count]);
        }

        private int WorksheetsCount()
        {
            return Globals.ThisAddIn.Application.Worksheets.Count;
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

        private void CreateNamedRanges()
        {
            const int FIRST_ROW_IN_RANGE = 2;
            const int COLUMN_B = 2;
            const int COLUMN_C = 3;
            const int COLUMN_G = 7;
            int lastRowInRange = FIRST_ROW_IN_RANGE + viewModel.intervals.Length - 1;

            Excel.Range range = dataSheet.Range[dataSheet.Cells[FIRST_ROW_IN_RANGE, COLUMN_B], dataSheet.Cells[lastRowInRange, COLUMN_B]];
            range.Name = FREQUENCIES_VALUES;
            range = dataSheet.Range[dataSheet.Cells[FIRST_ROW_IN_RANGE, COLUMN_C], dataSheet.Cells[lastRowInRange, COLUMN_C]];
            range.Name = X_VALUES;
            range = dataSheet.Range[dataSheet.Cells[FIRST_ROW_IN_RANGE, COLUMN_G], dataSheet.Cells[lastRowInRange, COLUMN_G]];
            range.Name = GRADUATION_VALUES;
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

        private void AddChartSheet()
        {
            int count = WorksheetsCount();
            chartSheet = Globals.ThisAddIn.Application.Charts.Add(After: Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets[count]);
            Globals.ThisAddIn.Application.ActiveChart.Type = (int)Excel.XlChartType.xlLine;
        }

        private void MoveChartSheet()
        {
            int count = WorksheetsCount();
            chartSheet.Move(Type.Missing, Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets[count]);
        }

        private void AddSeriesToChart()
        {
            while (Globals.ThisAddIn.Application.ActiveChart.SeriesCollection().Count() != 0)
                Globals.ThisAddIn.Application.ActiveChart.SeriesCollection(1).Delete();

            Excel.Range graduationRange = Globals.ThisAddIn.Application.Sheets[dataSheet.Index].Range[GRADUATION_VALUES];
            Excel.Range frequencyRange = Globals.ThisAddIn.Application.Sheets[dataSheet.Index].Range[FREQUENCIES_VALUES];
            Excel.Range xRange = Globals.ThisAddIn.Application.Sheets[dataSheet.Index].Range[X_VALUES];

            Excel.Series series = (Excel.Series)Globals.ThisAddIn.Application.ActiveChart.SeriesCollection().Add(frequencyRange);
            series.Name = Globals.ThisAddIn.Application.Sheets[dataSheet.Index].Range("B1").Value();
            series.XValues = xRange;

            series = (Excel.Series)Globals.ThisAddIn.Application.ActiveChart.SeriesCollection().Add(graduationRange);
            series.Name = Globals.ThisAddIn.Application.Sheets[dataSheet.Index].Range("G1").Value();
            series.XValues = xRange;
        }
    }
}
