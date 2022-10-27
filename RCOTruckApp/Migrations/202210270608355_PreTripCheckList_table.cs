namespace RCOTruckApp.Models.DBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PreTripCheckList_table : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tblPreTripCheckList", newName: "tblLog");
            AlterColumn("dbo.PreTripCheckLists", "OdoMeter", c => c.String(maxLength: 250));
            AlterColumn("dbo.PreTripCheckLists", "TruckNumber", c => c.String(maxLength: 250));
            AlterColumn("dbo.PreTripCheckLists", "Trailer1Number", c => c.String(maxLength: 250));
            AlterColumn("dbo.PreTripCheckLists", "Trailer1ReeferHOS", c => c.String(maxLength: 250));
            AlterColumn("dbo.PreTripCheckLists", "Trailer2Number", c => c.String(maxLength: 250));
            AlterColumn("dbo.PreTripCheckLists", "Trailer2ReeferHOS", c => c.String(maxLength: 250));
            AlterColumn("dbo.PreTripCheckLists", "Remarks", c => c.String(maxLength: 250));
            AlterColumn("dbo.PreTripCheckLists", "DriverName", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PreTripCheckLists", "DriverName", c => c.String());
            AlterColumn("dbo.PreTripCheckLists", "Remarks", c => c.String());
            AlterColumn("dbo.PreTripCheckLists", "Trailer2ReeferHOS", c => c.String());
            AlterColumn("dbo.PreTripCheckLists", "Trailer2Number", c => c.String());
            AlterColumn("dbo.PreTripCheckLists", "Trailer1ReeferHOS", c => c.String());
            AlterColumn("dbo.PreTripCheckLists", "Trailer1Number", c => c.String());
            AlterColumn("dbo.PreTripCheckLists", "TruckNumber", c => c.String());
            AlterColumn("dbo.PreTripCheckLists", "OdoMeter", c => c.String());
            RenameTable(name: "dbo.tblLog", newName: "tblPreTripCheckList");
        }
    }
}
