namespace lamia12771.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOfficeToTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Office", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Office");
        }
    }
}
