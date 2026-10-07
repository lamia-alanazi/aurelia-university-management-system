namespace lamia12771.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoomDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "RoomName", c => c.String(nullable: false));
            AddColumn("dbo.Rooms", "RoomType", c => c.String(nullable: false));
            AddColumn("dbo.Rooms", "Area", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "Status", c => c.String(nullable: false));
            AddColumn("dbo.Rooms", "Description", c => c.String());
            AddColumn("dbo.Rooms", "Facilities", c => c.String());
            AddColumn("dbo.Rooms", "ImagePath", c => c.String());
            AlterColumn("dbo.Rooms", "RoomNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rooms", "RoomNumber", c => c.String());
            DropColumn("dbo.Rooms", "ImagePath");
            DropColumn("dbo.Rooms", "Facilities");
            DropColumn("dbo.Rooms", "Description");
            DropColumn("dbo.Rooms", "Status");
            DropColumn("dbo.Rooms", "Area");
            DropColumn("dbo.Rooms", "RoomType");
            DropColumn("dbo.Rooms", "RoomName");
        }
    }
}
