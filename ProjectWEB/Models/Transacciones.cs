using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectWEB.Models
{
    public class Transacciones
    {

        [Key]
        public int id { set; get; }

        [MaxLength(100)]
        public string producto_ofrecido { set; get; }

        [MaxLength(100)]
        public string producto_interes { set; get; }

        public DateTime fecha { set; get; }

        [MaxLength(50)]
        public string estado { set; get; }
    }
}