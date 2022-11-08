using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminIES.DLL
{
    internal class Conexion
    {
        private string cadenaConexion = "Data Source=DESKTOP-TI4PMR8; Initial Catalog=PruebaEstudiantes; Integrated Security = True";
        SqlConnection sqlConnection;

        public SqlConnection EstablecerConexion() {          
            this.sqlConnection = new SqlConnection(this.cadenaConexion);
            return sqlConnection;
        }

        public bool EjecutarComandoSinRetornarDatos(string strComando) {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = strComando;
                sqlCommand.Connection = this.EstablecerConexion();
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch (Exception ex) { 
                return false;
            }
        
        }

        public DataSet EjecutarSentencia(SqlCommand sqlComando) {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand = sqlComando;
                sqlCommand.Connection = this.EstablecerConexion();
                adapter.SelectCommand = sqlCommand;
                sqlConnection.Open();
                adapter.Fill(ds);
                sqlConnection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }
    }
}
