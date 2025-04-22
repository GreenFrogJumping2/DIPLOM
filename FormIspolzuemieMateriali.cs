using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM
{
    public partial class FormIspolzuemieMateriali : Form
    {
        string vidIsdeliya;
        public FormIspolzuemieMateriali(string idVida)
        {
            InitializeComponent();
            vidIsdeliya = idVida;
        }

        private void FormIspolzuemieMateriali_Load(object sender, EventArgs e)
        {
            string SQL = "SELECT nasvanie FROM vidiisdeliy WHERE idVida = " + vidIsdeliya;
            SqlDataReader dr = Program.DBController.ReaderQuery(SQL);
            string naim = "";
            while (dr.Read())
            {
                naim = (String.Format("{0}", dr["nasvanie"]));
            }
            this.Text = "Используемые материалы для изделия \"" + naim + "\"";
            dataGridLoad1();
            clear1();
            dataGridLoad2();
            clear2();
            comboBoxLoad();
        }

        void dataGridLoad1()
        {
            string SQL = "SELECT idIspolzuemoyKoji, vidKoji, ploshad FROM ispolzuemayaKoja WHERE idVida = " + vidIsdeliya;
            DataTable dt = Program.DBController.SelectQuery(SQL);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "№";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Вид кожи";
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].HeaderText = "Площадь (м2)";
            dataGridView1.Columns[2].Width = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vidKoji = comboBox1.Text;
            string ploshad = Program.DBController.ConvertToNumeric(textBox1.Text);
            string SQL = "INSERT INTO ispolzuemayaKoja (vidKoji, ploshad, idVida) VALUES (N'" + vidKoji + "', '" + ploshad + "', '" + vidIsdeliya + "')";
            Program.DBController.Query(SQL);
            dataGridLoad1();
            clear1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            string SQL = "DELETE FROM ispolzuemayaKoja WHERE idIspolzuemoyKoji = " + id;
            Program.DBController.Query(SQL);
            dataGridLoad1();
            clear1();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            comboBox1.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox1.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        void clear1()
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            string vidKoji = comboBox1.Text;
            string ploshad = Program.DBController.ConvertToNumeric(textBox1.Text);
            string SQL = "UPDATE ispolzuemayaKoja SET vidKoji = N'" + vidKoji + "', ploshad = '" + ploshad + "' WHERE idIspolzuemoyKoji = " + id;
            Program.DBController.Query(SQL);
            dataGridLoad1();
            clear1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear1();
        }

        void dataGridLoad2()
        {
            string SQL = "SELECT idIspolzuemoyFurnituri, nasvanie, kolvo FROM ispolzuemayaFurnitura JOIN furnitura ON furnitura.idFurnituri = ispolzuemayaFurnitura.idFurnituri WHERE idVida = " + vidIsdeliya;
            DataTable dt = Program.DBController.SelectQuery(SQL);
            dataGridView2.DataSource = dt;
            dataGridView2.Columns[0].HeaderText = "№";
            dataGridView2.Columns[0].Width = 50;
            dataGridView2.Columns[1].HeaderText = "Вид фурнитуры";
            dataGridView2.Columns[1].Width = 200;
            dataGridView2.Columns[2].HeaderText = "Количество";
            dataGridView2.Columns[2].Width = 100;
        }

        void clear2()
        {
            comboBoxLoad();
            textBox2.Text = "";
            button5.Enabled = true;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
        }

        void comboBoxLoad ()
        {
            string SQL = "SELECT idFurnituri, nasvanie FROM furnitura";
            DataTable dt = Program.DBController.SelectQuery(SQL);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "nasvanie";
            comboBox2.ValueMember = "idFurnituri";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string furnitura = comboBox2.SelectedValue.ToString();
            string SQL1 = "SELECT idFurnituri FROM ispolzuemayaFurnitura WHERE idVida = " + vidIsdeliya;
            SqlDataReader dr = Program.DBController.ReaderQuery(SQL1);
            while (dr.Read())
            {
                if ((String.Format("{0}", dr["idFurnituri"])) == furnitura)
                {
                    MessageBox.Show(comboBox2.Text + " уже используется в этом изделии");
                    return;
                }
            }
            string kolvo = Program.DBController.ConvertToNumeric(textBox2.Text);
            string SQL = "INSERT INTO ispolzuemayaFurnitura (idFurnituri, kolvo, idVida) VALUES ('" + furnitura + "', '" + kolvo + "', '" + vidIsdeliya + "')";
            Program.DBController.Query(SQL);
            dataGridLoad2();
            clear2();
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            comboBox2.Text = dataGridView2[1, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox2.Text = dataGridView2[2, dataGridView1.CurrentRow.Index].Value.ToString();
            button5.Enabled = false;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string id = dataGridView2[0, dataGridView1.CurrentRow.Index].Value.ToString();
            string furnitura = comboBox2.SelectedValue.ToString();
            string SQL1 = "SELECT idFurnituri FROM ispolzuemayaFurnitura WHERE idVida = " + vidIsdeliya;
            SqlDataReader dr = Program.DBController.ReaderQuery(SQL1);
            while (dr.Read())
            {
                if ((String.Format("{0}", dr["idFurnituri"])) == furnitura)
                {
                    MessageBox.Show(comboBox2.Text + " уже используется в этом изделии");
                    return;
                }
            }
            string kolvo = textBox2.Text;
            string SQL = "UPDATE ispolzuemayaFurnitura SET idFurnituri = '" + furnitura + "', kolvo = '" + kolvo + "' WHERE idIspolzuemoyFurnituri = " + id;
            Program.DBController.Query(SQL);
            dataGridLoad2();
            clear2();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string id = dataGridView2[0, dataGridView1.CurrentRow.Index].Value.ToString();
            string SQL = "DELETE FROM ispolzuemayaFurnitura WHERE idIspolzuemoyFurnituri = " + id;
            Program.DBController.Query(SQL);
            dataGridLoad2();
            clear2();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            clear2();
        }
    }
}
