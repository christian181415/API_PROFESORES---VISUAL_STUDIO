using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Profesores.Models
{
    public class ClassPositivoProfe
    {
        public int id_posProfe { get; set; }
        public DateTime FechaConfirmado { get; set; }
        public string Comprobacion { get; set; }
        public string Antecedentes { get; set; }
        public string Riesgo { get; set; }
        public int NumContaio { get; set; }
        public string Extra { get; set; }
        public int F_Profe { get; set; }
        public string imagen { get; set; }
        public int discpacidad { get; set; }
    }
}