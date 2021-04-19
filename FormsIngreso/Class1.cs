using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FormsIngreso
{
    public class Conexion
    {
        public static DataSet conexion(string cmd)
        {

            SqlConnection conex = new SqlConnection(@"Data Source=DESKTOP-F9BVH3I\SQLEXPRESS;Initial Catalog=Tarea6;Integrated Security=True");
            conex.Open();

            DataSet dataset = new DataSet();
            SqlDataAdapter dataadapter = new SqlDataAdapter(cmd, conex);
            dataadapter.Fill(dataset);

            conex.Close();

            return dataset;

        }
    }
}
