namespace AddressBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConvertToSingleMobile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Mobile", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Mobile");
        }
    }
}
