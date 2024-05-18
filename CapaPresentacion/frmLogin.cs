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
    public partial class frmLogin : Form
    {
        public string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_barberia;";


        public frmLogin()
        {
            InitializeComponent();
        }

        private struct RGBColors
        {
            public static System.Drawing.Color color1 = System.Drawing.Color.FromArgb(224, 151, 255);
            public static System.Drawing.Color color2 = System.Drawing.Color.FromArgb(152, 245, 249);
            public static System.Drawing.Color color3 = System.Drawing.Color.FromArgb(255, 236, 161);
            public static System.Drawing.Color color4 = System.Drawing.Color.FromArgb(185, 254, 158);
            public static System.Drawing.Color color5 = System.Drawing.Color.FromArgb(255, 164, 165);
            public static System.Drawing.Color color6 = System.Drawing.Color.FromArgb(158, 154, 254);
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NombreUser = txtuser.Text.Trim();
            string ContraUser = txtpass.Text.Trim();

            if (txtuser.Text.Trim() == "" && txtpass.Text.Trim() == "")
            {
                MessageBox.Show("No puede estar vacio");
            }
            else if (VerificarCredenciales(NombreUser, ContraUser))
            {
                frmMenu frmMenu = new frmMenu();
                frmMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña Incorrecto.");
            }
        }
        //verificando datos de usuarios para inicio de sesión
        private bool VerificarCredenciales(string NombreUser, string ContraUser)
        {
            //tring connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_barberia;";
            string query = "SELECT COUNT(*) FROM Empleado WHERE Dui = '" + NombreUser + "' AND Contraseña = '" + ContraUser+ "' and Estado LIKE 'Activo'";

 

            MySqlConnection dbConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDB = new MySqlCommand(query, dbConnection);
            commandDB.CommandTimeout = 60;

            try
            {
                dbConnection.Open();
                int count = Convert.ToInt32(commandDB.ExecuteScalar());
                return count > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de MySql: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error General " + ex.Message);
                return false;
            }
            dbConnection.Close();
            
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited= true;
            System.Diagnostics.Process.Start("https://www.youtube.com/shorts/8qp_CpzX_IE");
        }
    }
}
