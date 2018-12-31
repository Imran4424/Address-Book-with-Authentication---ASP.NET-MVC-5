namespace AddressBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "UserIdentity", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "UserIdentity");
        }
    }
}
