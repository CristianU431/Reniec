using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

//Declarar los namespace
using System.Data; // con bases de datos
using System.Data.SqlClient; // sql server
using System.Configuration; // web config

namespace ServicioReniec
{
    /// <summary>
    /// Descripción breve de wsCiudadano
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsCiudadano : System.Web.Services.WebService
    {
        // Traer la cadena de conexion desde el archivo seguro desde web.config
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        private static SqlConnection conexion = new SqlConnection(cadena);

        [WebMethod(Description = "Listar los datos de un Ciudadano")]
        public DataSet Listar()
        {
            string consulta = "select * from DocIdentidad";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataSet data = new DataSet();
            adapter.Fill(data);
            return data;
        }

        [WebMethod(Description = "Agregar un registro de un Ciudadano")]
        public bool Agregar(int DNI, string Nombres, string ApellidoPaterno, string ApellidoMaterno, string FechaNacimiento, string Sexo, string EstadoCivil, string Direccion)
        {
            try
            {
                string consulta = "insert into DocIdentidad values('" + DNI + "','" + Nombres + "','" + ApellidoPaterno + "','" + ApellidoMaterno + "','" + FechaNacimiento + "','" + Sexo + "','" + EstadoCivil + "','" + Direccion + "')";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                conexion.Open();
                // Ejecutar la consulta
                int i = comando.ExecuteNonQuery();
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod(Description = "Eliminar un registro de un Ciudadano")]
        public bool Eliminar(int DNI)
        {
            try
            {
                string consulta = "Delete from DocIdentidad where Dni = '" + DNI + "'";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                conexion.Open();
                int i = comando.ExecuteNonQuery();
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod(Description = "Actualizar un registro de un Ciudadano")]
        public bool Actualizar(int DNI, string Nombres, string ApellidoPaterno, string ApellidoMaterno, string FechaNacimiento, string Sexo, string EstadoCivil, string Direccion)
        {
            try
            {
                string consulta = " UPDATE DocIdentidad SET Nombres = '" + Nombres + "',ApellidoPaterno = '" + ApellidoPaterno + "',ApellidoMaterno = '" + ApellidoMaterno + "',FechaNacimiento ='" + FechaNacimiento + "',Sexo = '" + Sexo + "',EstadoCivil = '" + EstadoCivil + "',Direccion = '" + Direccion + "' Where DNI = '" + DNI + "'";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                conexion.Open();
                int i = comando.ExecuteNonQuery();
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod(Description = "Buscar en la tabla DocIdentidad")]
        public DataSet Buscar(int DNI)
        {
            string consulta = String.Empty;
                consulta = "select * from DocIdentidad where Dni = '" + DNI + "'";
            SqlCommand command = new SqlCommand(consulta, conexion);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet data = new DataSet();
            adapter.Fill(data);
            return data;
        }
    }
}
