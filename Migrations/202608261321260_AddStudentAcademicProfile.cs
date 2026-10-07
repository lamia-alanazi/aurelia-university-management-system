namespace lamia12771.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentAcademicProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn(
                "dbo.Students",
                "Major",
                c => c.String(
                    nullable: false,
                    defaultValue: "Not Assigned"
                )
            );

            AddColumn(
                "dbo.Students",
                "Level",
                c => c.String(
                    nullable: false,
                    defaultValue: "Not Assigned"
                )
            );

            AddColumn(
                "dbo.Students",
                "GPA",
                c => c.Decimal(
                    nullable: false,
                    precision: 18,
                    scale: 2,
                    defaultValue: 0
                )
            );

            AddColumn(
                "dbo.Students",
                "CreditsCompleted",
                c => c.Int(
                    nullable: false,
                    defaultValue: 0
                )
            );

            AddColumn(
                "dbo.Students",
                "DegreeProgress",
                c => c.Int(
                    nullable: false,
                    defaultValue: 0
                )
            );

            AddColumn(
                "dbo.Students",
                "AcademicStanding",
                c => c.String()
            );

            AddColumn(
                "dbo.Students",
                "Email",
                c => c.String(
                    nullable: false,
                    defaultValue: "pending@student.aurelia.edu"
                )
            );

            AddColumn(
                "dbo.Students",
                "ImagePath",
                c => c.String()
            );

            AddColumn(
                "dbo.Students",
                "TeacherId",
                c => c.Int()
            );

            AlterColumn(
                "dbo.Students",
                "Name",
                c => c.String(nullable: false)
            );

            CreateIndex(
                "dbo.Students",
                "TeacherId"
            );

            AddForeignKey(
                "dbo.Students",
                "TeacherId",
                "dbo.Teachers",
                "TeacherId"
            );
        }

        public override void Down()
        {
            DropForeignKey("dbo.Students", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Students", new[] { "TeacherId" });
            AlterColumn("dbo.Students", "Name", c => c.String());
            DropColumn("dbo.Students", "TeacherId");
            DropColumn("dbo.Students", "ImagePath");
            DropColumn("dbo.Students", "Email");
            DropColumn("dbo.Students", "AcademicStanding");
            DropColumn("dbo.Students", "DegreeProgress");
            DropColumn("dbo.Students", "CreditsCompleted");
            DropColumn("dbo.Students", "GPA");
            DropColumn("dbo.Students", "Level");
            DropColumn("dbo.Students", "Major");
        }
    }
}
