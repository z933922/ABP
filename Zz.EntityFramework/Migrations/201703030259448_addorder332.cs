namespace Zz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addorder332 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Nums", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "Remark", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "Remark");
            DropColumn("dbo.OrderDetails", "Nums");
        }
    }
}
