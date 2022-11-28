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
    public class PositivoProfeController : ApiController
    {
        private static string CadenaConexion = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
        private static List<ClassPositivoProfe> NuevoPositivoProfe = new List<ClassPositivoProfe>();
        // GET: Profesor
        [HttpGet]
        public List<ClassPositivoProfe> Index()
        {
            NuevoPositivoProfe = new List<ClassPositivoProfe>();

            using (SqlConnection NuevaConexion = new SqlConnection(CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM PositivoProfe", NuevaConexion);
                cmd.CommandType = CommandType.Text;
                NuevaConexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ClassPositivoProfe Profesor = new ClassPositivoProfe();

                        Profesor.id_posProfe = Convert.ToInt32(dr["id_posProfe"]);
                        Profesor.FechaConfirmado = Convert.ToDateTime(dr["FechaConfirmado"]);
                        Profesor.Comprobacion = dr["Comprobacion"].ToString();
                        Profesor.Antecedentes = dr["Antecedentes"].ToString();
                        Profesor.Riesgo = dr["Riesgo"].ToString();
                        Profesor.NumContaio = Convert.ToInt32(dr["NumContaio"]);
                        Profesor.Extra = dr["Extra"].ToString();
                        Profesor.F_Profe = Convert.ToInt32(dr["F_Profe"]);
                        Profesor.imagen = dr["imagen"].ToString();
                        Profesor.discpacidad = Convert.ToInt32(dr["F_EdoCivil"]);

                        NuevoPositivoProfe.Add(Profesor);

                    }
                }
            }
            return NuevoPositivoProfe;
        }
    }
}
