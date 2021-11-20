namespace ArtistsApplicationDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPropertyToArtist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "Thumbnail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "Thumbnail");
        }
    }
}
