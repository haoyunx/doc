namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime2_instructor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Instructor", "HireDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Student", "EnrollmentDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "EnrollmentDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Instructor", "HireDate", c => c.DateTime(nullable: false));
        }
    }
}
