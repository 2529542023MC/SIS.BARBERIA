using CapaEntidadF;
using CapaNegocioF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CapaPresentacion
{
    public partial class frmCliente : Form
    {
        nCliente ncliente = new nCliente();
        Cliente cliente = new Cliente();
        public frmCliente()
        {
            InitializeComponent();
            dgvClientes.DataSource = ncliente.listarCliente();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {

        }

        public Cliente datosForm()
        {
            if (txtId.Text !="")
            {
                cliente.id_cliente = int.Parse(txtId.Text);
            }

            cliente.cliente = txtNombre.Text;
            cliente.telefono = txtTelefono.Text;
            cliente.correo = txtCorreo.Text;

            if(String.IsNullOrEmpty(cliente.cliente))
            {
                error.SetError(txtNombre, "Campo obligatorio");
                return null;
            }
            if(txtTelefono.Text == "    -")
            {
                error.SetError(txtTelefono, "Campo obligatorio");
                return null;

            }
            if (String.IsNullOrEmpty(cliente.correo))
            {
                error.SetError(txtCorreo, "Campo obligatorio");
                return null;
            }

            return cliente;
        }

        public void limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtBuscar.Text = "";
            dgvClientes.DataSource = ncliente.listarCliente();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                if (datosForm() == null)
                {
                    MessageBox.Show("No se puede agregar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea registrar a "+txtNombre.Text+"?","Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                            string mensaje = ncliente.agregarCliente(datosForm());
                            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limpiar();
                    }
                }


            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                if (datosForm() == null)
                {
                    MessageBox.Show("No se puede modificar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else { 
                    if (MessageBox.Show("¿Desea modificar a " + txtNombre.Text + "?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string mensaje = ncliente.modificarCliente(datosForm());
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        limpiar();
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                if (MessageBox.Show("¿Desea eliminar a " + txtNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string mensaje = ncliente.eliminarCliente(datosForm());
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    limpiar();
                }

            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if(txtBuscar.Text != "")
            {
                cliente.cliente = txtBuscar.Text;
                DataTable dt = new DataTable();
                dt = ncliente.buscarCliente(cliente);
                dgvClientes.DataSource = dt;
            }
            else
            {
                dgvClientes.DataSource = ncliente.listarCliente();
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgvClientes.CurrentCell.RowIndex;

            txtId.Text = dgvClientes[0,fila].Value.ToString();
            txtNombre.Text = dgvClientes[1, fila].Value.ToString();
            txtTelefono.Text = dgvClientes[2, fila].Value.ToString();
            txtCorreo.Text = dgvClientes[3, fila].Value.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        ErrorProvider error = new ErrorProvider();

        //VALIDACIONES DE CAMPOS AL MOMENTO DE PRESIONAR UNA TECLA
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool validar = Validaciones.soloLetras(e);
            if (!validar)
            {
                error.SetError(txtNombre, "Solo letras");
            }
            else
            {
                error.Clear();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool validar = Validaciones.soloNumeros(e);
            if (!validar)
            {
                error.SetError(txtTelefono, "Solo números");
            }
            else
            {
                error.Clear();
            }

        }

        //VALIDACIONES AL MOMENTO DE DEJAR CAMPOS VACIOS
        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (Validaciones.textVacios(txtNombre)){
                error.SetError(txtNombre, "Campo Obligatorio");
            }else
            {
                error.Clear();
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (!Validaciones.validarCorreo(txtCorreo.Text))
            {
                error.SetError(txtCorreo, "Correo inválido");
            }
            else
            {
                error.Clear();
            }
        }

    }
}
