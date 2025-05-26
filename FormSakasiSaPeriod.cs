using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace DIPLOM
{
    public partial class FormSakasiSaPeriod : Form
    {
        public FormSakasiSaPeriod()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

            string date1 = dateTimePicker1.Value.ToString("MM.dd.yyyy");
            string date2 = dateTimePicker2.Value.ToString("MM.dd.yyyy");

            worksheet.Range["A1:D1"].Merge();
            worksheet.Cells[1, 1] = "Заказы с " + date1 + " по " + date2;
            worksheet.Cells[1, 1].Font.Size = 12;
            worksheet.Cells[1, 1].Font.Bold = true;
            worksheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            worksheet.Cells[3, 1] = "№";
            worksheet.Cells[3, 1].Font.Size = 12;
            worksheet.Cells[3, 1].Borders.LineStyle = 1;
            worksheet.Cells[3, 1].Borders.Weight = Excel.XlBorderWeight.xlThick;
            worksheet.Columns[1].columnWidth = 6;

            worksheet.Cells[3, 2] = "Заказ";
            worksheet.Cells[3, 2].Font.Size = 12;
            worksheet.Cells[3, 2].Borders.LineStyle = 1;
            worksheet.Cells[3, 2].Borders.Weight = Excel.XlBorderWeight.xlThick;
            worksheet.Columns[2].columnWidth = 12;

            worksheet.Cells[3, 3] = "Дата заказа";
            worksheet.Cells[3, 3].Font.Size = 12;
            worksheet.Cells[3, 3].Borders.LineStyle = 1;
            worksheet.Cells[3, 3].Borders.Weight = Excel.XlBorderWeight.xlThick;
            worksheet.Columns[3].columnWidth = 18;

            worksheet.Cells[3, 4] = "ФИО заказчика";
            worksheet.Cells[3, 4].Font.Size = 12;
            worksheet.Cells[3, 4].Borders.LineStyle = 1;
            worksheet.Cells[3, 4].Borders.Weight = Excel.XlBorderWeight.xlThick;
            worksheet.Columns[4].columnWidth = 24;

            string SQL = "SELECT sakas.idSakasa, FORMAT(sakas.data, 'yyyy-MM-dd') AS data, sakaschiki.fio FROM sakas JOIN sakaschiki ON sakaschiki.idSakaschika = sakas.idSakaschika WHERE sakas.data BETWEEN '" + date1 + "' AND '" + date2 + "'";
            SqlDataReader dr = Program.DBController.ReaderQuery(SQL);
            int i = 4;
            while (dr.Read())
            {
                worksheet.Cells[i, 1].Value = i - 3;
                worksheet.Cells[i, 1].Font.Size = 12;
                worksheet.Cells[i, 1].Borders.LineStyle = 1;

                worksheet.Cells[i, 2].Value = (String.Format("{0}", dr["idSakasa"]));
                worksheet.Cells[i, 2].Font.Size = 12;
                worksheet.Cells[i, 2].Borders.LineStyle = 1;

                worksheet.Cells[i, 3].Value = (String.Format("{0}", dr["data"]));
                worksheet.Cells[i, 3].Font.Size = 12;
                worksheet.Cells[i, 3].Borders.LineStyle = 1;

                worksheet.Cells[i, 4].Value = (String.Format("{0}", dr["fio"]));
                worksheet.Cells[i, 4].Font.Size = 12;
                worksheet.Cells[i, 4].Borders.LineStyle = 1;

                i++;
            }
        }
    }
}
