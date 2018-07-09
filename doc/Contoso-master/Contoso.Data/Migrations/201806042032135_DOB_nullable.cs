namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DOB_nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "DateofBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "DateofBirth", c => c.DateTime(nullable: false));
        }
    }
}
