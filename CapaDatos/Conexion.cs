using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using CapaEntidad;
using System.Data;
using System.Security.Policy;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaDatos
{
    internal class Conexion
    {
        //Cadena de conexion

        public static MySqlConnection prepareConnection()
        {
            //Objeto de conexion
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_barberia";
            MySqlConnection con = new MySqlConnection(connectionString);
         
            con.Open();
            return con;
        }
       

        /*   MySqlCommand command = new MySqlCommand(query, con);
            command.CommandTimeout = 60;

            //Para determinar la cantidad de datos que devuelve la consulta
            //MySqlDataReader reader;
            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            txtObservacion.Text = reader.GetString(0);
            con.Close();*/

    }
}
