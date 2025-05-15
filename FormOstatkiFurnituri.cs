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
    public partial class FormOstatkiFurnituri : Form
    {
        public FormOstatkiFurnituri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

            worksheet.Range["A1:C1"].Merge();
            worksheet.Cells[1, 1] = "Остатки фурнитуры на " + DateTime.Now.ToString("dd.MM.yyyy");
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

            string SQL = "SELECT nasvanie, idFurnituri FROM furnitura";
            SqlDataReader dr = Program.DBController.ReaderQuery(SQL);
            int i = 4;
            while(dr.Read())
            {
                worksheet.Cells[i, 1].Value = i - 3;
                worksheet.Cells[i, 1].Font.Size = 12;
                worksheet.Cells[i, 1].Borders.LineStyle = 1;

                worksheet.Cells[i, 2].Value = (String.Format("{0}", dr["nasvanie"]));
                worksheet.Cells[i, 2].Font.Size = 12;
                worksheet.Cells[i, 2].Borders.LineStyle = 1;

                worksheet.Cells[i, 3].Value = "0";
                worksheet.Cells[i, 3].Font.Size = 12;
                worksheet.Cells[i, 3].Borders.LineStyle = 1;

                worksheet.Cells[i, 4].Value = (String.Format("{0}", dr["idFurnituri"]));
                i++;
            }
            dr.Close();

            string SQL1 = "SELECT idFurnituri, SUM(kolvo) AS kolvo FROM sakupkaFurnituri GROUP BY idFurnituri";
            SqlDataReader dr1 = Program.DBController.ReaderQuery(SQL1);
            i = 4;
            while (dr1.Read())
            {
                if ((String.Format("{0}", dr1["idFurnituri"])) == worksheet.Cells[i, 4].Value.ToString())
                {
                    worksheet.Cells[i, 3].Value = Convert.ToString(Convert.ToInt32(worksheet.Cells[i, 3].Value) + Convert.ToInt32((String.Format("{0}", dr1["kolvo"]))));
                }
                i++;
            }
            dr1.Close();

            string SQL2 = "SELECT idFurnituri, SUM(kolvo) AS kolvo FROM satrachenayaFurnitura GROUP BY idFurnituri";
            SqlDataReader dr2 = Program.DBController.ReaderQuery(SQL2);
            i = 4;
            while (dr2.Read())
            {
                if ((String.Format("{0}", dr2["idFurnituri"])) == worksheet.Cells[i, 4].Value.ToString())
                {
                    worksheet.Cells[i, 3].Value = Convert.ToString(Convert.ToInt32(worksheet.Cells[i, 3].Value) - Convert.ToInt32((String.Format("{0}", dr2["kolvo"]))));
                }
                i++;
            }
            dr2.Close();

            while (i >= 4)
            {
                worksheet.Cells[i, 4].Value = "";
                i--;
            }
        }
    }
}
