namespace lamia12771.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationUpdates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Subject", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "Email", c => c.String());
            AlterColumn("dbo.Teachers", "Subject", c => c.String());
            AlterColumn("dbo.Teachers", "Name", c => c.String());
        }
    }
}
