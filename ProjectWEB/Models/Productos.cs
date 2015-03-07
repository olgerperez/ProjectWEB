using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectWEB.Models
{
    public class Productos
    {
        [Key]
        public int id { set; get; }

        [MaxLength(255)]
        public string descripcion {set; get;}

        [MaxLength(100)]
        public string imagen { set; get; }

        [MaxLength(40)]
        public string estado { set; get; }

        public DateTime fecha { set; get; }

        public int  usuario_id { set; get; }

    }
}