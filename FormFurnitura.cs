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
    public partial class FormFurnitura : Form
    {
        public FormFurnitura()
        {
            InitializeComponent();
        }

        private void FormFurnitura_Load(object sender, EventArgs e)
        {
            dataGridUpdate();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        void dataGridUpdate()
        {
            string SQL = "SELECT furnitura.idFurnituri, furnitura.nasvanie FROM furnitura";
            try
            {
                DataTable dt = Program.DBController.SelectQuery(SQL);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "№";
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].HeaderText = "Название";
                dataGridView1.Columns[1].Width = 350;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nasvanie = textBox1.Text;
            string SQL = "INSERT INTO furnitura(nasvanie) VALUES(N'" + nasvanie + "')";
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
            textBox1.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            string nasvanie = textBox1.Text;
            string SQL = "UPDATE furnitura SET nasvanie = N'" + nasvanie + "' WHERE idFurnituri = '" + id + "'";
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
            string SQL = "DELETE FROM furnitura WHERE idFurnituri = '" + id + "'";
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
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            dataGridUpdate();
        }
    }
}
