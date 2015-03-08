namespace ProjectWEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        descripcion = c.String(maxLength: 255),
                        imagen = c.String(maxLength: 100),
                        estado = c.String(maxLength: 40),
                        fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Transacciones",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        producto_ofrecido = c.String(maxLength: 100),
                        producto_interes = c.String(maxLength: 100),
                        fecha = c.DateTime(nullable: false),
                        estado = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre_completo = c.String(nullable: false, maxLength: 100),
                        usuario = c.String(maxLength: 25),
                        contrasena = c.String(maxLength: 255),
                        correo = c.String(maxLength: 100),
                        telefono = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
            DropTable("dbo.Transacciones");
            DropTable("dbo.Productos");
        }
    }
}
