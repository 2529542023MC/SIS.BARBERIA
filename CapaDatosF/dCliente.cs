using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using CapaEntidadF;

namespace CapaDatosF
{
    public class dCliente
    {
        public DataTable ListarCliente()
        {
            string query = "SELECT Id_Cliente, Cliente,Telefono,Correo FROM cliente WHERE Deleted_at IS NULL";
            MySqlCommand comando = new MySqlCommand(query, Conexion.prepareConnection());
            MySqlDataAdapter da = new MySqlDataAdapter(comando);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable BuscarCliente(Cliente cliente)
        { 
            string query = "sp_buscar_cliente";
            MySqlCommand comando = new MySqlCommand(query, Conexion.prepareConnection());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("p_Cliente", cliente.cliente);

            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;
        }

         public string AgregarCliente(Cliente cliente)
          {
              string query = "INSERT INTO cliente (Cliente, Telefono, Correo) VALUES (@Nombre, @Telefono, @Correo)";

              using (MySqlConnection connection = Conexion.prepareConnection())
              {
                try
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", cliente.cliente);
                    command.Parameters.AddWithValue("@Telefono", cliente.telefono);
                    command.Parameters.AddWithValue("@Correo", cliente.correo);


                    if (connection.State == ConnectionState.Open) connection.Close();
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    string mensaje = "Cliente agregado";
                    return mensaje;
                }
                catch (Exception)
                {

                    throw;
                }
                  
            }
        }

          public string ModificarCliente(Cliente cliente)
          {
            try
            {
                string query = "UPDATE cliente SET  Cliente=@Nombre, Telefono=@Telefono, Correo=@Correo WHERE Id_Cliente=@Id";

                using (MySqlConnection connection = Conexion.prepareConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", cliente.id_cliente);
                    command.Parameters.AddWithValue("@Nombre", cliente.cliente);
                    command.Parameters.AddWithValue("@Telefono", cliente.telefono);
                    command.Parameters.AddWithValue("@Correo", cliente.correo);

                    if (connection.State == ConnectionState.Open) connection.Close();
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    string mensaje = "Cliente modificado";
                    return mensaje;
                }
            }
            catch (Exception)
            {

                throw;
            }
              
          }

          public string EliminarCliente(Cliente cliente)
          {
            DateTime dateTime = DateTime.Now;
            string query = "UPDATE cliente SET Deleted_at=@Date WHERE Id_Cliente=@Id";

            using (MySqlConnection connection = Conexion.prepareConnection())
              {
                try
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", cliente.id_cliente);
                    command.Parameters.AddWithValue("@Date", dateTime);

                    if (connection.State == ConnectionState.Open) connection.Close();
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    string mensaje = "Cliente eliminado";
                    return mensaje;
                }
                catch (Exception)
                {

                    throw;
                }
                 
              }
          }

    }
}
