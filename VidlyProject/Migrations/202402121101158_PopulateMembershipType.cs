namespace VidlyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id,Name,SginUpFee,DurationInMonth,DiscountRate) VALUES(1,'PayAsYouGo',0,0,0)");
            Sql("INSERT INTO MembershipTypes (Id,Name,SginUpFee,DurationInMonth,DiscountRate) VALUES(2,'Monthly',30,1,10)");
            Sql("INSERT INTO MembershipTypes (Id,Name,SginUpFee,DurationInMonth,DiscountRate) VALUES(3,'Quarter',90,3,15)");
            Sql("INSERT INTO MembershipTypes (Id,Name,SginUpFee,DurationInMonth,DiscountRate) VALUES(4,'Annual',300,12,20)");


        }

        public override void Down()
        {
        }
    }
}
