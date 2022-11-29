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
    public class SeguimientoProfeController : ApiController
    {
        private static string CadenaConexion = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
        private static List<ClassSeguimientoProfe> NuevoSeguimiento = new List<ClassSeguimientoProfe>();
        // GET: Profesor
        [HttpGet]
        public List<ClassSeguimientoProfe> Index()
        {
            NuevoSeguimiento = new List<ClassSeguimientoProfe>();

            using (SqlConnection NuevaConexion = new SqlConnection(CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM SeguimientoPRO", NuevaConexion);
                cmd.CommandType = CommandType.Text;
                NuevaConexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ClassSeguimientoProfe Profesor = new ClassSeguimientoProfe();

                        Profesor.id_Segui = Convert.ToInt32(dr["id_Segui"]);
                        Profesor.F_positivoProfe = Convert.ToInt32(dr["F_positivoProfe"]);
                        Profesor.F_medico = Convert.ToInt32(dr["F_medico"]);
                        Profesor.Fecha = Convert.ToDateTime(dr["Fecha"]);
                        Profesor.Form_Comunica = dr["Form_Comunica"].ToString();
                        Profesor.Reporte = dr["Reporte"].ToString();
                        Profesor.Entrevista = dr["Entrevista"].ToString();
                        Profesor.Extra = dr["Extra"].ToString();
                        Profesor.imagen = dr["imagen"].ToString();

                        NuevoSeguimiento.Add(Profesor);

                    }
                }
            }
            return NuevoSeguimiento;
        }



        //-----------------------------------------------------------------------------REGISTRAR
        public static bool Registrar(ClassSeguimientoProfe NuevoSeguimiento)
        {
            using (SqlConnection NuevaConexion = new SqlConnection(CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO SeguimientoPRO(F_positivoProfe, F_medico, Fecha, Form_Comunica, Reporte, Entrevista, Extra, imagen)" +
                    "VALUES (@F_positivoProfe, @F_medico, @Fecha, @Form_Comunica, @Reporte, @Entrevista, @Extra, @imagen)", NuevaConexion);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@F_positivoProfe", NuevoSeguimiento.F_positivoProfe);
                cmd.Parameters.AddWithValue("@F_medico", NuevoSeguimiento.F_medico);
                cmd.Parameters.AddWithValue("@Fecha", NuevoSeguimiento.Fecha);
                cmd.Parameters.AddWithValue("@Form_Comunica", NuevoSeguimiento.Form_Comunica);
                cmd.Parameters.AddWithValue("@Reporte", NuevoSeguimiento.Reporte);
                cmd.Parameters.AddWithValue("@Entrevista", NuevoSeguimiento.Entrevista);
                cmd.Parameters.AddWithValue("@Extra", NuevoSeguimiento.Extra);
                cmd.Parameters.AddWithValue("@imagen", NuevoSeguimiento.imagen);

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

        public bool Post([FromBody] ClassSeguimientoProfe NuevoSeguimiento)
        {
            return Registrar(NuevoSeguimiento);
        }
    }
}
