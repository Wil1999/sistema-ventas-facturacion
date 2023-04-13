using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_PUNTO_VENTAS.CONTROLADOR
{
    class ConexionDB
    {
        public static string string_connection = @"Data source= DESKTOP-6JD7FMV\SQLEXPRESS; Initial Catalog= SistemaVentasDB; Integrated Security = true;";
        public static SqlConnection connect = new SqlConnection(string_connection);

        public static void Open()
        {
            if (connect.State == System.Data.ConnectionState.Closed)
            {
                connect.Open();
            }
        }
        public static void Close()
        {
            if (connect.State == System.Data.ConnectionState.Open)
            {
                connect.Close();
            }
        }
    }
}
