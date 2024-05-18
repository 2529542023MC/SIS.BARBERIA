using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CapaPresentacion
{
    public partial class frmEmpleado : Form
    {
        public static MySqlConnection prepareConnection()
        {
            //Cadena de conexion
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);

            con.Open();
            return con;
        }

        public DataTable ListarEmpleados()
        {
            string querydgv = "";
            if (textId_Consulta.Text.Trim() != "")
            {
                querydgv = "SELECT Id_Empleado, empleado.Nombre, Apellido, Telefono, Correo," +
                           " empleado.Direccion, Dui, Estado, rol.Nombre, sucursal.Sucursal " +
                           "FROM empleado " +
                           "JOIN rol ON empleado.Id_Rol = rol.Id_Rol " +
                           "JOIN sucursal ON empleado.Id_Sucursal = sucursal.Id_Sucursal " +
                           "WHERE Id_Empleado = " + textId_Consulta.Text+
                           " GROUP BY Id_Empleado, empleado.Nombre, empleado.Apellido, Telefono, Correo, Direccion, Dui, Estado, rol.Nombre, sucursal.Sucursal";
            }
            else
            {
                querydgv = "SELECT Id_Empleado, empleado.Nombre, Apellido, Telefono, Correo," +
                           " empleado.Direccion, Dui, Estado, rol.Nombre, sucursal.Sucursal " +
                           "FROM empleado " +
                           "JOIN rol ON empleado.Id_Rol = rol.Id_Rol " +
                           "JOIN sucursal ON empleado.Id_Sucursal = sucursal.Id_Sucursal " +
                           "GROUP BY Id_Empleado, empleado.Nombre, empleado.Apellido, Telefono, Correo, Direccion, Dui, Estado, rol.Nombre, sucursal.Sucursal";
            }

            MySqlCommand comando = new MySqlCommand(querydgv, prepareConnection());
            MySqlDataAdapter da = new MySqlDataAdapter(comando);

            DataTable dt = new DataTable();
            da.Fill(dt);

            // Verificar si el DataTable tiene filas
            if (textId_Consulta.Text.Trim() != "" && dt.Rows.Count == 0)
            {
                MessageBox.Show("Valor no encontrado en la Base de Datos");
            }

            return dt;
        }

        InsertarUsuario insertarUsuario = new InsertarUsuario();
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_barberia;";
        static string query = "select * from empleado";
        private Form currentChildForm;

        public frmEmpleado()
        {
            InitializeComponent();
            cargadgv();
        }

        private void cargadgv()
        {
            dgvDatos.DataSource = ListarEmpleados();
        }

        private void OpenForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                //Abrir
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            //panelEscritorio.Controls.Add(childForm);
            //panelEscritorio.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //frmHomeMenu.Text = childForm.Text;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertarUsuario.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dgvDatos.DataSource = ListarEmpleados();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void eliminar_Click_Click(object sender, EventArgs e)
        {
            if (textId_Consulta.Text.Trim() == "")
            {
                MessageBox.Show("Escriba primero el ID del Usuario que desea eliminar.");
            }
            else
            {
                string queryE = "DELETE FROM empleado WHERE Id_Empleado=" + textId_Consulta.Text.Trim();
                MySqlConnection dbConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDB = new MySqlCommand(queryE, dbConnection);
                commandDB.CommandTimeout = 60;

                try
                {
                    dbConnection.Open();
                    MySqlDataReader reader = commandDB.ExecuteReader();
                    dbConnection.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }
                this.Close();
            }
        }

        ModificarCiente modificarCiente = new ModificarCiente();
        private void btnModificar_Click_Click(object sender, EventArgs e)
        {
            modificarCiente.Show();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (textId_Consulta.Text.Trim() == "")
            {
                MessageBox.Show("Escriba primero el ID del Usuario que desea Desactivar.");
            }
            else
            {
                string queryD = "UPDATE empleado SET Estado = 'Inactivo' WHERE empleado.Id_Empleado=" + textId_Consulta.Text.Trim();
                MySqlConnection dbConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDB = new MySqlCommand(queryD, dbConnection);
                commandDB.CommandTimeout = 60;

                try
                {
                    dbConnection.Open();
                    MySqlDataReader reader = commandDB.ExecuteReader();
                    dbConnection.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }
                this.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textId_Consulta.Text.Trim() == "")
            {
                MessageBox.Show("Escriba primero el ID del Usuario que desea Activar.");
            }
            else
            {
                string queryD = "UPDATE empleado SET Estado = 'Activo' WHERE empleado.Id_Empleado=" + textId_Consulta.Text.Trim();
                MySqlConnection dbConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDB = new MySqlCommand(queryD, dbConnection);
                commandDB.CommandTimeout = 60;

                try
                {
                    dbConnection.Open();
                    MySqlDataReader reader = commandDB.ExecuteReader();
                    dbConnection.Close();
                    OpenForm(new frmEmpleado());
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }
                this.Close();
            }
        }
    }
}
