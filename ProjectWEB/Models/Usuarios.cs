using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectWEB.Models
{
    public class Usuarios
    {
        [Key]
        public int id { set; get; }

        [MaxLength(100)]
        public string nombre_completo { set; get; }

        [MaxLength(25)]
        public string usuario { set; get; }

        [MaxLength(255)]
        public string contrasena { set; get; }

        [MaxLength(100)]
        public string correo { set; get; }

        [MaxLength(12)]
        public string telefono { set; get; }

        
    }
}