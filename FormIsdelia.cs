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

namespace DIPLOM
{
    public partial class FormIsdelia : Form
    {
        string idVida = "";
        public FormIsdelia()
        {
            InitializeComponent();
        }

        private void FormIsdelia_Load(object sender, EventArgs e)
        {
            comboBoxLoad1();
        }

        void comboBoxLoad1()
        {
            string SQL = "SELECT idIsdelia, (nasvanie + N' (заказ №' + CAST(sakas.idSakasa AS NVARCHAR) + N')') AS isdelie FROM isdelia JOIN vidiIsdeliy ON vidiIsdeliy.idVida = isdelia.idVida JOIN sakas ON sakas.idSakasa = isdelia.idSakasa";
            DataTable dt = Program.DBController.SelectQuery(SQL);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "isdelie";
            comboBox1.ValueMember = "idIsdelia";
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }
            comboBoxLoad2();
            dataGridLoad1();
        }

        void comboBoxLoad2()
        {
            string SQL = "SELECT vidiIsdeliy.idVida FROM vidiIsdeliy JOIN isdelia ON isdelia.idVida = vidiIsdeliy.idVida WHERE idIsdelia = " + comboBox1.SelectedValue.ToString();
            SqlDataReader dr = Program.DBController.ReaderQuery(SQL);
            while (dr.Read())
            {
                idVida = ((String.Format("{0}", dr["idVida"])));
            }
            SQL = "SELECT idIspolzuemoyFurnituri, furnitura.idFurnituri AS id, nasvanie FROM ispolzuemayaFurnitura JOIN furnitura ON furnitura.idFurnituri = ispolzuemayaFurnitura.idFurnituri WHERE idVida = " + idVida + " AND ispolzuemayaFurnitura.idFurnituri NOT IN (SELECT idFurnituri FROM satrachenayaFurnitura WHERE idIsdelia = '" + comboBox1.SelectedValue.ToString() + "')";
            DataTable dt = Program.DBController.SelectQuery(SQL);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "nasvanie";
            comboBox2.ValueMember = "id";
            comboBox2.Text = "";
        }

        void dataGridLoad1()
        {
            string idIsdelia = comboBox1.SelectedValue.ToString();
            string SQL = "SELECT satrachenayaFurnitura.idSatrachenoyFurnituri, nasvanie, kolvo FROM satrachenayaFurnitura JOIN furnitura ON furnitura.idFurnituri = satrachenayaFurnitura.idFurnituri JOIN isdelia ON isdelia.idIsdelia = satrachenayaFurnitura.idIsdelia WHERE isdelia.idIsdelia = " + idIsdelia;
            DataTable dt = Program.DBController.SelectQuery(SQL);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "№";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Вид фурнитуры";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].HeaderText = "Количество";
            dataGridView1.Columns[2].Width = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idFurnituri = comboBox2.SelectedValue.ToString();
            string idIsdelia = comboBox1.SelectedValue.ToString();
            string SQL = "SELECT kolvo FROM ispolzuemayaFurnitura WHERE idVida = " + idVida + " AND idFurnituri = " + idFurnituri;
            SqlDataReader dr = Program.DBController.ReaderQuery(SQL);
            string kolvo = "";
            while (dr.Read())
            {
                kolvo = ((String.Format("{0}", dr["kolvo"])));
            }
            SQL = "INSERT INTO satrachenayaFurnitura (kolvo, idFurnituri, idIsdelia) VALUES ('" + kolvo + "', '" + idFurnituri + "', '" + idIsdelia + "')";
            Program.DBController.Query(SQL);
            dataGridLoad1();
            comboBoxLoad2();
        }
    }
}
