
using System.Data.Entity;
using System.Reflection.Emit;

namespace RCOTruckApp.Models.DBContext
{
    /// <summary>
    /// RCOTruckDBContext
    /// </summary>
    public class RCOTruckDBContext : DbContext
    {
        /// <summary>
        /// Users
        /// </summary>
        public DbSet<User.User> Users { get; set; }

        /// <summary>
        /// Trucks
        /// </summary>
        public DbSet<Trucks.Truck> Trucks { get; set; }

        /// <summary>
        /// Logs
        /// </summary>
        public DbSet<Log.Log> Logs { get; set; }

        /// <summary>
        /// ErrorLogs
        /// </summary>
        public DbSet<Log.ErrorLog> ErrorLogs { get; set; }

        /// <summary>
        /// Drivers
        /// </summary>
        public DbSet<Driver.Driver> Drivers { get; set; }


        public DbSet<PreTrip.PreTripCheckList> PreTripCheckLists { get; set; }

        public DbSet<User.Credentials> Credentials { get; set; }
        public DbSet<ELD.ELDEvent> ELDEvents { get; set; }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here
            #region User


            //User Tble Property Configurations

            modelBuilder.Entity<User.User>()
                    .HasKey(u => u.id);
                    

            modelBuilder.Entity<User.User>()
                    .Property(u => u.firstName)
                    .HasMaxLength(250);
            
            modelBuilder.Entity<User.User>()
                    .Property(u => u.lastName)
                    .HasMaxLength(250);
            
            modelBuilder.Entity<User.User>()
                    .Property(u => u.rmsUserId)
                    .HasMaxLength(100);
            
            modelBuilder.Entity<User.User>()
                    .Property(u => u.recordId)
                    .HasMaxLength(100);
            
            modelBuilder.Entity<User.User>()
                    .Property(u => u.employeeId)
                    .HasMaxLength(100);
            
            modelBuilder.Entity<User.User>()
                    .Property(u => u.itemType)
                    .HasMaxLength(100);

            modelBuilder.Entity<User.User>()
                    .Property(u => u.trucknumber)
                    .HasMaxLength(100);
            
            modelBuilder.Entity<User.User>()
                    .Property(u => u.trailernumber)
                    .HasMaxLength(100);

            #endregion

            #region Credentials
            modelBuilder.Entity<User.Credentials>()
                .HasKey(u => u.id);


            modelBuilder.Entity<User.Credentials>()
                    .Property(u => u.rmsUserId)
                    .HasMaxLength(100);
            
            modelBuilder.Entity<User.Credentials>()
                    .Property(u => u.username)
                    .HasMaxLength(250);

            modelBuilder.Entity<User.Credentials>()
                    .Property(u => u.password)
                    .HasMaxLength(250);
            #endregion

            #region Truck

            modelBuilder.Entity<Trucks.Truck>()
                .ToTable("tblTruck");

            //Truck Tble Property Configurations
            modelBuilder.Entity<Trucks.Truck>()
                    .Property(t => t.TruckNumber)
                    .HasMaxLength(250);

            #endregion

            #region Driver
            modelBuilder.Entity<Driver.Driver>()
                .ToTable("tblDriver");

            //Driver Tble Property Configurations
            modelBuilder.Entity<Driver.Driver>()
                    .Property(t => t.Status)
                    .HasMaxLength(250);

            modelBuilder.Entity<Driver.Driver>()
                       .Property(t => t.DriverName)
                       .HasMaxLength(250);

            #endregion

            #region Logs

            modelBuilder.Entity<Log.Log>()
                .ToTable("tblLog");

            //Log Tble Property Configurations
            modelBuilder.Entity<Log.Log>()
                    .Property(t => t.ActionName)
                    .HasMaxLength(250);

            modelBuilder.Entity<Log.Log>()
                       .Property(t => t.LogText)
                       .HasMaxLength(4000);

            #endregion

            #region ErrorLogs

            modelBuilder.Entity<Log.ErrorLog>()
                .ToTable("tblErrorLog");

            //ErrorLog Tble Property Configurations
            modelBuilder.Entity<Log.ErrorLog>()
                    .Property(t => t.ActionName)
                    .HasMaxLength(250);

            modelBuilder.Entity<Log.ErrorLog>()
                       .Property(t => t.LogText)
                       .HasMaxLength(4000);

            #endregion

            #region AddPretripCheckList

            modelBuilder.Entity<PreTrip.PreTripCheckList>()
                .ToTable("PreTripCheckLists");
            modelBuilder.Entity<PreTrip.PreTripCheckList>()
               .HasKey(u => u.PreTripCheckListID);

            modelBuilder.Entity<PreTrip.PreTripCheckList>()
                       .Property(t => t.DriverName)
                       .HasMaxLength(250);

            modelBuilder.Entity<PreTrip.PreTripCheckList>()
                      .Property(t => t.Trailer1Number)
                      .HasMaxLength(250);

            modelBuilder.Entity<PreTrip.PreTripCheckList>()
                      .Property(t => t.Trailer2Number)
                      .HasMaxLength(250);

            modelBuilder.Entity<PreTrip.PreTripCheckList>()
                      .Property(t => t.Trailer1ReeferHOS)
                      .HasMaxLength(250);

            modelBuilder.Entity<PreTrip.PreTripCheckList>()
                     .Property(t => t.Trailer2ReeferHOS)
                     .HasMaxLength(250);

            modelBuilder.Entity<PreTrip.PreTripCheckList>()
                     .Property(t => t.Remarks)
                     .HasMaxLength(250);

            modelBuilder.Entity<PreTrip.PreTripCheckList>()
                     .Property(t => t.OdoMeter)
                     .HasMaxLength(250);

            modelBuilder.Entity<PreTrip.PreTripCheckList>()
                    .Property(t => t.TruckNumber)
                    .HasMaxLength(250);

            #endregion

            #region ELDEvents
            modelBuilder.Entity<ELD.ELDEvent>()
                    .HasKey(u => u.id);


            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.EventType)
                    .HasMaxLength(100);
            
            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.EventCode)
                    .HasMaxLength(100);
            
            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.objectType)
                    .HasMaxLength(100);

            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.SequenceId)
                    .HasMaxLength(100);

            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.BarCode)
                    .HasMaxLength(250);
            
            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.CheckData)
                    .HasMaxLength(200);
            
            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.CheckSum)
                    .HasMaxLength(200);
            
            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.CreationDate)
                    .HasMaxLength(200);
            
            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.CreationTime)
                    .HasMaxLength(200);

            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.Date)
                    .HasMaxLength(200);
            
            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.DateTime)
                    .HasMaxLength(200);
            
            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.DriverFirstName)
                    .HasMaxLength(250);
            
            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.DriverLastName)
                    .HasMaxLength(250);
            
            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.DriverRecordId)
                    .HasMaxLength(250);

            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.ELDUsername)
                    .HasMaxLength(250);
            
            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.EngineHours)
                    .HasMaxLength(250);
            
            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.EventCode)
                    .HasMaxLength(250);
            
            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.EventCodeDescription)
                    .HasMaxLength(250);
            
            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.EventSeconds)
                    .HasMaxLength(250);
            
            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.LatitudeString)
                    .HasMaxLength(100);
            
            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.LocalizationDescription)
                    .HasMaxLength(1000);
            
            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.LongitudeString)
                    .HasMaxLength(100);
            
            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.mobileRecordId)
                    .HasMaxLength(250);
            
            modelBuilder.Entity<ELD.ELDEvent>()
                    .Property(u => u.MapMobileRecordId)
                    .HasMaxLength(250);

            #endregion
        }
    }
}
