using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Winser.objetos
{
	public class ConexionSQL
	{
        private string datos = $"Server=WinServer; Database=itsur; User Id=sa; Password=Pokem@ster101;";
        private SqlConnection conexion;

        public ConexionSQL()
        {
            conexion = new SqlConnection(datos);
        }

        public SqlConnection getConexion()
        {
            return conexion;
        }
    }
}