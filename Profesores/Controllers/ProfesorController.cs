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
        private static string CadenaConexion = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
        private static List<ClassProfesor> NuevoProfesor = new List<ClassProfesor>();
        // GET: Profesor
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
    }
}
