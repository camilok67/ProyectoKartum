namespace Icosoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prueba : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        IdCity = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        IdDepartment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCity)
                .ForeignKey("dbo.Departments", t => t.IdDepartment, cascadeDelete: true)
                .Index(t => t.IdDepartment);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        IdDepartment = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.IdDepartment);
            
            AddColumn("dbo.Suppliers", "IdCity", c => c.Int(nullable: false));
            CreateIndex("dbo.Suppliers", "IdCity");
            AddForeignKey("dbo.Suppliers", "IdCity", "dbo.Cities", "IdCity", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suppliers", "IdCity", "dbo.Cities");
            DropForeignKey("dbo.Cities", "IdDepartment", "dbo.Departments");
            DropIndex("dbo.Suppliers", new[] { "IdCity" });
            DropIndex("dbo.Cities", new[] { "IdDepartment" });
            DropColumn("dbo.Suppliers", "IdCity");
            DropTable("dbo.Departments");
            DropTable("dbo.Cities");
        }
    }
}
