namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdateToCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Bithdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Bithdate");
        }
    }
}
