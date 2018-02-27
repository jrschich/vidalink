namespace ControleTarefas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tarefa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                        DataExcucao = c.DateTime(nullable: false),
                        UsuarioIdCadastro = c.Int(nullable: false),
                        UsuarioIdAlteracao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        Ativo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
            DropTable("dbo.Tarefa");
        }
    }
}
