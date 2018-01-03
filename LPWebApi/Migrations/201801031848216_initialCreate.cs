namespace LPWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbPublicacoes",
                c => new
                    {
                        IdPublicacao = c.Int(nullable: false, identity: true),
                        TituloPublicacao = c.String(),
                        UrlPublicacao = c.String(),
                    })
                .PrimaryKey(t => t.IdPublicacao);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbPublicacoes");
        }
    }
}
