using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatosF;
using CapaEntidadF;

namespace CapaNegocioF
{
    public class nMovimiento
    {
        dMovimiento movimientoD = new dMovimiento();

        public DataTable listarMovimiento()
        {
            return movimientoD.ListarMovimiento();
        }

        public DataTable listarCliente()
        {
            return movimientoD.ListarCliente();
        }

        public DataTable listarSucursal()
        {
            return movimientoD.ListarSucursal();
        }

        public DataTable listarProductos(Sucursal sucursal)
        {
            return movimientoD.ListarProductos(sucursal);
        }

        public DataTable buscarProducto(Producto prod, Sucursal sucursal) {
             return movimientoD.BuscarProducto(prod, sucursal);
        }

        public int agregarMovimiento(Movimiento mov)
        {
            return movimientoD.AgregarMovimiento(mov);
        }

        public string agregarMovimientoProducto(Movimiento_Producto mov)
        {
            return movimientoD.AgregarMovimientoProducto(mov);
        }

        public string agregarStock(Movimiento_Producto mov)
        {
            return movimientoD.AgregarStock(mov);
        }
        public string disminuirStock(Movimiento_Producto mov)
        {
            return movimientoD.DisminuirStock(mov);
        }

        public string modificarMovimiento(Movimiento mov)
        {
            return movimientoD.ModificarMovimiento(mov);
        }
        public string eliminarMovimiento(Movimiento mov)
        {
            return movimientoD.EliminarMovimiento(mov);
        }
    }
}
