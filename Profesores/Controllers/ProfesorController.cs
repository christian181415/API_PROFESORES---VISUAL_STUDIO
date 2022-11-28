using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Profesores.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Profesores.Controllers
{
    public class ProfesorController : ApiController
    {
        //----------------------------------------------------------------------------CADENA DE CONEXION
        private static string CadenaConexion = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
        private static List<ClassProfesor> NuevoProfesor = new List<ClassProfesor>();

        //----------------------------------------------------------------------------MOSTRAR
        [HttpGet]
        public List<ClassProfesor> Index()
        {
            NuevoProfesor = new List<ClassProfesor>();

            using (SqlConnection NuevaConexion = new SqlConnection(CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Profesor", NuevaConexion);
                cmd.CommandType = CommandType.Text;
                NuevaConexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ClassProfesor Profesor = new ClassProfesor();

                        Profesor.ID_Profe = Convert.ToInt32(dr["ID_Profe"]);
                        Profesor.RegistroEmpleado = Convert.ToInt32(dr["RegistroEmpleado"]);
                        Profesor.Nombre = dr["Nombre"].ToString();
                        Profesor.Ap_pat = dr["Ap_pat"].ToString();
                        Profesor.Ap_Mat = dr["Ap_Mat"].ToString();
                        Profesor.Genero = dr["Genero"].ToString();
                        Profesor.Categoria = dr["Categoria"].ToString();
                        Profesor.Correo = dr["Correo"].ToString();
                        Profesor.Celular = dr["Celular"].ToString();
                        Profesor.F_EdoCivil = Convert.ToInt32(dr["F_EdoCivil"]);

                        NuevoProfesor.Add(Profesor);

                    }
                }
            }
            return NuevoProfesor;
        }

        //-----------------------------------------------------------------------------REGISTRAR
        public static bool Registrar(ClassProfesor NuevoProfesor)
        {
            using (SqlConnection NuevaConexion = new SqlConnection(CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Profesor(RegistroEmpleado, Nombre, Ap_pat, Ap_Mat, Genero, Categoria, Correo, Celular, F_EdoCivil)"+
                    "VALUES (@RegistroEmpleado, @Nombre, @Ap_pat, @Ap_Mat, @Genero, @Categoria, @Correo, @Celular, @F_EdoCivil)", NuevaConexion);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@RegistroEmpleado", NuevoProfesor.RegistroEmpleado);
                cmd.Parameters.AddWithValue("@Nombre", NuevoProfesor.Nombre);
                cmd.Parameters.AddWithValue("@Ap_pat", NuevoProfesor.Ap_pat);
                cmd.Parameters.AddWithValue("@Ap_Mat", NuevoProfesor.Ap_Mat);
                cmd.Parameters.AddWithValue("@Genero", NuevoProfesor.Genero);
                cmd.Parameters.AddWithValue("@Categoria", NuevoProfesor.Categoria);
                cmd.Parameters.AddWithValue("@Correo", NuevoProfesor.Correo);
                cmd.Parameters.AddWithValue("@Celular", NuevoProfesor.Celular);
                cmd.Parameters.AddWithValue("@F_EdoCivil", NuevoProfesor.F_EdoCivil);

                try
                {
                    NuevaConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Post([FromBody]ClassProfesor NuevoProfesor)
        {
            return Registrar(NuevoProfesor);
        }
    }
}
