using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using MySql.Data.MySqlClient;

namespace CapaPresentacion
{
    public partial class frmMovimiento : Form
    {
       
        public frmMovimiento()
        {
            InitializeComponent();
        }

        private void frmVenta_Load(object sender, EventArgs e) {
            string querySelect = "SELECT Cliente FROM cliente";

            //Conexion para traer las marcas
            MySqlCommand comando = new MySqlCommand(querySelect, Conexion.prepareConnection());

            //Manda a ejecutar el query
            MySqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                //Agrega lo que trae la consulta al combobox
                cmbCliente.Items.Add(lector.GetString(0));
            }
        }

       

    }
}
