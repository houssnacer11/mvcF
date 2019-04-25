namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titre = c.String(maxLength: 60),
                        Description = c.String(),
                        DateProd = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ImageUrl = c.String(),
                        Genre = c.String(nullable: false, maxLength: 30),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Evaluation = c.String(maxLength: 5),
                        ProducteurId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Producteurs", t => t.ProducteurId, cascadeDelete: true)
                .Index(t => t.ProducteurId);
            
            CreateTable(
                "dbo.Producteurs",
                c => new
                    {
                        ProducteurId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        prenom = c.String(),
                        DateNaissance = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ProducteurId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "ProducteurId", "dbo.Producteurs");
            DropIndex("dbo.Films", new[] { "ProducteurId" });
            DropTable("dbo.Producteurs");
            DropTable("dbo.Films");
        }
    }
}
