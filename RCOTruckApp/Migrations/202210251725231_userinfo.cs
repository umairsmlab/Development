namespace RCOTruckApp.Models.DBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userinfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Credentials",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        rmsUserId = c.String(maxLength: 100),
                        username = c.String(maxLength: 250),
                        password = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblDriver",
                c => new
                    {
                        DriverID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        TruckID = c.Int(nullable: false),
                        DriverName = c.String(maxLength: 250),
                        Status = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DriverID);
            
            CreateTable(
                "dbo.tblErrorLog",
                c => new
                    {
                        ErrorLogID = c.Int(nullable: false, identity: true),
                        LogType = c.Int(nullable: false),
                        ActionName = c.String(maxLength: 250),
                        LogText = c.String(maxLength: 4000),
                        UserID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ErrorLogID);
            
            CreateTable(
                "dbo.tblPreTripCheckList",
                c => new
                    {
                        LogID = c.Int(nullable: false, identity: true),
                        LogType = c.Int(nullable: false),
                        ActionName = c.String(maxLength: 250),
                        LogText = c.String(maxLength: 4000),
                        UserID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LogID);
            
            CreateTable(
                "dbo.PreTripCheckLists",
                c => new
                    {
                        PreTripCheckListID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        CheckBreaks = c.Boolean(nullable: false),
                        CheckEmergencyFlashers = c.Boolean(nullable: false),
                        CheckExternalLights = c.Boolean(nullable: false),
                        CheckHeadLights = c.Boolean(nullable: false),
                        CheckHeater = c.Boolean(nullable: false),
                        CheckHorns = c.Boolean(nullable: false),
                        CheckMirros = c.Boolean(nullable: false),
                        CheckParkingBreak = c.Boolean(nullable: false),
                        CheckSeatBelt = c.Boolean(nullable: false),
                        CheckSteering = c.Boolean(nullable: false),
                        CheckTireRims = c.Boolean(nullable: false),
                        CheckTurnSignals = c.Boolean(nullable: false),
                        CheckWheelChocks = c.Boolean(nullable: false),
                        CheckWindShield = c.Boolean(nullable: false),
                        CheckWipers = c.Boolean(nullable: false),
                        Signature = c.Binary(),
                        VersionUserID = c.Int(nullable: false),
                        Archived = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PreTripCheckListID);
            
            CreateTable(
                "dbo.tblTruck",
                c => new
                    {
                        TruckID = c.Int(nullable: false, identity: true),
                        TruckNumber = c.String(maxLength: 250),
                        trailer = c.String(),
                        trailer2 = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TruckID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        rmsUserId = c.String(maxLength: 100),
                        recordId = c.String(maxLength: 100),
                        firstName = c.String(maxLength: 250),
                        lastName = c.String(maxLength: 250),
                        employeeId = c.String(maxLength: 100),
                        itemType = c.String(maxLength: 100),
                        trucknumber = c.String(maxLength: 100),
                        trailernumber = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.tblTruck");
            DropTable("dbo.PreTripCheckLists");
            DropTable("dbo.tblPreTripCheckList");
            DropTable("dbo.tblErrorLog");
            DropTable("dbo.tblDriver");
            DropTable("dbo.Credentials");
        }
    }
}
