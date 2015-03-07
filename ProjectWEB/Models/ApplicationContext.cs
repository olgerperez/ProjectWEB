using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectWEB.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet <Productos> Productos { set; get; }

        public DbSet <Usuarios> Usuarios { set; get; }

        public DbSet <Transacciones> Transacciones{ set; get; }
}
}