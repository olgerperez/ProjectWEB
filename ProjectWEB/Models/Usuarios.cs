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
        [Display(Name = "Nombre Completo")]
        [MaxLength(100)]
        [Required]
        public string nombre_completo { set; get; }
        [Display(Name = "Usuario")]
        [MaxLength(25)]
        public string usuario { set; get; }
        [Display(Name = "Contraseña")]
        [MaxLength(255)]
        public string contrasena { set; get; }
        [Display(Name = "Correo")]
        [MaxLength(100)]
        public string correo { set; get; }
        [Display(Name = "Telefono")]
        [MaxLength(12)]
        public string telefono { set; get; }

        
    }
}