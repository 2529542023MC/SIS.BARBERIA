using CapaEntidadF;
using CapaNegocioF;
//using CapaDatosF;
using CapaEntidadF;
using MySql.Data.MySqlClient;
using System;
using MySql.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Mysqlx;
using System.Data.Common;
using System.Collections;

namespace CapaPresentacion
{
    public partial class ModificarCiente : Form
    {
        static string connectionString1 = "datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_barberia;";
        public static MySqlConnection prepareConnection()
        {
            //Cadena de conexion
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);

            con.Open();
            return con;
        }

        public ModificarCiente()
        {
            InitializeComponent();
            
        }


        public DataTable ModificarEmpleado()
        {
            string query = "SELECT Id_Empleado, empleado.Nombre, Apellido, Telefono, Correo," +
                " empleado.Direccion, Dui,Estado,  rol.Nombre, sucursal.Sucursal   FROM empleado JOIN rol on" +
                " empleado.Id_Rol=rol.Id_Rol JOIN sucursal on empleado.Id_Sucursal=sucursal.Id_Sucursal GROUP BY Id_Empleado," +
                " empleado.Nombre, empleado.Apellido, Telefono, Correo, Direccion, Dui, Estado, rol.Nombre, sucursal.Sucursal";
            MySqlCommand comando = new MySqlCommand(query, prepareConnection());
            MySqlDataAdapter da = new MySqlDataAdapter(comando);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void LlenarComboBoxSucursal()
        {
            string query = "SELECT Id_Sucursal, Sucursal FROM sucursal";
            using (MySqlConnection dbConnection = new MySqlConnection(connectionString1))
            {
                using (MySqlCommand commandDB = new MySqlCommand(query, dbConnection))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(commandDB);
                    DataTable dt = new DataTable();

                    try
                    {
                        dbConnection.Open();
                        adapter.Fill(dt);

                        // Asignando los datos al ComboBox
                        cbxSucursalM.DataSource = dt;
                        cbxSucursalM.DisplayMember = "Sucursal";
                        cbxSucursalM.ValueMember = "Id_Sucursal"; // Assuming Estado itself is the value
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al llenar el ComboBox Estado: " + ex.Message);
                    }
                }
            }
        }
        private void LlenarComboBoxRol()
        {
            string query = "SELECT Id_Rol, Nombre FROM rol";
            using (MySqlConnection dbConnection = new MySqlConnection(connectionString1))
            {
                using (MySqlCommand commandDB = new MySqlCommand(query, dbConnection))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(commandDB);
                    DataTable dt = new DataTable();

                    try
                    {
                        dbConnection.Open();
                        adapter.Fill(dt);

                        // Asignando los datos al ComboBox
                        cbxRolM.DataSource = dt;
                        cbxRolM.DisplayMember = "Nombre";
                        cbxRolM.ValueMember = "Id_Rol";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al llenar el ComboBox Rol: " + ex.Message);
                    }
                }
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Por favor Ingrese El ID, no puede estar vacio.");
            }
            else
            {
                // Variables para construir la consulta SQL
                List<string> updates = new List<string>();

                // Verificación y construcción de las actualizaciones
                if (nombreM.Text.Trim() != "")
                {
                    updates.Add("Nombre = '" + nombreM.Text.Trim() + "'");
                }
                if (apellidoM.Text.Trim() != "")
                {
                    updates.Add("Apellido = '" + apellidoM.Text.Trim() + "'");
                }
                if (txtTelefono.Text.Trim() != "")
                {
                    updates.Add("Telefono = '" + txtTelefono.Text.Trim() + "'");
                }
                if (correoM.Text.Trim() != "")
                {
                    updates.Add("Correo = '" + correoM.Text.Trim() + "'");
                }
                if (direccionM.Text.Trim() != "")
                {
                    updates.Add("Direccion = '" + direccionM.Text.Trim() + "'");
                }
                if (duiM.Text.Trim() != "")
                {
                    updates.Add("Dui = '" + duiM.Text.Trim() + "'");
                }
                if (cbxRolM.SelectedValue != null)
                {
                    updates.Add("Id_Rol = " + cbxRolM.SelectedValue);
                }
                if (cbxSucursalM.SelectedValue != null)
                {
                    updates.Add("Id_Sucursal = " + cbxSucursalM.SelectedValue);
                }

                // Verificación de contraseña
                if (textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "")
                {
                    if (textBox3.Text.Trim() == textBox4.Text.Trim())
                    {
                        updates.Add("Contraseña = '" + textBox4.Text.Trim() + "'");
                    }
                    else
                    {
                        MessageBox.Show("Las Contraseñas no coinciden");
                        return; // Termina la ejecución si las contraseñas no coinciden
                    }
                }
                else
                {
                    MessageBox.Show("Los campos de Contraseñas no pueden estar vacios");
                    return; // Termina la ejecución si los campos de contraseña están vacíos
                }

                // Construyendo la consulta SQL final
                string queryM = "UPDATE empleado SET " + string.Join(", ", updates) + " WHERE empleado.Id_Empleado = " + textBox1.Text.Trim();

                MySqlConnection dbConnection = new MySqlConnection(connectionString1);
                MySqlCommand commandDBm = new MySqlCommand(queryM, dbConnection);
                commandDBm.CommandTimeout = 60;

                try
                {
                    dbConnection.Open();
                    commandDBm.ExecuteNonQuery();
                    dbConnection.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al actualizar empleado: " + error.Message);
                }
                finally
                {
                    dbConnection.Dispose(); // Libera recursos
                }

                this.Close();
            }
        }



        private void ModificarCiente_Load(object sender, EventArgs e)
        {
            LlenarComboBoxSucursal();
            LlenarComboBoxRol();
            

        }
    }
}
