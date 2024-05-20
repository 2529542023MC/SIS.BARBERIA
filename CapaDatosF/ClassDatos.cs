using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;  // Librería para manejo de datos en DataTable
using MySql.Data.MySqlClient;  // Librería para conexión y operaciones con MySQL
using CapaEntidadF;  // Clase de entidad referencia
using MySqlX.XDevAPI;  // Librería para operaciones avanzadas con MySQL
using System.Runtime.Remoting;  // Librería para comunicación entre dominios de aplicación

namespace CapaDatosF
{
    public class ClassDatos
    {
        // Método para listar sucursales
        public DataTable D_listar_Sucursal()
        {
            using (MySqlConnection connection = Conexion.prepareConnection())
            {
                MySqlCommand cmd = new MySqlCommand("sp_mostrar_sucursal", connection);  // Llama al procedimiento almacenado para mostrar sucursales
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                try
                {
                    da.Fill(dt);
                    return dt; // Llena el DataTable con las sucursales
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar las sucursales: " + ex.Message);  // Manejo de error
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();  // Cierra la conexión si está abierta
                    }
                }

                return dt;  // Retorna el DataTable con las sucursales
            }
        }

        // Método para buscar sucursal
        public DataTable D_buscar_sucursal(ClassEntidad obje)
        {
            using (MySqlConnection connection = Conexion.prepareConnection())
            {
                MySqlCommand cmd = new MySqlCommand("sp_buscar_sucursal", connection);  // Llama al procedimiento almacenado para buscar sucursal
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("nombre", obje.sucursal);  // Parámetro: nombre de sucursal
                cmd.Parameters.AddWithValue("id", obje.id_sucursal);  // Parámetro: ID de sucursal
                cmd.Parameters.AddWithValue("direction", obje.direccion);  // Parámetro: dirección de sucursal
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    da.Fill(dt);  // Llena el DataTable con la sucursal buscada
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar las sucursales: " + ex.Message);  // Manejo de error
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();  // Cierra la conexión si está abierta
                    }
                }

                return dt;  // Retorna el DataTable con la sucursal buscada
            }
        }

        // Método para realizar mantenimiento de sucursal
        public int D_mantenimiento_sucursal(ClassEntidad obje)
        {
            using (MySqlConnection connection = Conexion.prepareConnection())
            {
                string accion = obje.accion;
                MySqlCommand cmd = new MySqlCommand("sp_mantenimiento_sucursal", connection);  // Llama al procedimiento almacenado para mantenimiento de sucursal
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id_sucursal", obje.id_sucursal);  // Parámetros
                cmd.Parameters.AddWithValue("sucursal", obje.sucursal);  
                cmd.Parameters.AddWithValue("direccion", obje.direccion);  
                cmd.Parameters.Add("accion", MySqlDbType.VarChar, 50).Value = accion;  
                cmd.Parameters["accion"].Direction = ParameterDirection.InputOutput;

                try
                {
                    cmd.ExecuteNonQuery();
                    accion = cmd.Parameters["accion"].Value.ToString();  // Actualiza el valor de acción
                    string querys = "SELECT LAST_INSERT_ID()";  // Obtiene el último ID insertado
                    MySqlCommand commands = new MySqlCommand(querys, connection);
                    commands.ExecuteNonQuery();
                    int movimientoId = Convert.ToInt32(commands.ExecuteScalar());
                    connection.Close();
                    return movimientoId;  // Retorna el ID del movimiento
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al ejecutar el procedimiento almacenado: " + ex.Message);  // Manejo de error
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();  // Cierra la conexión si está abierta
                    }
                }
            }
        }

        // Método para modificar sucursal
        public string ModificarSucursal(Sucursal suc)
        {
            try
            {
                string query = "UPDATE sucursal SET  Sucursal=@sucursal, Direccion=@direccion WHERE Id_Sucursal=@id_sucursal";

                using (MySqlConnection connection = Conexion.prepareConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id_sucursal", suc.id_sucursal);  // Parámetros
                    command.Parameters.AddWithValue("@sucursal", suc.sucursal);  
                    command.Parameters.AddWithValue("@direccion", suc.direccion);  

                    if (connection.State == ConnectionState.Open) connection.Close();
                    connection.Open();
                    command.ExecuteNonQuery();  // Ejecuta la consulta de modificación
                    connection.Close();

                    string mensaje = "Sucursal modificada";
                    return mensaje;  // Retorna el mensaje de éxito
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Método para eliminar sucursal
        public string EliminarSucursal(Sucursal suc)
        {
            DateTime dateTime = DateTime.Now;
            string query = "DELETE FROM sucursal WHERE Id_Sucursal=@Id_sucursal";

            using (MySqlConnection connection = Conexion.prepareConnection())
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id_sucursal", suc.id_sucursal);  // Parámetro

                    if (connection.State == ConnectionState.Open) connection.Close();
                    connection.Open();
                    command.ExecuteNonQuery();  // Ejecuta la consulta de eliminación
                    connection.Close();

                    string mensaje = "Sucursal eliminada";
                    return mensaje;  // Retorna el mensaje de éxito
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        // Método para listar productos
        public DataTable ListarProductos()
        {
            string query = "SELECT Id_Producto, Producto FROM producto WHERE Deleted_at IS NULL";
            MySqlCommand comando = new MySqlCommand(query, Conexion.prepareConnection());
            MySqlDataAdapter da = new MySqlDataAdapter(comando);

            DataTable dt = new DataTable();
            da.Fill(dt);  // Llena el DataTable con los productos
            return dt;  // Retorna el DataTable con los productos
        }

        // Método para agregar producto a sucursal
        public string AgregarSucursalProducto(int id, int producto_id, int stock)
        {
            string query = "INSERT INTO sucursal_producto (Id_Sucursal,Id_Producto,Stock_Min)" +

                            " VALUES (@Id_Sucursal,@Id_Producto,@Stock);";

            using (MySqlConnection connection = Conexion.prepareConnection())
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id_Sucursal", id);  // Parámetros
                    command.Parameters.AddWithValue("@Id_Producto", producto_id);
                    command.Parameters.AddWithValue("@Stock", stock);  // Parámetro: stock mínimo

                    if (connection.State == ConnectionState.Open) connection.Close();
                    connection.Open();
                    command.ExecuteNonQuery();  // Ejecuta la consulta de inserción

                    string mensaje = "Producto agregado";
                    connection.Close();
                    return mensaje;  // Retorna el mensaje de éxito
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}

