using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class CN_Servicio
    {
        public int codigo { get; set; }
        public string tipo { get; set; }
        public string estado { get; set; }

        public bool encontro = false;

        private CD_Servicio objServicio = new CD_Servicio();
        public void insertarCliente(int id, string tipo, string estado)
        {
            objServicio.insertar(id, tipo, estado);
        }

        public void actualizarCliente(int id, string tipo, string estado)
        {
            objServicio.actualizar(id, tipo, estado);
        }

        public void eliminarCliente(int id)
        {
            objServicio.eliminar(id);

        }
        public void buscarCliente(int id)
        {
            objServicio.buscar(id);
            if (objServicio.encontro)
            {
                this.codigo = objServicio.codigo;
                this.tipo = objServicio.tipo;
                this.estado = objServicio.estado;
                encontro = true;
            }
            else
            {
                encontro = false;
            }
        }

        public DataTable listarServicio()
        {
            return objServicio.listar();
        }
}
}
