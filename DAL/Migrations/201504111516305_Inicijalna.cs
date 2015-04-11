namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicijalna : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dogadjaj",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatumVrijemeDogadjaja = c.DateTime(nullable: false),
                        UposlenikId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Uposlenik", t => t.UposlenikId, cascadeDelete: true)
                .Index(t => t.UposlenikId);
            
            CreateTable(
                "dbo.Uposlenik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Pozicija = c.String(),
                        Kartica = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dogadjaj", "UposlenikId", "dbo.Uposlenik");
            DropIndex("dbo.Dogadjaj", new[] { "UposlenikId" });
            DropTable("dbo.Uposlenik");
            DropTable("dbo.Dogadjaj");
        }
    }
}
