namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CreatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Courses", "UpdatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Departments", "CreatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Departments", "UpdatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.People", "DateofBirth", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.People", "CreatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.People", "UpdatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.OfficeAssignments", "CreatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.OfficeAssignments", "UpdatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Roles", "CreatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Roles", "UpdatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Enrollments", "CreatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Enrollments", "UpdatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Enrollments", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.Enrollments", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Roles", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.Roles", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.OfficeAssignments", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.OfficeAssignments", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.People", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.People", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.People", "DateofBirth", c => c.DateTime());
            AlterColumn("dbo.Departments", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.Departments", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Courses", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.Courses", "CreatedDate", c => c.DateTime());
        }
    }
}
