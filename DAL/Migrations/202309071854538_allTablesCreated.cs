namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allTablesCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblEmployeeAttendances",
                c => new
                    {
                        attendanceId = c.Int(nullable: false, identity: true),
                        employeeId = c.Int(nullable: false),
                        attendanceDate = c.DateTime(nullable: false),
                        isPresent = c.Int(nullable: false),
                        isAbsent = c.Int(nullable: false),
                        isOffday = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.attendanceId);
            
            CreateTable(
                "dbo.tblEmployees",
                c => new
                    {
                        employeeId = c.Int(nullable: false, identity: true),
                        employeeName = c.String(nullable: false, maxLength: 30),
                        employeeCode = c.String(nullable: false),
                        employeeSalary = c.Int(nullable: false),
                        supervisorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.employeeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblEmployees");
            DropTable("dbo.tblEmployeeAttendances");
        }
    }
}
