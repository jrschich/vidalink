namespace ControleTarefas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removidocamposusuarios : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tarefa", "UsuarioIdCadastro");
            DropColumn("dbo.Tarefa", "UsuarioIdAlteracao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tarefa", "UsuarioIdAlteracao", c => c.Int(nullable: false));
            AddColumn("dbo.Tarefa", "UsuarioIdCadastro", c => c.Int(nullable: false));
        }
    }
}
