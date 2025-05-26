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
    public partial class FormSpisanieKoji : Form
    {
        string listId;
        public FormSpisanieKoji(string id)
        {
            InitializeComponent();
            listId = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = dateTimePicker1.Value.ToString("MM.dd.yyyy");
            string prichina = comboBox1.Text;
            string SQL = "UPDATE listiKoji SET dataSpisania = '" + data + "', prichinaSpisania = N'" + prichina + "' WHERE idLista = " + listId;
            Program.DBController.Query(SQL);
            Close();
        }
    }
}
