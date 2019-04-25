namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FormationCandidats", "Candidat_CIN", "dbo.Candidats");
            DropIndex("dbo.FormationCandidats", new[] { "Candidat_CIN" });
            DropPrimaryKey("dbo.Candidats");
            DropPrimaryKey("dbo.FormationCandidats");
            AlterColumn("dbo.Candidats", "CIN", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.FormationCandidats", "Candidat_CIN", c => c.String(nullable: false, maxLength: 8));
            AddPrimaryKey("dbo.Candidats", "CIN");
            AddPrimaryKey("dbo.FormationCandidats", new[] { "Formation_IdFormation", "Candidat_CIN" });
            CreateIndex("dbo.FormationCandidats", "Candidat_CIN");
            AddForeignKey("dbo.FormationCandidats", "Candidat_CIN", "dbo.Candidats", "CIN", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FormationCandidats", "Candidat_CIN", "dbo.Candidats");
            DropIndex("dbo.FormationCandidats", new[] { "Candidat_CIN" });
            DropPrimaryKey("dbo.FormationCandidats");
            DropPrimaryKey("dbo.Candidats");
            AlterColumn("dbo.FormationCandidats", "Candidat_CIN", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Candidats", "CIN", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.FormationCandidats", new[] { "Formation_IdFormation", "Candidat_CIN" });
            AddPrimaryKey("dbo.Candidats", "CIN");
            CreateIndex("dbo.FormationCandidats", "Candidat_CIN");
            AddForeignKey("dbo.FormationCandidats", "Candidat_CIN", "dbo.Candidats", "CIN", cascadeDelete: true);
        }
    }
}
