using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//create analias to the namespace/type
using Excel = Microsoft.Office.Interop.Excel;

namespace Excel_Lib {
    public class ExcelHandler {

        public static void CreateNewExcelFile(string filename) {

            // Creates and Excel Application instance:
            var excelAplication = new Excel.Application();
            excelAplication.Visible = true;

            // Creates an Excel Workbook with a default number of sheets:
            var excelWorkbook = excelAplication.Workbooks.Add();
            excelWorkbook.SaveAs(filename, AccessMode: Excel.XlSaveAsAccessMode.xlNoChange);

            // "Eliminates" the instance:
            excelWorkbook.Close();
            excelAplication.Quit();

            // Don't forget to free the memory
            ReleaseCOMObject(excelWorkbook);
            ReleaseCOMObject(excelAplication);

        }

        // static  method name ReleaseCOMObjectsto kill  all  COM  classes used:
        private static void ReleaseCOMObject(Object obj) {
            try {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            } catch (Exception e) {
                obj = null;
                System.Diagnostics.Debug.WriteLine("Exception while releasing COM object" + e.ToString());
            } finally {
                GC.Collect();
            }
        }

        // static method to open and write data intoan existing excel file:
        public static void WriteToExcelFile(string filename) {

            Excel.Application excelAplication = new Excel.Application();
            excelAplication.Visible = true;

            // Opens the excel file:
            Excel.Workbook excelWorkbook = excelAplication.Workbooks.Open(filename);
            Excel.Worksheet excelWorksheet = excelWorkbook.ActiveSheet;

            excelWorksheet.Cells[1, 1].Value = "Hello";
            excelWorksheet.Cells[1, 2].Value = "World!";

            Excel.Worksheet excelWorksheet2 = excelWorkbook.Worksheets.Add();
            excelWorksheet2.Cells[1, 1].Value = "Goodbye";
            excelWorksheet2.Cells[1, 2].Value = "World!";

            // "Eliminates" the instance:
            excelWorkbook.Save();
            excelWorkbook.Close();
            excelAplication.Quit();

            // Don't forget to free the memory
            ReleaseCOMObject(excelWorksheet2);
            ReleaseCOMObject(excelWorksheet);
            ReleaseCOMObject(excelWorkbook);
            ReleaseCOMObject(excelAplication);
        }

        // Static method to open and read data from an existing excel file:
        public static string ReadFromExcelFile(String filename) {

            var excelAplication = new Excel.Application();
            excelAplication.Visible = false;

            // Opens the excel file:
            var excelWorkbook = excelAplication.Workbooks.Open(filename);
            var excelWorksheet = (Excel.Worksheet)excelWorkbook.ActiveSheet;

            string content = excelWorksheet.Cells[1, 1].Value;
            // content = excelWorksheet.Cells[1, 2].Value;
            content += (excelWorksheet.Cells[1, 2] as Excel.Range).Text;

            // "Eliminates" the instance:
            excelWorkbook.Close();
            excelAplication.Quit();

            // Don't forget to free the memory
            ReleaseCOMObject(excelWorksheet);
            ReleaseCOMObject(excelWorkbook);
            ReleaseCOMObject(excelAplication);

            // Release memory from COM Objects:
            return content;
        }

        // Static method that creates a chart:
        public static void CreateChart(string filename) {

            var excelApplication = new Excel.Application();
            excelApplication.Visible = false;

            //Opens the excel file
            var excelWorkbook = excelApplication.Workbooks.Open(filename);
            var excelWorksheet = (Excel.Worksheet)excelWorkbook.ActiveSheet;


            Excel.Chart myChart = null;
            Excel.ChartObjects charts = excelWorksheet.ChartObjects();
            Excel.ChartObject chartObj = charts.Add(100, 100, 300, 300);
            myChart = chartObj.Chart;

            // Set chart range -- cell  values  to be used in the graph 
            Excel.Range myRange = excelWorksheet.get_Range("C2:C8");
            myChart.SetSourceData(myRange);

            // Chart  properties using  the named properties and default parameters functionality
            // In the .NET framework

            myChart.ChartType = Excel.XlChartType.xl3DColumn;
            myChart.ChartWizard(Source: myRange,
                Title: "Notas UC IS",
                CategoryTitle: "Title of x Axis",
                ValueTitle: "TESTES");

            // "Eliminates" the instance:
            excelWorkbook.Save();
            excelWorkbook.Close();
            excelApplication.Quit();
            // Don't forget to free the memory
            ReleaseCOMObject(myChart);
            ReleaseCOMObject(chartObj);
            ReleaseCOMObject(charts);
            ReleaseCOMObject(myRange);
            ReleaseCOMObject(excelWorksheet);
            ReleaseCOMObject(excelWorkbook);
            ReleaseCOMObject(excelApplication);
        }
    }
}
