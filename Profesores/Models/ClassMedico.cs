using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Profesores.Models
{
    public class ClassMedico
    {
        public int ID_Dr { get; set; }
        public string Nombre { get; set; }
        public string App { get; set; }
        public string Apm { get; set; }
        public string Telefono { get; set; }
        public string correo { get; set; }
        public string horario { get; set; }
        public string especialidad { get; set; }
        public string extra { get; set; }
    }
}