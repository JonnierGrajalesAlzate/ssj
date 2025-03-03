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
    public class CD_conexion
    {
        //Instancia para establecer la cadena de conexion
        private SqlConnection cnn = new SqlConnection(
            "Server=B13-204-22887;DataBase=gimnasio;Integrated Security=true"
        );

        public SqlConnection conectar()
        {
            if (cnn.State==ConnectionState.Closed) 
                cnn.Open();
            return cnn;
        }

        public SqlConnection desconectar()
        {
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
            return cnn;
        }
    }
}
