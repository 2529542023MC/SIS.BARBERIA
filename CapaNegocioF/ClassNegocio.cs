using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using CapaDatosF;
using CapaEntidadF;


namespace CapaNegocioF
{
    public class ClassNegocio
    {
        ClassDatos objd = new ClassDatos(); //Instancia

        // Métodos para invocar y realizar operaciones relacionadas con
        // la gestión de sucursales y productos.

        public DataTable N_mostrar_sucursal()
        {
            return objd.D_listar_Sucursal();
        }

        public DataTable N_buscar_sucursal(ClassEntidad obje)
        {
            return objd.D_buscar_sucursal(obje);
        }

        public int N_mantenimiento_sucursal(ClassEntidad obje)
        {
            return objd.D_mantenimiento_sucursal(obje);
        }

        public string N_Modificar_Sucursal(Sucursal suc)
        {
            return objd.ModificarSucursal(suc);
        }

        public string N_Eliminar_Sucursal(Sucursal suc)
        {
            return objd.EliminarSucursal(suc);
        }

        public DataTable N_Listar_Productos()
        {
            return objd.ListarProductos();
        }

        public string N_AgregarSucursalProducto(int id, int producto_id, int stock)
        {
            return objd.AgregarSucursalProducto(id, producto_id, stock);
        }
    }
}
