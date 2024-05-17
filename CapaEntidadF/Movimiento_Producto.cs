using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidadF
{
    public class Movimiento_Producto
    {
        public int id_movimiento_producto { get; set; }
        public int id_movimiento { get; set; }
        public int id_sucursal_producto { get; set; }
        public string producto { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }
        public double subtotal { get; set; }
    }
}
