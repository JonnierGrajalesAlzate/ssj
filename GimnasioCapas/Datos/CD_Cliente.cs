using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Usar las clases para SQL
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class CD_Cliente
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad {  get; set; }

        public bool encontro = false;

        //Instancia para conctar y desconectar de la BD
        private CD_conexion conexion=new CD_conexion();

        //Variable para lectura de datos en la BD
        private SqlDataReader lector = null;

        //Variable para ejecutar los comandos SQL
        private SqlCommand comando = null;

        /* SERVICIOS QUE CONSUMIRA LAS OPCIONES DEL CLIENTE */
        public void insertar(int id,string nom,string ape,int edad)
        {
            comando=new SqlCommand("dbo.RegistrarCliente");
            comando.Connection = conexion.conectar();//Conectar a la BD
            //Indicar que el comando es de tipo procedimiento almacenado
            comando.CommandType=CommandType.StoredProcedure;

            //Mandar los parametros al procedimiento almacenado
            comando.Parameters.AddWithValue("@Id", id);
            comando.Parameters.AddWithValue("@Nombre", nom);
            comando.Parameters.AddWithValue("@Apellido", ape);
            comando.Parameters.AddWithValue("@Edad", edad);

            //Ejecutar el comando
            comando.ExecuteNonQuery();
            conexion.desconectar(); //Desconectar la BD
        }

        //Actualizar datos
        public void actualizar(int id, string nom, string ape, int edad)
        {
            comando = new SqlCommand("dbo.ActualizarCliente");
            comando.Connection = conexion.conectar();//Conectar a la BD
            //Indicar que el comando es de tipo procedimiento almacenado
            comando.CommandType = CommandType.StoredProcedure;

            //Mandar los parametros al procedimiento almacenado
            comando.Parameters.AddWithValue("@Id", id);
            comando.Parameters.AddWithValue("@Nombre", nom);
            comando.Parameters.AddWithValue("@Apellido", ape);
            comando.Parameters.AddWithValue("@Edad", edad);

            //Ejecutar el comando
            comando.ExecuteNonQuery();
            conexion.desconectar(); //Desconectar la BD
        }

        //eliminar datos
        public void eliminar(int id)
        {
            comando = new SqlCommand("dbo.EliminarCliente");
            comando.Connection = conexion.conectar();//Conectar a la BD
            //Indicar que el comando es de tipo procedimiento almacenado
            comando.CommandType = CommandType.StoredProcedure;

            //Mandar los parametros al procedimiento almacenado
            comando.Parameters.AddWithValue("@Id", id);
            
            //Ejecutar el comando
            comando.ExecuteNonQuery();
            conexion.desconectar(); //Desconectar la BD
        }

        //Buscar un dato
        public void buscar(int id)
        {
            comando = new SqlCommand("dbo.BuscarCliente");
            comando.Connection = conexion.conectar();//Conectar a la BD
            //Indicar que el comando es de tipo procedimiento almacenado
            comando.CommandType = CommandType.StoredProcedure;

            //Mandar los parametros al procedimiento almacenado
            comando.Parameters.AddWithValue("@Id", id);

            lector=comando.ExecuteReader();
            //Validar si encontro el cliente
            if (lector.Read())
            {
                codigo = lector.GetInt32(0);
                nombre=lector.GetString(1);
                apellido=lector.GetString(2);
                edad=lector.GetInt32(3);
                encontro = true;
            }
            else
            {
                encontro=false;
            }
            conexion.desconectar();
        }

        //Metodo para listar (retornar una tabla virtual)
        public DataTable listar()
        {
            DataTable tabla = new DataTable();
            comando = new SqlCommand("dbo.ListarCliente");
            comando.Connection = conexion.conectar();//Conectar a la BD
            //Indicar que el comando es de tipo procedimiento almacenado
            comando.CommandType = CommandType.StoredProcedure;

            //Crear un adaptador para el comando
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            adaptador.Fill(tabla);

            comando.ExecuteNonQuery();
            conexion.desconectar();
            return tabla;
        }

    }//cierre clase
}
