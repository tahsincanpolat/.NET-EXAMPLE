namespace OgrenciBilgiSistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bolum",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        FakulteId = c.Int(nullable: false),
                        Adres = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bolum");
        }
    }
}
