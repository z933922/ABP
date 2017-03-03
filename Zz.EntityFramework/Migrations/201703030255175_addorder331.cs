namespace Zz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addorder331 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ZPeopleInputs");
            DropTable("dbo.ZPeopleOutputs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ZPeopleOutputs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                        Name = c.String(),
                        DoubleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ZPeopleInputs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 10),
                        DoubleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
