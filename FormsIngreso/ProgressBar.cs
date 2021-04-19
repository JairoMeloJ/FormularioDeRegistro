using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsIngreso
{
    public partial class ProgressBar : Form
    {

        Segundo datos2;
        Datos primero;

        public ProgressBar()
        {
            InitializeComponent();
        }

        private void ProgressBar_Load(object sender, EventArgs e)
        {
        }
        private void Progress_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3; 
            if (panel2.Width >= 832)
            {
                Progress.Stop();
                datos2 = new Segundo();
                primero = new Datos();
                primero.Close();
                this.Close();
                datos2.Show();
            }
        }
    }
}
