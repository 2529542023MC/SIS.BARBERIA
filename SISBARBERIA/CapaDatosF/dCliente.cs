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
    internal class dCliente
    {
        //Cadena de conexion
        public DataTable listarCliente()
        {
            string query = "SELECT * FROM cliente";
            MySqlCommand comando = new MySqlCommand(query, Conexion.prepareConnection());
            MySqlDataAdapter da = new MySqlDataAdapter(comando);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable buscarCliente(string nombre)
        {
            string query = "SELECT * FROM cliente WHERE Cliente=@Cliente";

            MySqlCommand comando = new MySqlCommand(query, Conexion.prepareConnection());
            comando.Parameters.AddWithValue("@Cliente", nombre);

            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;
        }

        /*  public void AgregarCliente(Cliente cliente)
          {
              string query = "INSERT INTO cliente (Nombre, Telefono, Correo) VALUES (@Nombre, @Telefono, @Correo)";

              using (MySqlConnection connection = Conexion.prepareConnection())
              {
                  MySqlCommand command = new MySqlCommand(query, connection);
                  command.Parameters.AddWithValue("@Nombre", cliente);
                  command.Parameters.AddWithValue("@Telefono", Telefono);
                  command.Parameters.AddWithValue("@Correo", Correo);

                  command.ExecuteNonQuery();
              }
          }

          public void ModificarCliente()
          {
              string query = "UPDATE cliente SET Telefono=@Telefono, Correo=@Correo WHERE Nombre=@Nombre";

              using (MySqlConnection connection = Conexion.prepareConnection())
              {
                  MySqlCommand command = new MySqlCommand(query, connection);
                  command.Parameters.AddWithValue("@Nombre", Nombre);
                  command.Parameters.AddWithValue("@Telefono", Telefono);
                  command.Parameters.AddWithValue("@Correo", Correo);

                  command.ExecuteNonQuery();
              }
          }

          public void EliminarCliente()
          {
              string query = "DELETE FROM cliente WHERE Nombre=@Nombre";

              using (MySqlConnection connection = Conexion.prepareConnection())
              {
                  MySqlCommand command = new MySqlCommand(query, connection);
                  command.Parameters.AddWithValue("@Nombre", Nombre);

                  command.ExecuteNonQuery();
              }
          }*/

    }
}
