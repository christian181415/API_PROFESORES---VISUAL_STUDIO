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
    public class EdoCivilController : ApiController
    {
        //----------------------------------------------------------------------------CADENA DE CONEXION
        private static string CadenaConexion = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
        private static List<ClassEdoCivil> NuevoEdoCivil = new List<ClassEdoCivil>();

        //----------------------------------------------------------------------------MOSTRAR
        [HttpGet]
        public List<ClassEdoCivil> Index()
        {
            NuevoEdoCivil = new List<ClassEdoCivil>();

            using (SqlConnection NuevaConexion = new SqlConnection(CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM EstadoCivil", NuevaConexion);
                cmd.CommandType = CommandType.Text;
                NuevaConexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ClassEdoCivil EdoCivil = new ClassEdoCivil();

                        EdoCivil.Id_Edo = Convert.ToInt32(dr["Id_Edo"]);
                        EdoCivil.Estado = dr["Estado"].ToString();
                        EdoCivil.Extra = dr["Extra"].ToString();

                        NuevoEdoCivil.Add(EdoCivil);
                    }
                }
            }
            return NuevoEdoCivil;
        }
    }
}
