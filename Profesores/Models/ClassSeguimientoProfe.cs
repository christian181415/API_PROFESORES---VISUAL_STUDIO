using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Profesores.Models
{
    public class ClassSeguimientoProfe
    {
        public int id_Segui { get; set; }
        public int F_positivoProfe { get; set; }
        public int F_medico { get; set; }
        public DateTime Fecha { get; set; }
        public string Form_Comunica { get; set; }
        public string Reporte { get; set; }
        public string Entrevista { get; set; }
        public string Extra { get; set; }
        public string imagen { get; set; }
    }
}