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
using CapaEntidadF;
using CapaNegocioF;
using Mysqlx;

namespace CapaPresentacion
{
    public partial class frmMovimiento : Form
    {
        Movimiento mov = new Movimiento();
        Movimiento_Producto movProd = new Movimiento_Producto();
        nMovimiento nMovimiento = new nMovimiento();
        Sucursal sucursal = new Sucursal();
        Producto producto = new Producto();
        ErrorProvider error = new ErrorProvider();

        int stock = 0;
        int stockMinimo = 0;
        public frmMovimiento()
        {
            InitializeComponent();
            cmbSucursal.DataSource = nMovimiento.listarSucursal();
            cmbSucursal.DisplayMember = "Sucursal";
            cmbSucursal.ValueMember = "Id_Sucursal";

            cmbCliente.DataSource = nMovimiento.listarCliente();
            cmbCliente.DisplayMember = "Cliente";
            cmbCliente.ValueMember = "Id_Cliente";

            DataRowView selectedRow = cmbSucursal.SelectedItem as DataRowView;
            sucursal.id_sucursal = int.Parse(selectedRow["Id_Sucursal"].ToString());
            dgvProd.DataSource = nMovimiento.listarProductos(sucursal);
        }



        public void limpiarProducto()
        {
            txtId.Text = "";
            txtProducto.Text = "";
            txtPrecio.Text = "";
            txtDesc.Text = "";
            txtCantidad.Text = "";
            txtBuscar.Text = "";
        }

        public void limpiarMov()
        {
            txtObservacion.Text = "";
            txtCantidadT.Text = "";
            txtTotal.Text = "";
            dgvProd.DataSource = nMovimiento.listarProductos(sucursal);
            dgvMov.Rows.Clear();
        }


