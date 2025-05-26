using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace DIPLOM
{
    public partial class FormKoja : Form
    {
        public FormKoja()
        {
            InitializeComponent();
        }

        private void FormKoja_Load(object sender, EventArgs e)
        {
            dataGridUpdate1();
            dataGridUpdate2();
            clear();
            clear2();
        }

        void dataGridUpdate1()
        {
            string SQL = "SELECT * FROM sakupkaKoji";
            try
            {
                DataTable dt = Program.DBController.SelectQuery(SQL);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "№";
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].HeaderText = "Дата закупки";
                dataGridView1.Columns[1].Width = 200;
                comboBoxesUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void dataGridUpdate2()
        {
            string SQL = "SELECT idLista, (N'№' + CAST(sakupkaKoji.idSakupki AS NVARCHAR) + N' от ' + CAST(data AS NVARCHAR)) AS idSakupki, vidKoji, ploshad, stoimost FROM listiKoji JOIN sakupkaKoji ON listiKoji.idSakupki = sakupkaKoji.idSakupki WHERE prichinaSpisania IS NULL";
            DataTable dt = Program.DBController.SelectQuery(SQL);
            dataGridView2.DataSource = dt;
            dataGridView2.Columns[0].HeaderText = "№";
            dataGridView2.Columns[0].Width = 50;
            dataGridView2.Columns[1].HeaderText = "Закупка";
            dataGridView2.Columns[1].Width = 150;
            dataGridView2.Columns[2].HeaderText = "Вид кожи";
            dataGridView2.Columns[2].Width = 130;
            dataGridView2.Columns[3].HeaderText = "Площадь (м2)";
            dataGridView2.Columns[3].Width = 150;
            dataGridView2.Columns[4].HeaderText = "Стоимость (р/м2)";
            dataGridView2.Columns[4].Width = 180;
        }

        void comboBoxesUpdate()
        {
            string SQL = "SELECT idSakupki, (N'№' + CAST(idSakupki AS NVARCHAR) + N' от ' + CAST(data AS NVARCHAR)) AS naim FROM sakupkaKoji";
            try
            {
                DataTable dt = Program.DBController.SelectQuery(SQL);
                comboBox1.DataSource = dt;
                comboBox1.ValueMember = "idSakupki";
                comboBox1.DisplayMember = "naim";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = dateTimePicker1.Value.ToString("MM.dd.yyyy");
            string SQL = "INSERT INTO sakupkaKoji(data) VALUES('" + data + "')";
            try
            {
                Program.DBController.Query(SQL);
                dataGridUpdate1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            string SQL = "DELETE FROM sakupkaKoji WHERE idSakupki = '" + id + "'";
            try
            {
                Program.DBController.Query(SQL);
                clear();
                dataGridUpdate1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void clear()
        {
            dateTimePicker1.Value = DateTime.Now;
            dataGridUpdate1();
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sakupka = comboBox1.SelectedValue.ToString();
            string vidKoji = comboBox2.Text;
            string stoimost = Program.DBController.ConvertToNumeric(textBox1.Text);
            string ploshad = Program.DBController.ConvertToNumeric(textBox2.Text);
            string SQL = "INSERT INTO listiKoji(idSakupki, vidKoji, stoimost, ploshad) VALUES('" + sakupka + "', N'" + vidKoji + "', '" + stoimost + "', '" + ploshad + "')";
            Program.DBController.Query(SQL);
            dataGridUpdate2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id = dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString();
            string sakupka = comboBox1.SelectedValue.ToString();
            string vidKoji = comboBox2.Text;
            string stoimost = Program.DBController.ConvertToNumeric(textBox1.Text);
            string ploshad = Program.DBController.ConvertToNumeric(textBox2.Text);
            string SQL = "UPDATE listiKoji SET idSakupki = '" + sakupka + "', vidKoji = N'" + vidKoji + "', stoimost = '" + stoimost + "', ploshad = '" + ploshad + "' WHERE idLista = " + id;
            Program.DBController.Query(SQL);
            dataGridUpdate2();
            clear2();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string id = dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString();
            string SQL = "DELETE FROM listiKoji WHERE idLista = " + id;
            Program.DBController.Query(SQL);
            dataGridUpdate2();
            clear2();
        }

        void clear2()
        {
            comboBoxesUpdate();
            textBox1.Text = "";
            textBox2.Text = "";
            button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clear2();
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            if (dataGridView2[1, dataGridView2.CurrentRow.Index].Value.ToString() == "")
            {
                return;
            }
            comboBox1.Text = dataGridView2[1, dataGridView2.CurrentRow.Index].Value.ToString();
            comboBox2.Text = dataGridView2[2, dataGridView2.CurrentRow.Index].Value.ToString();
            textBox2.Text = dataGridView2[3, dataGridView2.CurrentRow.Index].Value.ToString();
            textBox1.Text = dataGridView2[4, dataGridView2.CurrentRow.Index].Value.ToString();
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                FormSpisanieKoji formSpisanieKoji = new FormSpisanieKoji(dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString());
                formSpisanieKoji.ShowDialog();
                dataGridUpdate2();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
