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
        public bool Agregar(string nombreEstudiante, string ape1, string ape2,string email,string foto)
        {
            return conexion.EjecutarComandoSinRetornarDatos($"INSERT INTO ESTUDIANTE(Nombre,PrimerApellido,SegundoApellido,Email,Foto) " +
                $"values ('{nombreEstudiante}','{ape1}','{ape2}','{email}','{foto}')");
        }
        public bool AgregarEstudianteCiclo(string idCiclo) {
            return conexion.EjecutarComandoSinRetornarDatos($"INSERT INTO Alumno_Asignar_Ciclo (Id_estudiante,Id_ciclo)" +
                $" VALUES((SELECT MAX(ID) FROM ESTUDIANTE),{idCiclo})"); 
        }

        public bool Borrar(string idEstudiante)
        {
            return conexion.EjecutarComandoSinRetornarDatos($"DELETE FROM ESTUDIANTE WHERE ID='{idEstudiante}'");
        }
        public bool BorrarEstudianteCiclo(string idEstudiante)
        {
            return conexion.EjecutarComandoSinRetornarDatos($"DELETE FROM Alumno_Asignar_Ciclo WHERE Id_estudiante='{idEstudiante}'");
        }

        public bool Modificar(string id,string nombreEstudiante, string ape1, string ape2, string email, byte[] foto)
        {
            return conexion.EjecutarComandoSinRetornarDatos($"UPDATE ESTUDIANTE SET NOMBRE='{nombreEstudiante}', PRIMERAPELLIDO='{ape1}', SEGUNDOAPELLIDO='{ape2}',EMAIL='{email}',FOTO='{foto}' WHERE ID={id}");
        }

        public DataSet MostrarEstudiantes()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM ESTUDIANTE");
            return conexion.EjecutarSentencia(sentencia);
        }
    }
}
