namespace ProjectWEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForaneaUsuariosToProductos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "usuario_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Productos", "usuario_id");
            AddForeignKey("dbo.Productos", "usuario_id", "dbo.Usuarios", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "usuario_id", "dbo.Usuarios");
            DropIndex("dbo.Productos", new[] { "usuario_id" });
            DropColumn("dbo.Productos", "usuario_id");
        }
    }
}
