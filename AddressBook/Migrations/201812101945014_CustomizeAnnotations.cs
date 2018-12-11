namespace AddressBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomizeAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "FullName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "FullName", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
