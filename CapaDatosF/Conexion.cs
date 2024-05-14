using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace CapaDatosF
{
    internal class Conexion
    {

        public static MySqlConnection prepareConnection()
        {
            //Cadena de conexion
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
         
            con.Open();
            return con;
        }
    }
}
