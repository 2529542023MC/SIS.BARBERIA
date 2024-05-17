using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidadF
{
    public class Movimiento
    {
        public int id_movimiento { get; set; }
        public double precio_total { get; set; }
        public int cantidad_total { get; set; }
        public string observacion { get; set; }
        public string tipo_movimiento { get; set; }
        public string usuario { get; set; }
        public int id_cliente { get; set; }


    }
}
