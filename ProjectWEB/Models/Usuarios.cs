using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWEB.Models
{
    public class Usuarios
    {
        public int id { set; get; }

        public string nombre_completo { set; get; }

        public string usuario { set; get; }

        public string contrasena { set; get; }

        public string correo { set; get; }

        public string telefono { set; get; }

        
    }
}