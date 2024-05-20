using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mysqlx.Crud.Order.Types;

namespace CapaPresentacion
{
    public partial class frmProducto : Form
    {
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_barberia;";
        public frmProducto()
        {
            InitializeComponent();
        }
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
                querydgv = "SELECT Id_Producto, Producto, Precio, Descripcion, Tipo FROM producto WHERE Id_Producto = " + textId_Consulta.Text;
            }
            else
            {
                querydgv = "SELECT Id_Producto, Producto, Precio, Descripcion, Tipo FROM producto";
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

        

        private void cargadgv()
        {
            dataGridView1.DataSource = ListarEmpleados();
        }
        private void frmProducto_Load(object sender, EventArgs e)
        {
            cargadgv();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tipo = "";
            if (comboBox1.SelectedIndex.ToString() == "0")
            {
               tipo = "Producto";
            }
            else
            {
                tipo = "Servicio";

            }
            string query = "Insert into producto(Producto, Precio, Descripcion, Tipo) VALUES" +
                " ('"+textBox1.Text+"',"+textBox3.Text+",'"+textBox2.Text+ "', '" + tipo+ "')";

            using (MySqlConnection dbConnection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand commandDB = new MySqlCommand(query, dbConnection))
                {
                    try
                    {
                        dbConnection.Open();
                        commandDB.ExecuteNonQuery();
                        MessageBox.Show("Producto insertado con éxito.");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error al insertar Producto: " + error.ToString());
                    }
                }
            }
        }
        ModificarProducto ModificarProducto = new ModificarProducto ();
        private void button3_Click(object sender, EventArgs e)
        {
            ModificarProducto.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cargadgv();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "Delete from producto where Id_Producto="+int.Parse(textId_Consulta.Text);

            using (MySqlConnection dbConnection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand commandDB = new MySqlCommand(query, dbConnection))
                {
                    try
                    {
                        dbConnection.Open();
                        commandDB.ExecuteNonQuery();
                        MessageBox.Show("Producto eliminado con éxito.");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error al eliminar Producto: " + error.ToString());
                    }
                }
            }
        }
    }
}
