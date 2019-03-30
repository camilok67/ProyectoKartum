namespace Icosoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCampoPerfil : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(maxLength: 40));
            AddColumn("dbo.AspNetUsers", "Document", c => c.String(maxLength: 13));
            AddColumn("dbo.AspNetUsers", "Direction", c => c.String(maxLength: 45));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Direction");
            DropColumn("dbo.AspNetUsers", "Document");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
