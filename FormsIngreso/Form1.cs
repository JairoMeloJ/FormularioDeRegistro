using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace FormsIngreso
{
    public partial class Datos : Form
    {

        Ayudas help;
        ProgressBar progreso;

        public Datos() => InitializeComponent();

        private void Ingresar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textUsuario.Text != "") && (TextClave.Text != ""))
                {
                    string datos = string.Format("SELECT * FROM Login WHERE admin='" + textUsuario.Text.Trim() + "' AND clave = '" + TextClave.Text.Trim() + "'");

                    DataSet dataset = Conexion.conexion(datos);

                    string administrador = dataset.Tables[0].Rows[0]["admin"].ToString().Trim();
                    string clave = dataset.Tables[0].Rows[0]["clave"].ToString().Trim();

                    if (administrador == textUsuario.Text.Trim() && clave == TextClave.Text.Trim())
                    {
                        progreso = new ProgressBar();
                        this.Hide();
                        progreso.Show();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Usuario o contraseña incorrectos!~.");
            }

            if ((textUsuario.Text == "") && (TextClave.Text == ""))
            {
                MessageBox.Show("Estos campos son obligatorios!~.");
            }
        }
        private void Help_Click(object sender, EventArgs e)
        {
            help = new Ayudas();
            help.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Datos_Load(object sender, EventArgs e)
        {

        }
    }
}
