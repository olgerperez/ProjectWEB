using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWEB.Models
{
    public class Productos
    {
        public int id { set; get; }

        public string descripcion {set; get;}

        public string imagen { set; get; }

        public string estado { set; get; }

        public DateTime fecha { set; get; }

        public int  usuario_id { set; get; }

    }
}