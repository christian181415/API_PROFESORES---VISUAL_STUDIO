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
    public class MedicoController : ApiController
    {
        //----------------------------------------------------------------------------CADENA DE CONEXION
        private static string CadenaConexion = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
        private static List<ClassMedico> NuevoMedico = new List<ClassMedico>();

        //----------------------------------------------------------------------------MOSTRAR
        [HttpGet]
        public List<ClassMedico> Index()
        {
            NuevoMedico = new List<ClassMedico>();

            using (SqlConnection NuevaConexion = new SqlConnection(CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Medico", NuevaConexion);
                cmd.CommandType = CommandType.Text;
                NuevaConexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ClassMedico Medico = new ClassMedico();

                        Medico.ID_Dr = Convert.ToInt32(dr["ID_Dr"]);
                        Medico.Nombre = dr["Nombre"].ToString(); ;
                        Medico.App = dr["App"].ToString(); ;
                        Medico.Apm = dr["Apm"].ToString(); ;
                        Medico.Telefono = dr["Telefono"].ToString(); ;
                        Medico.correo = dr["correo"].ToString(); ;
                        Medico.horario = dr["horario"].ToString(); ;
                        Medico.especialidad = dr["especialidad"].ToString(); ;
                        Medico.extra = dr["extra"].ToString(); ;

                        NuevoMedico.Add(Medico);
                    }
                }
            }
            return NuevoMedico;
        }
    }
}
