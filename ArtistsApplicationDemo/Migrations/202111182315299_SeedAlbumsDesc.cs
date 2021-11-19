namespace ArtistsApplicationDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAlbumsDesc : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Albums SET Description = 'This CD is a tough, gritty and brilliant representation of Daniel Castro' WHERE ID=1");
            Sql("UPDATE Albums SET Description = 'No Surrender features interpretations of well-known blues standards' WHERE ID=2");
            Sql("UPDATE Albums SET Description = 'Blueprint is the third studio album by Irish guitarist Rory Gallagher' WHERE ID=3");
        }
        
        public override void Down()
        {
            Sql("UPDATE Albums SET Description = ''");
        }
    }
}
