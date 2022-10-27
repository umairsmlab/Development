namespace RCOTruckApp.Models.DBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ELDEvents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ELDEvents",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        LobjectId = c.Int(nullable: false),
                        objectType = c.String(maxLength: 100),
                        iCsvRow = c.Int(nullable: false),
                        mobileRecordId = c.String(maxLength: 250),
                        RecordOrigin = c.String(),
                        EventCode = c.String(maxLength: 250),
                        EventCodeDescription = c.String(maxLength: 250),
                        BarCode = c.String(maxLength: 250),
                        DriverRecordId = c.String(maxLength: 250),
                        Time = c.String(),
                        OrganizationNumber = c.String(),
                        DateTime = c.String(maxLength: 200),
                        EngineHours = c.String(maxLength: 250),
                        OrderNumberUser = c.String(),
                        RMSCodingTimestamp = c.String(),
                        RecordId = c.String(),
                        CheckData = c.String(maxLength: 200),
                        RecordStatus = c.String(),
                        OrganizationName = c.String(),
                        ELDUsername = c.String(maxLength: 250),
                        LocalizationDescription = c.String(maxLength: 1000),
                        RecordOriginId = c.String(),
                        MapMobileRecordId = c.String(maxLength: 250),
                        Odometer = c.String(),
                        LatitudeString = c.String(maxLength: 100),
                        DriverLastName = c.String(maxLength: 250),
                        CreationTime = c.String(maxLength: 200),
                        Date = c.String(maxLength: 200),
                        ObjectName = c.String(),
                        SequenceId = c.String(maxLength: 100),
                        DriverFirstName = c.String(maxLength: 250),
                        EventSeconds = c.String(maxLength: 250),
                        CreationDate = c.String(maxLength: 200),
                        LongitudeString = c.String(maxLength: 100),
                        CheckSum = c.String(maxLength: 200),
                        EventType = c.String(maxLength: 100),
                        RMSTimestamp = c.String(),
                        VIN = c.String(),
                        VehicleMiles = c.String(),
                        OrderNumberCMV = c.String(),
                        ShiftStart = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ELDEvents");
        }
    }
}
