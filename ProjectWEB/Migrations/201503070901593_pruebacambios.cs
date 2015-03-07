namespace ProjectWEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pruebacambios : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "nombre_completo", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "nombre_completo", c => c.String(maxLength: 100));
        }
    }
}
