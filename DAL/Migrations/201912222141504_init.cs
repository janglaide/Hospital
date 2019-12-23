namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        SpecializationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.PatientId);
            
            CreateTable(
                "dbo.Specializations",
                c => new
                    {
                        SpecializationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SpecializationId);
            
            CreateTable(
                "dbo.VisitResults",
                c => new
                    {
                        DiagnosisId = c.Int(nullable: false, identity: true),
                        VisitId = c.Int(nullable: false),
                        Diagnosis = c.String(),
                    })
                .PrimaryKey(t => t.DiagnosisId);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        VisitId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        VisitTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VisitId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Visits");
            DropTable("dbo.VisitResults");
            DropTable("dbo.Specializations");
            DropTable("dbo.Patients");
            DropTable("dbo.Doctors");
        }
    }
}
