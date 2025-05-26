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
    public partial class FormSakupkaFurnituri : Form
    {
        public FormSakupkaFurnituri()
        {
            InitializeComponent();
        }

        private void FormSakupkaFurnituri_Load(object sender, EventArgs e)
        {
            dataGridUpdate();
            comboBoxUpdate();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        void dataGridUpdate()
        {
            string SQL = "SELECT idSakupki, nasvanie, stoimost, kolvo FROM sakupkaFurnituri JOIN furnitura ON furnitura.idFurnituri = sakupkaFurnituri.idFurnituri";
            try
            {
                DataTable dt = Program.DBController.SelectQuery(SQL);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "№";
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].HeaderText = "Название";
                dataGridView1.Columns[1].Width = 250;
                dataGridView1.Columns[2].HeaderText = "Стоимость (р.)";
                dataGridView1.Columns[2].Width = 200;
                dataGridView1.Columns[3].HeaderText = "Количество (шт.)";
                dataGridView1.Columns[3].Width = 200;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void comboBoxUpdate()
        {
            string SQL = "SELECT idFurnituri, nasvanie FROM furnitura";
            try
            {
                DataTable dt = Program.DBController.SelectQuery(SQL);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "nasvanie";
                comboBox1.ValueMember = "idFurnituri";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idFurnituri = comboBox1.SelectedValue.ToString();
            string stoimost = textBox1.Text;
            string kolvo = textBox2.Text;
            string SQL = "INSERT INTO sakupkaFurnituri(idFurnituri, stoimost, kolvo) VALUES('" + idFurnituri + "', N'" + stoimost + "', N'" + kolvo + "')";
            try
            {
                Program.DBController.Query(SQL);
                dataGridUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            comboBox1.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox1.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox2.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        void clear()
        {
            comboBoxUpdate();
            textBox1.Text = "";
            textBox2.Text = "";
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            dataGridUpdate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            string idFurnituri = comboBox1.SelectedValue.ToString();
            string stoimost = Program.DBController.ConvertToNumeric(textBox1.Text);
            string kolvo = textBox2.Text;
            string SQL = "UPDATE sakupkaFurnituri SET idFurnituri = '" + idFurnituri + "', stoimost = '" + stoimost + "', kolvo = '" + kolvo + "' WHERE idSakupki = '" + id + "'";
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
            string SQL = "DELETE FROM sakupkaFurnituri WHERE idSakupki = '" + id + "'";
            Console.WriteLine(SQL);
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
    }
}
