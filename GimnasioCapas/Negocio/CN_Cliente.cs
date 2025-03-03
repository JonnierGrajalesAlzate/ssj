using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;

namespace Negocio
{
    public class CN_Cliente
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }

        public bool encontro = false;

        private CD_Cliente objCliente=new CD_Cliente();
        public void insertarCliente(int id,string nom,string ape, int edad)
        {
            objCliente.insertar(id,nom,ape,edad);
        }

        public void actualizarCliente(int id, string nom, string ape, int edad)
        {
            objCliente.actualizar(id, nom, ape, edad);
        }

        public void eliminarCliente(int id)
        {
            objCliente.eliminar(id);
           
        }
        public void buscarCliente(int id)
        {
            objCliente.buscar(id);
            if (objCliente.encontro)
            {
                this.codigo = objCliente.codigo;
                this.nombre = objCliente.nombre;
                this.apellido = objCliente.apellido;
                this.edad = objCliente.edad;
                encontro = true;
            }
            else
            {
                encontro = false;
            }
        }

        public DataTable listarCliente()
        {
            return objCliente.listar();
        }
    }//clase
}
