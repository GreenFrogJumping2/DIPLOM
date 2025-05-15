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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void заказчикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSakaschiki FormSakaschiki = new FormSakaschiki();
            FormSakaschiki.ShowDialog();
        }

        private void видыИзделийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVidiIsdeliy FormVidiIsdeliy = new FormVidiIsdeliy();
            FormVidiIsdeliy.ShowDialog();
        }

        private void фурнитураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFurnitura formFurnitura = new FormFurnitura();
            formFurnitura.ShowDialog();
        }

        private void фурнитураToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormSakupkaFurnituri formSakupkaFurnituri = new FormSakupkaFurnituri();
            formSakupkaFurnituri.ShowDialog();
        }

        private void кожаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKoja formKoja = new FormKoja();
            formKoja.ShowDialog();
        }

        private void заказыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormSakasi formSakasi = new FormSakasi();
            formSakasi.ShowDialog();
        }

        private void изделияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIsdelia formIsdelia = new FormIsdelia();
            formIsdelia.ShowDialog();
        }

        private void остаткиКожиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOstatkiKoji formOstatkiKoji = new FormOstatkiKoji();
            formOstatkiKoji.ShowDialog();
        }

        private void остаткиФурнитурыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOstatkiFurnituri formOstatkiFurnituri = new FormOstatkiFurnituri();
            formOstatkiFurnituri.ShowDialog();
        }
    }
}
