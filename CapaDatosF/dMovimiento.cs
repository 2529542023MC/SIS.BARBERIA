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
    public class dMovimiento
    {
        public DataTable ListarMovimiento()
        {
            string query = "SELECT Id_Movimiento, Precio_Total,Cantidad_Total,Observacion,Tipo_Movimiento,Usuario,Id_Cliente " +
                "FROM movimiento WHERE Deleted_at IS NULL";
            MySqlCommand comando = new MySqlCommand(query, Conexion.prepareConnection());
            MySqlDataAdapter da = new MySqlDataAdapter(comando);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable ListarCliente()
        {
            string query = "SELECT Id_Cliente, Cliente FROM cliente WHERE Deleted_at IS NULL";
            MySqlCommand comando = new MySqlCommand(query, Conexion.prepareConnection());
            MySqlDataAdapter da = new MySqlDataAdapter(comando);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable ListarSucursal()
        {
            string query = "SELECT Id_Sucursal, Sucursal FROM sucursal WHERE Deleted_at IS NULL";
            MySqlCommand comando = new MySqlCommand(query, Conexion.prepareConnection());
            MySqlDataAdapter da = new MySqlDataAdapter(comando);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable ListarProductos(Sucursal sucursal)
        {
            string query = "SELECT sucursal_producto.Id_Sucursal_Producto as Id, Producto, Descripcion, Precio, Stock, Stock_Min FROM producto INNER JOIN sucursal_producto " +
                "ON producto.Id_Producto=sucursal_producto.Id_Producto WHERE sucursal_producto.id_sucursal=@Id_Sucursal AND producto.Deleted_at IS NULL";
            MySqlCommand comando = new MySqlCommand(query, Conexion.prepareConnection());
            comando.Parameters.AddWithValue("Id_Sucursal", sucursal.id_sucursal);
            MySqlDataAdapter da = new MySqlDataAdapter(comando);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable BuscarProducto(Producto producto, Sucursal sucursal)
         { 
             string query = "sp_buscar_producto";
             MySqlCommand comando = new MySqlCommand(query, Conexion.prepareConnection());
             comando.CommandType = CommandType.StoredProcedure;
             comando.Parameters.AddWithValue("p_producto", producto.producto);
             comando.Parameters.AddWithValue("p_sucursal", sucursal.id_sucursal);

            MySqlDataAdapter da = new MySqlDataAdapter(comando);
             DataTable dt = new DataTable();

             da.Fill(dt);
             return dt;
         }

        public int AgregarMovimiento(Movimiento movimiento)
          {
              string query = "INSERT INTO movimiento (Precio_Total,Cantidad_Total,Observacion,Tipo_Movimiento,Usuario,Id_Cliente)" +
                " VALUES (@Precio_Total,@Cantidad_Total,@Observacion,@Tipo_Movimiento,@Usuario,@Id_Cliente)";

            using (MySqlConnection connection = Conexion.prepareConnection())
              {
                try
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Precio_Total", movimiento.precio_total);
                    command.Parameters.AddWithValue("@Cantidad_Total", movimiento.cantidad_total);
                    command.Parameters.AddWithValue("@Observacion", movimiento.observacion);
                    command.Parameters.AddWithValue("@Tipo_Movimiento", movimiento.tipo_movimiento);
                    command.Parameters.AddWithValue("@Usuario", movimiento.usuario);
                    command.Parameters.AddWithValue("@Id_Cliente", movimiento.id_cliente);

                  
                    if (connection.State == ConnectionState.Open) connection.Close();
                    connection.Open();
                    command.ExecuteNonQuery();

                    string querys = "SELECT LAST_INSERT_ID()";
                    MySqlCommand commands = new MySqlCommand(querys, connection);
                    commands.ExecuteNonQuery();
                    int movimientoId = Convert.ToInt32(commands.ExecuteScalar());
                    connection.Close();
                    return movimientoId;
                }
                catch (Exception)
                {

                    throw;
                }
                  
            }
        }
        public string AgregarMovimientoProducto(Movimiento_Producto movimiento)
        {
            string query = "INSERT INTO movimiento_producto (Precio,Cantidad,SubTotal,Id_Sucursal_Producto,Id_Movimiento)" +
              " VALUES (@Precio,@Cantidad,@SubTotal,@Id_Sucursal_Producto,@Id_Movimiento);";

            using (MySqlConnection connection = Conexion.prepareConnection())
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Precio", movimiento.precio);
                    command.Parameters.AddWithValue("@Cantidad", movimiento.cantidad);
                    command.Parameters.AddWithValue("@SubTotal", movimiento.subtotal);
                    command.Parameters.AddWithValue("@Id_Sucursal_Producto", movimiento.id_sucursal_producto);
                    command.Parameters.AddWithValue("@Id_Movimiento", movimiento.id_movimiento);

                    if (connection.State == ConnectionState.Open) connection.Close();
                    connection.Open();
                    command.ExecuteNonQuery();

                    string mensaje = "Movimiento agregado";
                    connection.Close();
                    return mensaje;
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public string AgregarStock(Movimiento_Producto movimiento)
        {
            try { 
            
                string query = "UPDATE sucursal_producto SET Stock=Stock+@Cantidad WHERE Id_Sucursal_Producto=@Id";

                using (MySqlConnection connection = Conexion.prepareConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", movimiento.id_sucursal_producto);
                    command.Parameters.AddWithValue("@Cantidad", movimiento.cantidad);

                    if (connection.State == ConnectionState.Open) connection.Close();
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    string mensaje = "Productos agregados";
                    return mensaje;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public string DisminuirStock(Movimiento_Producto movimiento)
        {
            try
            {

                string query = "UPDATE sucursal_producto SET Stock=Stock-@Cantidad WHERE Id_Sucursal_Producto=@Id";

                using (MySqlConnection connection = Conexion.prepareConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", movimiento.id_sucursal_producto);
                    command.Parameters.AddWithValue("@Cantidad", movimiento.cantidad);

                    if (connection.State == ConnectionState.Open) connection.Close();
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    string mensaje = "Producto vendido";
                    return mensaje;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public string ModificarMovimiento(Movimiento movimiento)
          {
            try
            {
                string query = "UPDATE movimiento SET  Precio_Total=@Precio_Total,Cantidad_Total=@Cantidad_Total,Observacion=@Observacion,Tipo_Movimiento=@Tipo_Movimiento,Usuario=@Usuario,Id_Cliente=@Id_Cliente WHERE Id_Movimiento=@Id";

                using (MySqlConnection connection = Conexion.prepareConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", movimiento.id_movimiento);
                    command.Parameters.AddWithValue("@Precio_Total", movimiento.precio_total);
                    command.Parameters.AddWithValue("@Cantidad_Total", movimiento.cantidad_total);
                    command.Parameters.AddWithValue("@Observacion", movimiento.observacion);
                    command.Parameters.AddWithValue("@Tipo_Movimiento", movimiento.tipo_movimiento);
                    command.Parameters.AddWithValue("@Usuario", movimiento.usuario);
                    command.Parameters.AddWithValue("@Id_Cliente", movimiento.id_cliente);

                    if (connection.State == ConnectionState.Open) connection.Close();
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    string mensaje = "Movimiento modificado";
                    return mensaje;
                }
            }
            catch (Exception)
            {

                throw;
            }
              
          }

          public string EliminarMovimiento(Movimiento movimiento)
          {
            DateTime dateTime = DateTime.Now;
            string query = "UPDATE movimiento SET Deleted_at=@Date WHERE Id_Movimiento=@Id";

            using (MySqlConnection connection = Conexion.prepareConnection())
              {
                try
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", movimiento.id_movimiento);
                    command.Parameters.AddWithValue("@Date", dateTime);

                    if (connection.State == ConnectionState.Open) connection.Close();
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    string mensaje = "Movimiento eliminado";
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
