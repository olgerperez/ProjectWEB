using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectWEB.Models
{
    public class Productos
    {
        [Key]
        public int id { set; get; }
        [Display(Name = "Descripción")]
        [MaxLength(255)]
        public string descripcion {set; get;}
        [Display(Name = "Imagen")]
        [MaxLength(100)]
        public string imagen { set; get; }
        [Display(Name = "Estado")]
        [MaxLength(40)]
        public string estado { set; get; }
        [Display(Name = "Fecha")]
        public DateTime fecha { set; get; }

        [Display(Name = "Nombre Usuario")]
        [ForeignKey("Usuario")]
        [Column(Order = 1)]
        public int usuario_id { set; get; }
        public Usuarios Usuario { set; get; }


    }
}