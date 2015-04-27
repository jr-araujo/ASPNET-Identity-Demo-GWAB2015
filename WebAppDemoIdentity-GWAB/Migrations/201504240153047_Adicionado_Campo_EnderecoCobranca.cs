namespace WebAppDemoIdentity_GWAB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicionado_Campo_EnderecoCobranca : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "EnderecoCobranca", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "EnderecoCobranca");
        }
    }
}
