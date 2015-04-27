namespace WebAppDemoIdentity_GWAB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removido_Campo_EnderecoCobranca : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "EnderecoCobranca");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "EnderecoCobranca", c => c.String());
        }
    }
}
