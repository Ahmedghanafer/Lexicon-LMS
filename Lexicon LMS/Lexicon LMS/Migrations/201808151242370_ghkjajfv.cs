namespace Lexicon_LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ghkjajfv : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "RoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "RoleId", c => c.String());
        }
    }
}
