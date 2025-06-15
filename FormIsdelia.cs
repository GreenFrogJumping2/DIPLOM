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
            dataGridLoad2();
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

            SQL = "SELECT idIspolzuemoyKoji, (vidKoji + N' ' + CAST(ploshad AS NVARCHAR) + N' м2') AS nasv FROM ispolzuemayaKoja WHERE idVida = " + idVida + " AND idIspolzuemoyKoji NOT IN (SELECT idIspolzuemoyKoji FROM satrachenayaKoja WHERE idIsdelia = " + comboBox1.SelectedValue.ToString() + ")";
            DataTable dt2 = Program.DBController.SelectQuery(SQL);
            comboBox3.DataSource = dt2;
            comboBox3.DisplayMember = "nasv";
            comboBox3.ValueMember = "idIspolzuemoyKoji";
            comboBox3.Text = "";
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
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].HeaderText = "Количество";
            dataGridView1.Columns[2].Width = 200;
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
                kolvo = (String.Format("{0}", dr["kolvo"]));
            }
            if (checkFurnitura(idFurnituri, kolvo) == false)
            {
                MessageBox.Show("Недостаточно фурнитуры");
                return;
            }
            SQL = "INSERT INTO satrachenayaFurnitura (kolvo, idFurnituri, idIsdelia) VALUES ('" + kolvo + "', '" + idFurnituri + "', '" + idIsdelia + "')";
            Program.DBController.Query(SQL);
            dataGridLoad1();
            comboBoxLoad2();
        }

        void comboBoxLoad3()
        {
            string SQL1 = "SELECT vidKoji FROM ispolzuemayaKoja WHERE idIspolzuemoyKoji = " + comboBox3.SelectedValue.ToString();
            SqlDataReader dr = Program.DBController.ReaderQuery(SQL1);
            string vidKoji = "";
            while (dr.Read())
            {
                vidKoji = ((String.Format("{0}", dr["vidKoji"])));
            }
            string SQL = "SELECT idLista, (vidKoji + N' №' + CAST(idLista AS NVARCHAR)) AS list FROM listiKoji WHERE vidKoji = N'" + vidKoji + "'";
            DataTable dt = Program.DBController.SelectQuery(SQL);
            comboBox4.DataSource = dt;
            comboBox4.DisplayMember = "list";
            comboBox4.ValueMember = "idLista";
            comboBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBoxLoad3();
        }

        void dataGridLoad2()
        {
            string idIsdelia = comboBox1.SelectedValue.ToString();
            string SQL = "SELECT satrachenayaKoja.idSatrachenoyKoji, (vidKoji + N' №' + CAST(listiKoji.idLista AS NVARCHAR)) AS list, ploshadViresa FROM satrachenayaKoja JOIN listiKoji ON listiKoji.idLista = satrachenayaKoja.idLista JOIN isdelia ON isdelia.idIsdelia = satrachenayaKoja.idIsdelia WHERE isdelia.idIsdelia = " + idIsdelia;
            DataTable dt = Program.DBController.SelectQuery(SQL);
            dataGridView2.DataSource = dt;
            dataGridView2.Columns[0].HeaderText = "№";
            dataGridView2.Columns[0].Width = 50;
            dataGridView2.Columns[1].HeaderText = "Лист кожи";
            dataGridView2.Columns[1].Width = 200;
            dataGridView2.Columns[2].HeaderText = "Площадь выреза (м2)";
            dataGridView2.Columns[2].Width = 250;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string trebuemKoja = comboBox3.SelectedValue.ToString();
            string listKoji = comboBox4.SelectedValue.ToString();
            string isdelie = comboBox1.SelectedValue.ToString();
            string ploshad = "";
            string SQL = "SELECT ploshad FROM ispolzuemayaKoja WHERE idIspolzuemoyKoji = " + comboBox3.SelectedValue.ToString();
            SqlDataReader dr = Program.DBController.ReaderQuery(SQL);
            while (dr.Read())
            {
                ploshad = Program.DBController.ConvertToNumeric((String.Format("{0}", dr["ploshad"])));
            }
            if (checkKoja(trebuemKoja, listKoji) == false)
            {
                MessageBox.Show("Не хватает кожи, выберите другой лист.");
                return;
            }
            /*
             * Здесь будет проверка остатков кожи
             */
            string SQL2 = "INSERT INTO satrachenayaKoja(ploshadViresa, idLista, idIsdelia, idIspolzuemoyKoji) VALUES('" + ploshad + "', '" + listKoji + "', '" + isdelie + "', '" + trebuemKoja + "')";
            Program.DBController.Query(SQL2);
            dataGridLoad2();
            comboBoxLoad2();
        }

        bool checkKoja(string trebKoja, string listKoji)
        {
            string SQL = "SELECT ploshad FROM listiKoji WHERE idLista = " + listKoji;
            SqlDataReader dr = Program.DBController.ReaderQuery(SQL);
            double ploshad = 0;
            while (dr.Read())
            {
                ploshad = Convert.ToDouble((String.Format("{0}", dr["ploshad"])));
            }
            dr.Close();
            string SQL1 = "SELECT SUM(ploshadViresa) AS ploshad FROM satrachenayaKoja WHERE idLista = " + listKoji + " GROUP BY idLista";
            SqlDataReader dr1 = Program.DBController.ReaderQuery(SQL1);
            while (dr1.Read())
            {
                ploshad -= Convert.ToDouble((String.Format("{0}", dr1["ploshad"])));
            }
            string SQL2 = "SELECT ploshad FROM ispolzuemayaKoja WHERE idIspolzuemoyKoji = " + trebKoja;
            SqlDataReader dr2 = Program.DBController.ReaderQuery(SQL2);
            double treb = 0;
            while (dr2.Read())
            {
                treb = Convert.ToDouble((String.Format("{0}", dr2["ploshad"])));
            }
            dr2.Close();
            if (ploshad < treb)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        bool checkFurnitura(string idFurnituri, string trebKolvo)
        {
            string SQL = "SELECT SUM(kolvo) AS kolvo FROM sakupkaFurnituri WHERE idFurnituri = " + idFurnituri + " GROUP BY idFurnituri";
            SqlDataReader dr = Program.DBController.ReaderQuery(SQL);
            int kolvo = 0;
            while (dr.Read())
            {
                kolvo += Convert.ToInt32((String.Format("{0}", dr["kolvo"])));
            }
            dr.Close();
            string SQL1 = "SELECT SUM(kolvo) AS kolvo FROM satrachenayaFurnitura WHERE idFurnituri = " + idFurnituri + " GROUP BY idFurnituri";
            SqlDataReader dr1 = Program.DBController.ReaderQuery(SQL1);
            while (dr1.Read())
            {
                kolvo -= Convert.ToInt32((String.Format("{0}", dr1["kolvo"])));
            }
            if (kolvo < Convert.ToUInt32(trebKolvo))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
