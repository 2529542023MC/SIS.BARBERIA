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
    public class nCliente
    {
        dCliente clienteD = new dCliente();

        public DataTable listarCliente()
        {
            return clienteD.ListarCliente();
        }

        public DataTable buscarCliente(Cliente cliente) {
            return clienteD.BuscarCliente(cliente);
        }

        public string agregarCliente(Cliente cliente)
        {
            return clienteD.AgregarCliente(cliente);
        }
        public string modificarCliente(Cliente cliente)
        {
            return clienteD.ModificarCliente(cliente);
        }
        public string eliminarCliente(Cliente cliente)
        {
            return clienteD.EliminarCliente(cliente);
        }
    }
}
