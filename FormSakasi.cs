using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM
{
    public partial class FormSakasi : Form
    {
        string sakasId = "";
        public FormSakasi()
        {
            InitializeComponent();
        }

        private void FormSakasi_Load(object sender, EventArgs e)
        {
            comboBoxLoad1();
            comboBoxesLoad2();
            dataGridLoad1();
            clear1();
        }

        void comboBoxLoad1()
        {
            string SQL = "SELECT fio, idSakaschika FROM Sakaschiki";
            DataTable dt = Program.DBController.SelectQuery(SQL);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "fio";
            comboBox1.ValueMember = "idSakaschika";
        }

        void dataGridLoad1()
        {
            string SQL = "SELECT idSakasa, fio, data FROM Sakas JOIN sakaschiki ON sakaschiki.idSakaschika = sakas.idSakaschika";
            DataTable dt = Program.DBController.SelectQuery(SQL);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "№";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Заказчик";
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].HeaderText = "Дата";
            dataGridView1.Columns[2].Width = 150;
        }

        void clear1()
        {
            comboBoxLoad1();
            dateTimePicker1.Value = DateTime.Now;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sakaschik = comboBox1.SelectedValue.ToString();
            string data = dateTimePicker1.Value.ToString("MM.dd.yyyy");
            string SQL = "INSERT INTO sakas (idSakaschika, data) VALUES ('" + sakaschik + "', '" + data + "')";
            Program.DBController.Query(SQL);
            dataGridLoad1();
            comboBoxesLoad2();
            clear1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            string sakaschik = comboBox1.SelectedValue.ToString();
            string data = dateTimePicker1.Value.ToString("MM.dd.yyyy");
            string SQL = "UPDATE sakas SET idSakaschika = '" + sakaschik + "', data = '" + data + "' WHERE idSakasa = " + id;
            Program.DBController.Query(SQL);
            dataGridLoad1();
            comboBoxesLoad2();
            clear1();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            comboBox1.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            dateTimePicker1.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            sakasId = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            dataGridLoad2();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            string SQL = "DELETE FROM sakas WHERE idSakasa = " + id;
            Program.DBController.Query(SQL);
            dataGridLoad1();
            comboBoxesLoad2();
            clear1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear1();
        }

        void comboBoxesLoad2()
        {
            string SQL = "SELECT idVida, nasvanie FROM vidiIsdeliy";
            DataTable dt = Program.DBController.SelectQuery(SQL);
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "nasvanie";
            comboBox3.ValueMember = "idVida";
        }

        void dataGridLoad2()
        {
            string SQL = "SELECT idIsdelia, nasvanie FROM isdelia JOIN vidiIsdeliy ON isdelia.idVida = vidiIsdeliy.idVida WHERE idSakasa = " + sakasId;
            DataTable dt = Program.DBController.SelectQuery(SQL);
            dataGridView2.DataSource = dt;
            dataGridView2.Columns[0].HeaderText = "№";
            dataGridView2.Columns[0].Width = 50;
            dataGridView2.Columns[1].HeaderText = "Вид изделия";
            dataGridView2.Columns[1].Width = 200;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string vid = comboBox3.SelectedValue.ToString();
            string SQL = "INSERT INTO isdelia (idVida, idSakasa) VALUES ('" + vid + "', '" + sakasId + "')";
            Program.DBController.Query(SQL);
            dataGridLoad2();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string id = dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString();
            string SQL = "DELETE FROM isdelia WHERE idIsdelia = " + id;
            Program.DBController.Query(SQL);
            dataGridLoad2();
        }
    }
}
