using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminIES.DLL
{
    internal class EstudianteDLL
    {
        Conexion conexion;
        public EstudianteDLL()
        {
            conexion = new Conexion();
        }
        public bool Agregar(string nombreEstudiante, string ape1, string ape2,string email,byte[] foto)
        {
            return conexion.EjecutarComandoSinRetornarDatos($"INSERT INTO ESTUDIANTE(Nombre,PrimerApellido,SegundoApellido,Email,Foto) " +
                $"values ('{nombreEstudiante}','{ape1}','{ape2}','{email}','{foto}')");
        }

        public bool Borrar(string idEstudiante)
        {
            return conexion.EjecutarComandoSinRetornarDatos($"DELETE FROM ESTUDIANTE WHERE ID='{idEstudiante}'");
        }

        public bool Modificar(string nombreEstudiante, string id)
        {
            return conexion.EjecutarComandoSinRetornarDatos($"UPDATE ESTUDIANTE SET Nombre='{nombreEstudiante}' WHERE ID={id}");
        }

        public DataSet MostrarCiclos()
        {
            SqlCommand sentencia = new SqlCommand("Select * from ciclo");
            return conexion.EjecutarSentencia(sentencia);
        }
    }
}
