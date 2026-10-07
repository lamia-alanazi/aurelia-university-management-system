namespace lamia12771.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeacherProfileFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Title", c => c.String());
            AddColumn("dbo.Teachers", "About", c => c.String());
            AddColumn("dbo.Teachers", "Education", c => c.String());
            AddColumn("dbo.Teachers", "AcademicExperience", c => c.String());
            AddColumn("dbo.Teachers", "ResearchInterests", c => c.String());
            AddColumn("dbo.Teachers", "CoursesTaught", c => c.String());
            AddColumn("dbo.Teachers", "Email", c => c.String());
            AddColumn("dbo.Teachers", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "ImagePath");
            DropColumn("dbo.Teachers", "Email");
            DropColumn("dbo.Teachers", "CoursesTaught");
            DropColumn("dbo.Teachers", "ResearchInterests");
            DropColumn("dbo.Teachers", "AcademicExperience");
            DropColumn("dbo.Teachers", "Education");
            DropColumn("dbo.Teachers", "About");
            DropColumn("dbo.Teachers", "Title");
        }
    }
}
