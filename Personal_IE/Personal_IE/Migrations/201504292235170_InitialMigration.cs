namespace Personal_IE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "HR.Department",
                c => new
                    {
                        DepartmentId = c.Long(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 100),
                        LocationId = c.Long(),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("HR.Location", t => t.LocationId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "HR.Location",
                c => new
                    {
                        LocationId = c.Long(nullable: false, identity: true),
                        StreetAddress = c.String(maxLength: 250),
                        PostalCode = c.String(maxLength: 6),
                        City = c.String(maxLength: 100),
                        StateProvince = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "HR.Employee",
                c => new
                    {
                        EmployeeId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(nullable: false, maxLength: 100),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CommisionPercent = c.Decimal(precision: 18, scale: 2),
                        HireDate = c.DateTime(nullable: false),
                        JobId = c.Long(nullable: false),
                        ManagerId = c.Long(),
                        DepartamentId = c.Long(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("HR.Department", t => t.DepartamentId)
                .ForeignKey("HR.Job", t => t.JobId)
                .ForeignKey("HR.Employee", t => t.ManagerId)
                .Index(t => t.JobId)
                .Index(t => t.ManagerId)
                .Index(t => t.DepartamentId);
            
            CreateTable(
                "HR.Job",
                c => new
                    {
                        JobId = c.Long(nullable: false, identity: true),
                        JobCode = c.String(nullable: false, maxLength: 100),
                        JobTitle = c.String(nullable: false, maxLength: 100),
                        MinSalary = c.Decimal(precision: 18, scale: 2),
                        MaxSalary = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.JobId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("HR.Employee", "ManagerId", "HR.Employee");
            DropForeignKey("HR.Employee", "JobId", "HR.Job");
            DropForeignKey("HR.Employee", "DepartamentId", "HR.Department");
            DropForeignKey("HR.Department", "LocationId", "HR.Location");
            DropIndex("HR.Employee", new[] { "DepartamentId" });
            DropIndex("HR.Employee", new[] { "ManagerId" });
            DropIndex("HR.Employee", new[] { "JobId" });
            DropIndex("HR.Department", new[] { "LocationId" });
            DropTable("HR.Job");
            DropTable("HR.Employee");
            DropTable("HR.Location");
            DropTable("HR.Department");
        }
    }
}
