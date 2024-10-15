using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanalAbejas
{
    public partial class Form1 : Form
    {
        private Panal objPanal = new Panal();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            picCanvas.Refresh();
            try
            {
                objPanal.ReadData(txtLado, picCanvas);
                objPanal.CalcularPuntos();
                objPanal.PlotShape(picCanvas);
            }
            catch(Exception)
            {
                MessageBox.Show("Error en los datos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            objPanal.InitializeData(picCanvas);
            txtLado.Text = "";
        }

        private void txtLado_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && c != 8 && c != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnGraficar_Click(sender, e);
            }
        }
    }
}
