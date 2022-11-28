using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Profesores.Models
{
    public class ClassProfesor
    {
        public int ID_Profe { get; set; }
        public int RegistroEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Ap_pat { get; set; }
        public string Ap_Mat { get; set; }
        public string Genero { get; set; }
        public string Categoria { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public int F_EdoCivil { get; set; }
    }
}