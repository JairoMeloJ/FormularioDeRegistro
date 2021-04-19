using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsIngreso
{
    public partial class Segundo : Form
    {
        SqlConnection conex = new SqlConnection(@"Data Source=DESKTOP-F9BVH3I\SQLEXPRESS;Initial Catalog=Tarea6;Integrated Security=True");
        SqlCommand comando;

        public Segundo()
        {
            InitializeComponent(); 
            Llenar();
            textNombre.Enabled = false; textMatricula.Enabled = false; textEdad.Enabled = false; textCarrera.Enabled = false; textPais.Enabled = false; btnRegister.Enabled = false; btnModding.Enabled = false; btnDelete.Enabled = false; textFind.Enabled = false; btnFind.Enabled = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        //Boton registrar.
        public void Help_Click(object sender, EventArgs e)
        {
            try
            {
                conex.Open();
                comando = new SqlCommand($"INSERT INTO Estudiantes VALUES ('{textNombre.Text}','{textMatricula.Text}',{textEdad.Text},'{textCarrera.Text}','{textPais.Text}')", conex);
                comando.ExecuteNonQuery();
                conex.Close();
                Llenar();
                limpiar();
            }
            catch (Exception error)
            {
                MessageBox.Show("Hubo un inconveniente al registrar el estudiante. \n\n" + error.Message);
                conex.Close();
            }
        }

        //Boton actualizar.
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conex.Open();
                comando = new SqlCommand($"UPDATE Estudiantes SET name = '{textNombre.Text}', edad = {textEdad.Text} , carrera = '{textCarrera.Text}'  WHERE matri = '{textMatricula.Text}'", conex);
                comando.ExecuteNonQuery();
                conex.Close();
                Llenar();
                limpiar();
            }
            catch (Exception error)
            {
                MessageBox.Show("Hubo un inconveniente al actualizar. \n\n" + error.Message);
                conex.Close();
            }
        }

        //Boton eliminar.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                conex.Open();
                comando = new SqlCommand($"DELETE FROM Estudiantes WHERE Matri='{textFind.Text}'", conex);
                comando.ExecuteNonQuery();
                conex.Close();
                Llenar();
                limpiar();
            }
            catch (Exception error)
            {
                MessageBox.Show("Hubo un error al eliminar este registro.\n\n" + error.Message);
                conex.Close();
            }
        }

        //Boton buscar.
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                conex.Open();
                comando = new SqlCommand($"SELECT * FROM Estudiantes WHERE matri='{textFind.Text}' OR carrera= '{textFind.Text}'", conex);
                comando.ExecuteNonQuery();
                DataTable tabla = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;
                conex.Close();
                limpiar();
            }
            catch (Exception error)
            {
                MessageBox.Show("Hubo un error al realizar esta busqueda.\n\n" + error.Message);
                conex.Close();
            }
        }
        //-----------------------------------------------


        //Botones extras, cerrar, minimizar y deslogeo.
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Restart();
        }
        //-----------------------------------------------


        //Funcion para actualizar el DataGridView.
        public DataTable Llenar()
        {
            conex.Open();
            comando = new SqlCommand($"SELECT * FROM Estudiantes", conex);
            comando.ExecuteNonQuery();
            DataTable BD = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter(comando);
            adapt.Fill(BD);
            dataGridView1.DataSource = BD;
            conex.Close();
            return BD;
        }

        //Aqui habilito los datos que necesitare llenar y desactivo los inecesarios.
        private void register_CheckedChanged(object sender, EventArgs e)
        {
            btnModding.Enabled = false; btnDelete.Enabled = false; textFind.Enabled = false; btnFind.Enabled = false;
            textNombre.Enabled = true; textMatricula.Enabled = true; textEdad.Enabled = true; textCarrera.Enabled = true; textPais.Enabled = true; btnRegister.Enabled = true;
        }

        private void Delete_CheckedChanged(object sender, EventArgs e)
        {
            btnModding.Enabled = false; btnDelete.Enabled = true; textFind.Enabled = true; btnFind.Enabled = false;
            textNombre.Enabled = false; textMatricula.Enabled = false; textEdad.Enabled = false; textCarrera.Enabled = false; textPais.Enabled = false; btnRegister.Enabled = false;
        }

        private void Find_CheckedChanged(object sender, EventArgs e)
        {
            textNombre.Enabled = false; textMatricula.Enabled = false; textEdad.Enabled = false; textCarrera.Enabled = false; textPais.Enabled = false; btnRegister.Enabled = false; btnModding.Enabled = false; btnDelete.Enabled = false; textFind.Enabled = true; btnFind.Enabled = true;
        }

        private void modding_CheckedChanged(object sender, EventArgs e)
        {
            btnModding.Enabled = true; btnDelete.Enabled = false; textFind.Enabled = false; btnFind.Enabled = false;
            textNombre.Enabled = true; textMatricula.Enabled = true; textEdad.Enabled = true; textCarrera.Enabled = true; textPais.Enabled = false; btnRegister.Enabled = false;
        }
        //-------------------------------------------------------------------

        //Funcion para limpiar casillas.
        public void limpiar()
        {
            textNombre.Text = ""; textMatricula.Text = ""; textEdad.Text = ""; textCarrera.Text = ""; textPais.Text = ""; textFind.Text = "";
        }
    }
}
