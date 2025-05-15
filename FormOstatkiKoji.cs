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
    public partial class FormOstatkiKoji : Form
    {
        public FormOstatkiKoji()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

            worksheet.Range["A1:D1"].Merge();
            worksheet.Cells[1, 1] = "Остатки кожи на " + DateTime.Now.ToString("dd.MM.yyyy");
            worksheet.Cells[1, 1].Font.Size = 12;
            worksheet.Cells[1, 1].Font.Bold = true;
            worksheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            worksheet.Cells[3, 1] = "№";
            worksheet.Cells[3, 1].Font.Size = 12;
            worksheet.Cells[3, 1].Borders.LineStyle = 1;
            worksheet.Cells[3, 1].Borders.Weight = Excel.XlBorderWeight.xlThick;
            worksheet.Columns[1].columnWidth = 6;

            worksheet.Cells[3, 2] = "Лист";
            worksheet.Cells[3, 2].Font.Size = 12;
            worksheet.Cells[3, 2].Borders.LineStyle = 1;
            worksheet.Cells[3, 2].Borders.Weight = Excel.XlBorderWeight.xlThick;
            worksheet.Columns[2].columnWidth = 6;

            worksheet.Cells[3, 3] = "Вид кожи";
            worksheet.Cells[3, 3].Font.Size = 12;
            worksheet.Cells[3, 3].Borders.LineStyle = 1;
            worksheet.Cells[3, 3].Borders.Weight = Excel.XlBorderWeight.xlThick;
            worksheet.Columns[3].columnWidth = 18;

            worksheet.Cells[3, 4] = "Оставшаяся площадь";
            worksheet.Cells[3, 4].Font.Size = 12;
            worksheet.Cells[3, 4].Borders.LineStyle = 1;
            worksheet.Cells[3, 4].Borders.Weight = Excel.XlBorderWeight.xlThick;
            worksheet.Columns[4].columnWidth = 24;

            string SQL = "SELECT idLista, vidKoji, ploshad FROM listiKoji WHERE prichinaSpisania IS NULL ORDER BY idLista";
            SqlDataReader dr = Program.DBController.ReaderQuery(SQL);
            int i = 4;
            while (dr.Read())
            {
                worksheet.Cells[i, 1].Value = i - 3;
                worksheet.Cells[i, 1].Font.Size = 12;
                worksheet.Cells[i, 1].Borders.LineStyle = 1;

                worksheet.Cells[i, 2].Value = (String.Format("{0}", dr["idLista"]));
                worksheet.Cells[i, 2].Font.Size = 12;
                worksheet.Cells[i, 2].Borders.LineStyle = 1;

                worksheet.Cells[i, 3].Value = (String.Format("{0}", dr["vidKoji"]));
                worksheet.Cells[i, 3].Font.Size = 12;
                worksheet.Cells[i, 3].Borders.LineStyle = 1;

                worksheet.Cells[i, 4].Value = (String.Format("{0}", dr["ploshad"]));
                worksheet.Cells[i, 4].Font.Size = 12;
                worksheet.Cells[i, 4].Borders.LineStyle = 1;

                i++;
            }
            dr.Close();

            string SQL1 = "SELECT idLista, SUM(ploshadViresa) AS ploshad FROM satrachenayaKoja GROUP BY idLista";
            SqlDataReader dr1 = Program.DBController.ReaderQuery(SQL1);
            i = 4;
            while (dr1.Read())
            {
                if ((String.Format("{0}", dr1["idLista"])) == worksheet.Cells[i, 2].Value.ToString())
                {
                    worksheet.Cells[i, 4].Value = Convert.ToString(Convert.ToDouble(worksheet.Cells[i, 4].Value) - Convert.ToDouble((String.Format("{0}", dr1["ploshad"]))));
                }
                i++;
            }
        }
    }
}