        private void frmVenta_Load(object sender, EventArgs e) {

        }

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedRow = cmbSucursal.SelectedItem as DataRowView;
            sucursal.id_sucursal = int.Parse(selectedRow["Id_Sucursal"].ToString());
            dgvProd.DataSource = nMovimiento.listarProductos(sucursal);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                producto.producto = txtBuscar.Text;
                dgvProd.DataSource = nMovimiento.buscarProducto(producto, sucursal);
            }
            else
            {
                dgvProd.DataSource = nMovimiento.listarProductos(sucursal);
            }
        }

        private void dgvProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvProd.CurrentRow.Cells["Id"].Value.ToString();
            txtProducto.Text = dgvProd.CurrentRow.Cells["Producto"].Value.ToString();
            txtPrecio.Text = dgvProd.CurrentRow.Cells["Precio"].Value.ToString();
            txtDesc.Text = dgvProd.CurrentRow.Cells["Descripcion"].Value.ToString();

            stock = int.Parse(dgvProd.CurrentRow.Cells["Stock"].Value.ToString());
            stockMinimo = int.Parse(dgvProd.CurrentRow.Cells["Stock_Min"].Value.ToString());
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                error.Clear();

                if (cmbTipMov.SelectedIndex.ToString() == "1")
                {
                    if ((stock - int.Parse(txtCantidad.Text)) < stockMinimo)
                    {
                        MessageBox.Show("El stock actual es de: " + stock + "\nEl stock minimo es: " + stockMinimo,
                            "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else { 

                    double subtotal = double.Parse(txtCantidad.Text) * double.Parse(txtPrecio.Text);

                    DataGridViewRow row = new DataGridViewRow();

                    // Agrega las celdas a la nueva fila y asigna los valores de los TextBox
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = txtId.Text });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = txtProducto.Text });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = txtPrecio.Text });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = txtCantidad.Text });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = subtotal.ToString() });

                    // Agrega la fila al DataGridView
                    dgvMov.Rows.Add(row);
                    CalcularTotales();
                    limpiarProducto();
                    }
                }
                else
                {
                    double subtotal = double.Parse(txtCantidad.Text) * double.Parse(txtPrecio.Text);

                    DataGridViewRow row = new DataGridViewRow();

                    // Agrega las celdas a la nueva fila y asigna los valores de los TextBox
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = txtId.Text });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = txtProducto.Text });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = txtPrecio.Text });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = txtCantidad.Text });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = subtotal.ToString() });

                    // Agrega la fila al DataGridView
                    dgvMov.Rows.Add(row);
                    CalcularTotales();
                    limpiarProducto();
                }
            }
            else
            {
                error.SetError(txtCantidad, "Campo Obligatorio");
            }
                
        }
        private void CalcularTotales()
        {
            decimal totalCantidad = 0;
            decimal totalPrecio = 0;

            foreach (DataGridViewRow row in dgvMov.Rows)
            {
                // Verifica si la fila es una fila de datos y no una fila nueva o de encabezado
                if (!row.IsNewRow)
                {
                    // Obtén los valores de cantidad y precio de las celdas de la fila
                    if (decimal.TryParse(row.Cells["Cantidad"].Value?.ToString(), out decimal cantidad) &&
                        decimal.TryParse(row.Cells["Precio"].Value?.ToString(), out decimal precio))
                    {
                        // Suma la cantidad y el precio total
                        totalCantidad += cantidad;
                        totalPrecio += cantidad * precio;
                    }
                }
            }

            // Actualiza los controles o muestra los totales en algún lugar
            txtCantidadT.Text = totalCantidad.ToString();
            txtTotal.Text = totalPrecio.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarMov();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool validar = Validaciones.soloNumeros(e);
            if (!validar)
            {
                error.SetError(txtCantidad, "Solo números");
            }
            else
            {
                error.Clear();
            }
        }

        public Movimiento datosMov()
        {
            if (String.IsNullOrEmpty(txtObservacion.Text))
            {
                error.SetError(txtObservacion, "Campo obligatorio");
                return null;
            }else if (dgvMov.Rows.Count == 0)
            {
                error.SetError(dgvMov, "Agregue un detalle con productos");
                return null;
            }

            error.Clear();

            mov.observacion = txtObservacion.Text;
            mov.cantidad_total = int.Parse(txtCantidadT.Text);
            mov.precio_total = double.Parse(txtTotal.Text);

            if (cmbTipMov.SelectedIndex.ToString() == "0")
            {
                mov.tipo_movimiento = "Compra";
            }
            else
            {
                mov.tipo_movimiento = "Ventas";

            }
            mov.usuario = "Marcela";

            DataRowView selectedRow = cmbCliente.SelectedItem as DataRowView;
            int cliente = int.Parse(selectedRow["Id_Cliente"].ToString());
            mov.id_cliente= cliente;

            return mov;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (datosMov() == null)
            {
                MessageBox.Show("No se puede agregar el movimiento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("¿Desea registrar la " + mov.tipo_movimiento + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = nMovimiento.agregarMovimiento(datosMov());
                    string mensaje="";
                    foreach (DataGridViewRow row in dgvMov.Rows)
                    {
                        // Verifica si la fila es una fila de datos y no una fila nueva o de encabezado
                        if (!row.IsNewRow)
                        {
                            movProd.id_movimiento = id;
                            movProd.id_sucursal_producto = int.Parse(row.Cells["Id"].Value.ToString()); 
                            movProd.cantidad = int.Parse(row.Cells["Cantidad"].Value.ToString());
                            movProd.precio = double.Parse(row.Cells["Precio"].Value.ToString());
                            movProd.subtotal = double.Parse(row.Cells["Subtotal"].Value.ToString());

                            nMovimiento.agregarMovimientoProducto(movProd);

                            if (mov.tipo_movimiento == "Compra")
                            {
                               mensaje = nMovimiento.agregarStock(movProd);
                            }
                            else
                            {
                                mensaje = nMovimiento.disminuirStock(movProd);
                            }
                        }
                    }
                    limpiarMov();
                    MessageBox.Show(mensaje,"Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }
    }
}
