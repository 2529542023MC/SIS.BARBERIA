using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class ModificarProducto : Form
    {
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_barberia;";

        public ModificarProducto()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        
        private void ModificarProducto_Load(object sender, EventArgs e)
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
                List<string> updatesP = new List<string>();

                if (nombre.Text.Trim() != "")
                {
                    updatesP.Add("Producto = '" + nombre.Text.Trim() + "'");
                }
                if (precio.Text.Trim() != "")
                {
                    updatesP.Add("Precio = " + precio.Text.Trim() + "");
                }
                if (descripcion.Text.Trim() != "")
                {
                    updatesP.Add("Descripcion = '" + descripcion.Text.Trim() + "'");
                }
                string tipo = "";
                if (cbxTipo.SelectedIndex.ToString() == "0")
                {
                    tipo = "Producto";
                    updatesP.Add("Tipo = '" + tipo + "'");
                }
                else
                {
                    tipo = "Servicio";
                    updatesP.Add("Tipo = '" + tipo + "'");

                }

                ///////////
                
                string queryM = "UPDATE producto SET " + string.Join(", ", updatesP) + " WHERE producto.Id_Producto = " + textBox1.Text.Trim();

                MySqlConnection dbConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDBm = new MySqlCommand(queryM, dbConnection);
                commandDBm.CommandTimeout = 60;

                try
                {
                    dbConnection.Open();
                    commandDBm.ExecuteNonQuery();
                    dbConnection.Close();
                    MessageBox.Show("Dato Actualizado.");

                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al actualizar producto: " + error.Message);
                }
                finally
                {
                    dbConnection.Dispose(); // Libera recursos
                }

                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
