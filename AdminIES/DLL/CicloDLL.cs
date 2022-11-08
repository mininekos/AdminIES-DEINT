using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminIES.DLL
{
    internal class CicloDLL
    {
        Conexion conexion;
        public CicloDLL()
        {
            conexion = new Conexion();
        }
        public bool Agregar(string nombreCiclo) {
            return conexion.EjecutarComandoSinRetornarDatos($"Insert into Ciclo(Nombre) values ('{nombreCiclo}')");
        }

        public bool Borrar(string idCiclo)
        {
            return conexion.EjecutarComandoSinRetornarDatos($"DELETE FROM Ciclo WHERE ID='{idCiclo}'");
        }

        public bool Modificar(string nombreCiclo, string id)
        {
            return conexion.EjecutarComandoSinRetornarDatos($"UPDATE CICLO SET Nombre='{nombreCiclo}' WHERE ID={id}");
        }

        public DataSet MostrarCiclos() {
            SqlCommand sentencia = new SqlCommand("Select * from ciclo");
            return conexion.EjecutarSentencia(sentencia);
        }
    }
}
