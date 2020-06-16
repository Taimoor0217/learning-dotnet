namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeNames : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET NAME = 'Type 1' WHERE Id = 1");
            Sql("Update MembershipTypes SET NAME = 'Type 2' WHERE Id = 2");
            Sql("Update MembershipTypes SET NAME = 'Type 3' WHERE Id = 3");
            Sql("Update MembershipTypes SET NAME = 'Type 4' WHERE Id = 4");

        }
        
        public override void Down()
        {
        }
    }
}
