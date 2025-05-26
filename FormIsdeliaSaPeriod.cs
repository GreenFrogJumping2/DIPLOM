using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace DIPLOM
{
    public partial class FormIsdeliaSaPeriod : Form
    {
        public FormIsdeliaSaPeriod()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

            string data1 = dateTimePicker1.Value.ToString("MM.dd.yyyy");
            string data2 = dateTimePicker2.Value.ToString("MM.dd.yyyy");

            worksheet.Range["A1:C1"].Merge();
            worksheet.Cells[1, 1] = "Изготовленные изделия с " + data1 + " по " + data2;
            worksheet.Cells[1, 1].Font.Size = 12;
            worksheet.Cells[1, 1].Font.Bold = true;
            worksheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            worksheet.Cells[3, 1] = "№";
            worksheet.Cells[3, 1].Font.Size = 12;
            worksheet.Cells[3, 1].Borders.LineStyle = 1;
            worksheet.Cells[3, 1].Borders.Weight = Excel.XlBorderWeight.xlThick;
            worksheet.Columns[1].columnWidth = 6;

            worksheet.Cells[3, 2] = "Название";
            worksheet.Cells[3, 2].Font.Size = 12;
            worksheet.Cells[3, 2].Borders.LineStyle = 1;
            worksheet.Cells[3, 2].Borders.Weight = Excel.XlBorderWeight.xlThick;
            worksheet.Columns[2].columnWidth = 24;

            worksheet.Cells[3, 3] = "Количество";
            worksheet.Cells[3, 3].Font.Size = 12;
            worksheet.Cells[3, 3].Borders.LineStyle = 1;
            worksheet.Cells[3, 3].Borders.Weight = Excel.XlBorderWeight.xlThick;
            worksheet.Columns[3].columnWidth = 18;

            string SQL = "SELECT nasvanie, COUNT(idIsdelia) AS count FROM vidiIsdeliy JOIN isdelia ON isdelia.idVida = vidiIsdeliy.idVida JOIN sakas ON sakas.idSakasa = isdelia.idSakasa WHERE data BETWEEN '" + data1 + "' AND '" + data2 + "' GROUP BY vidiIsdeliy.idVida, nasvanie";
            SqlDataReader dr = Program.DBController.ReaderQuery(SQL);
            int i = 4;
            while (dr.Read())
            {
                worksheet.Cells[i, 1].Value = i - 3;
                worksheet.Cells[i, 1].Font.Size = 12;
                worksheet.Cells[i, 1].Borders.LineStyle = 1;

                worksheet.Cells[i, 2].Value = (String.Format("{0}", dr["nasvanie"]));
                worksheet.Cells[i, 2].Font.Size = 12;
                worksheet.Cells[i, 2].Borders.LineStyle = 1;

                worksheet.Cells[i, 3].Value = (String.Format("{0}", dr["count"]));
                worksheet.Cells[i, 3].Font.Size = 12;
                worksheet.Cells[i, 3].Borders.LineStyle = 1;

                i++;
            }
            dr.Close();

            int maxI = i - 1;
            Excel.Range dataRange = worksheet.Range[worksheet.Cells[3, 2], worksheet.Cells[maxI, 3]];

            excelApp.Charts.Add();
            Excel.Chart chart = excelApp.ActiveChart;
            chart.ChartType = Excel.XlChartType.xlColumnClustered;
            chart.SetSourceData(dataRange, XlRowCol.xlColumns);

            chart.HasLegend = false;
            string title = "Заказанные изделия с " + data1 + " по " + data2;
            chart.ChartTitle.Text = title;
            ((Excel.Axis)chart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary)).MajorUnit = 1;
        }
    }
}
