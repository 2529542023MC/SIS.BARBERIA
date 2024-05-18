using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class InsertarUsuario : Form
    {
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_barberia;";

        public InsertarUsuario()
        {
            InitializeComponent();
            LlenarComboBoxRol();
            LlenarComboBoxSucursal();
        }

        private void LlenarComboBoxRol()
        {
            string query = "SELECT Id_Rol, Nombre FROM rol";
            using (MySqlConnection dbConnection = new MySqlConnection(connectionString))
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
                        cbxRol.DataSource = dt;
                        cbxRol.DisplayMember = "Nombre";
                        cbxRol.ValueMember = "Id_Rol";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al llenar el ComboBox Rol: " + ex.Message);
                    }
                }
            }
        }

        private void LlenarComboBoxSucursal()
        {
            string query = "SELECT Id_Sucursal, Sucursal FROM sucursal";
            using (MySqlConnection dbConnection = new MySqlConnection(connectionString))
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
                        cbxSucursal.DataSource = dt;
                        cbxSucursal.DisplayMember = "Sucursal";
                        cbxSucursal.ValueMember = "Id_Sucursal"; // Assuming Estado itself is the value
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al llenar el ComboBox Estado: " + ex.Message);
                    }
                }
            }
        }

        private void InsertarUsuario_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idRol = Convert.ToInt32(cbxRol.SelectedValue);
            int idSucursal = Convert.ToInt32(cbxSucursal.SelectedValue);


            string query = "INSERT INTO empleado (Id_Empleado, Nombre, Apellido, Telefono, Correo, Direccion, Dui, Contraseña, Estado, Id_Rol, Id_Sucursal, Deleted_at) VALUES" +
                           " (NULL, '" + nombre.Text.Trim() + "', '" + apellido.Text.Trim() + "', '" + telefono.Text.Trim() + "', '" + correo.Text.Trim() + "', '" + direccion.Text.Trim() + "', " +
                           "'" + dui.Text.Trim() + "', '" + contraseña.Text.Trim() + "', '" + cbxEstado_empleado.Text.Trim() + "', " + idRol + ", " + idSucursal + ", NULL)";

            using (MySqlConnection dbConnection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand commandDB = new MySqlCommand(query, dbConnection))
                {
                    try
                    {
                        dbConnection.Open();
                        commandDB.ExecuteNonQuery();
                        MessageBox.Show("Usuario insertado con éxito.");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error al insertar usuario: " + error.ToString());
                    }
                }
            }

            this.Close();
        }



        private void cbxEstado_empleado_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
