using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWEB.Models
{
    public class Transacciones
    {
        public int id { set; get; }

        public string producto_ofrecido { set; get; }

        public string producto_interes { set; get; }

        public DateTime fecha { set; get; }

        public string estado { set; get; }
    }
}