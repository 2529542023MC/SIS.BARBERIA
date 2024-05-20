using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CapaEntidadF;
using CapaNegocioF;
using MySqlX.XDevAPI;
using Mysqlx;
using System.Collections;

// Gestiona la funcionalidad del formulario principal
namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        // Instancias de clases
        ClassEntidad objent = new ClassEntidad();
        ClassNegocio objneg = new ClassNegocio();
        Sucursal objSuc = new Sucursal();

        // Constructor del formulario
        public Form1()
        {
            InitializeComponent();
            // Carga datos iniciales
            dgvSucursales.DataSource = objneg.N_mostrar_sucursal();
            cbxListProducto.DataSource = objneg.N_Listar_Productos();
            cbxListProducto.DisplayMember = "Producto";
            cbxListProducto.ValueMember = "Id_Producto";
        }

        // Carga asincrónica de sucursales (desactivado)
        private void Form1_Load(object sender, EventArgs e)
        {
            //await CargarSucursalesAsync();
        }

        // Método asincrónico para cargar sucursales
        private async Task CargarSucursalesAsync()
        {
            try
            {
                dgvSucursales.DataSource = await Task.Run(() => objneg.N_mostrar_sucursal());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las sucursales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Función para realizar operaciones de mantenimiento
        private void mantenimiento(string accion)
        {
            // Configuración de entidad
            objent.id_sucursal = txtId.Text;
            objent.sucursal = txtNombre.Text;
            objent.direccion = txtDireccion.Text;
            objent.accion = accion;
            // Ejecución de operación de mantenimiento
            int Id = objneg.N_mantenimiento_sucursal(objent);
            string mensaje = "";
            // Agrega productos a la sucursal
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                // Verifica y agrega productos
                if (!row.IsNewRow)
                {
                    int sucursal_id = Id;
                    int producto_id = int.Parse(row.Cells["Id"].Value.ToString());
                    int stockcantidad = int.Parse(row.Cells["StockMinimo"].Value.ToString());

                    mensaje = objneg.N_AgregarSucursalProducto(Id, producto_id, stockcantidad);
                }
            }
            // Limpia y muestra mensaje de operación
            limpiar();
            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Limpia los campos del formulario
        private void limpiar()
        {
            try
            {
                txtId.Text = "";
                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtBuscar.Text = "";
                dgvSucursales.DataSource = objneg.N_mostrar_sucursal();
                dgvProductos.DataSource = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al limpiar los campos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Limpia campos del formulario al hacer clic en menú
        private void cleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        // Registra una nueva sucursal
        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                if (MessageBox.Show("¿Deseas registrar a " + txtNombre.Text + "?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    mantenimiento("1");
                    limpiar();
                }
            }
        }

        // Modifica una sucursal existente
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                if (datosForm() == null)
                {
                    MessageBox.Show("No se puede modificar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea modificar a " + txtNombre.Text + "?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string mensaje = objneg.N_Modificar_Sucursal(datosForm());
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        limpiar();
                    }
                }
            }
        }

        // Obtiene datos del formulario
        public Sucursal datosForm()
        {
            objSuc.id_sucursal = int.Parse(txtId.Text);
            objSuc.sucursal = txtNombre.Text;
            objSuc.direccion = txtDireccion.Text;
            return objSuc;
        }

        // Elimina una sucursal
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                if (txtId.Text != "")
                {
                    if (MessageBox.Show("¿Desea eliminar a " + txtNombre.Text + "?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string mensaje = objneg.N_Eliminar_Sucursal(datosForm());
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        limpiar();
                    }
                }
            }
        }

        // Busca sucursales en base a texto ingresado
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtBuscar.Text))
                {
                    // Establece los criterios de búsqueda
                    objent.id_sucursal = txtBuscar.Text;
                    objent.sucursal = txtBuscar.Text;
                    objent.direccion = txtBuscar.Text;
                    // Realiza la búsqueda de sucursales
                    DataTable dt = objneg.N_buscar_sucursal(objent);
                    dgvSucursales.DataSource = dt;
                }
                else
                {
                    // Si no hay texto de búsqueda, muestra todas las sucursales
                    dgvSucursales.DataSource = objneg.N_mostrar_sucursal();
                }
            }
            catch (Exception ex)
            {
                // Maneja cualquier error que ocurra durante la búsqueda
                MessageBox.Show("Error al buscar las sucursales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Gestiona el evento de hacer clic en una celda del DataGridView de sucursales
        private void dgvSucursales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Obtiene el índice de la fila seleccionada
                int fila = dgvSucursales.CurrentCell.RowIndex;

                // Muestra la información de la sucursal seleccionada en los TextBox correspondientes
                txtId.Text = dgvSucursales[0, fila].Value.ToString();
                txtNombre.Text = dgvSucursales[1, fila].Value.ToString();
                txtDireccion.Text = dgvSucursales[2, fila].Value.ToString();
            }
            catch (Exception ex)
            {
                // Maneja cualquier error que ocurra al intentar obtener información de la sucursal seleccionada
                MessageBox.Show("Error al obtener información de la sucursal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ErrorProvider para validar entrada de usuario
        ErrorProvider error = new ErrorProvider();

        // botón para agregar un producto
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtStock.Text != "")
            {
                error.Clear();
                DataRowView selectedRow = cbxListProducto.SelectedItem as DataRowView;
                string Produc = selectedRow["Id_Producto"].ToString();

                string subtotal = txtStock.Text;

                DataGridViewRow row = new DataGridViewRow();

                // Agrega las celdas a la nueva fila y asigna los valores de los TextBox
                row.Cells.Add(new DataGridViewTextBoxCell { Value = Produc });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = subtotal });

                // Agrega la fila al DataGridView
                dgvProductos.Rows.Add(row);
                limpiarProducto();
            }
            else
            {
                // Muestra un mensaje de error si el campo de stock está vacío
                error.SetError(txtStock, "Campo Obligatorio");
            }

        }

        // Limpia el campo de stock
        private void limpiarProducto()
        {
            try
            {
                txtStock.Text = "";

            }
            catch (Exception ex)
            {
                // Maneja cualquier error que ocurra al intentar limpiar los campos
                MessageBox.Show("Error al limpiar los campos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
