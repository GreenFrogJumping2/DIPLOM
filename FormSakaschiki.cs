using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DIPLOM
{
    public partial class FormSakaschiki : Form
    {
        public FormSakaschiki()
        {
            InitializeComponent();
        }

        private void FormSakaschiki_Load(object sender, EventArgs e)
        {
            dataGridUpdate();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        void dataGridUpdate()
        {
            string SQL = "SELECT * FROM sakaschiki";
            try
            {
                DataTable dt = Program.DBController.SelectQuery(SQL);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "№";
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].HeaderText = "ФИО";
                dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns[2].HeaderText = "Телефон";
                dataGridView1.Columns[2].Width = 150;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fio = textBox1.Text;
            string telefon = maskedTextBox1.Text;
            string SQL = "INSERT INTO sakaschiki(fio, telefon) VALUES(N'" + fio + "', N'" + telefon + "')";
            try
            {
                Program.DBController.Query(SQL);
                dataGridUpdate();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            maskedTextBox1.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            string fio = textBox1.Text;
            string telefon = maskedTextBox1.Text;
            string SQL = "UPDATE sakaschiki SET fio = N'" + fio + "', telefon = N'" + telefon + "' WHERE idSakaschika = '" + id + "'";
            try
            {
                Program.DBController.Query(SQL);
                clear();
                dataGridUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            string SQL = "DELETE FROM sakaschiki WHERE idSakaschika = '" + id + "'";
            try
            {
                Program.DBController.Query(SQL);
                clear();
                dataGridUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        void clear()
        {
            textBox1.Text = "";
            maskedTextBox1.Text = "";
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            dataGridUpdate();
        }
    }
}
