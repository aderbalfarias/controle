namespace Imarley.Controle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        StatusId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Telefone = c.String(nullable: false, maxLength: 15, unicode: false),
                        Celular = c.String(nullable: false, maxLength: 15, unicode: false),
                        Endereco = c.String(nullable: false, maxLength: 100, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 255, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.StatusId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Clientes", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Clientes", new[] { "CategoriaId" });
            DropIndex("dbo.Clientes", new[] { "StatusId" });
            DropTable("dbo.Status");
            DropTable("dbo.Clientes");
            DropTable("dbo.Categorias");
        }
    }
}
