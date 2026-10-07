namespace lamia12771.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "CourseCode", c => c.String(nullable: false));
            AddColumn("dbo.Courses", "Category", c => c.String(nullable: false));
            AddColumn("dbo.Courses", "Schedule", c => c.String());
            AddColumn("dbo.Courses", "Location", c => c.String());
            AddColumn("dbo.Courses", "Description", c => c.String());
            AddColumn("dbo.Courses", "Topics", c => c.String());
            AddColumn("dbo.Courses", "ImagePath", c => c.String());
            AddColumn("dbo.Courses", "Instructor", c => c.String());
            AlterColumn("dbo.Courses", "CourseName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "CourseName", c => c.String());
            DropColumn("dbo.Courses", "Instructor");
            DropColumn("dbo.Courses", "ImagePath");
            DropColumn("dbo.Courses", "Topics");
            DropColumn("dbo.Courses", "Description");
            DropColumn("dbo.Courses", "Location");
            DropColumn("dbo.Courses", "Schedule");
            DropColumn("dbo.Courses", "Category");
            DropColumn("dbo.Courses", "CourseCode");
        }
    }
}
