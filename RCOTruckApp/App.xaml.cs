using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Entity;
using RCOTruckApp.Models.DBContext;
using System.Data.Entity.Migrations;
using System.Runtime.Remoting.Contexts;

namespace RCOTruckApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //create db and seed data
            //RCOTruckDBContextSeeder rCOTruckDBContextSeeder = new RCOTruckDBContextSeeder();
            //RCOTruckDBContext rCOTruckDBContext = new RCOTruckDBContext();
            Database.SetInitializer<RCOTruckDBContext>(new MigrateDatabaseToLatestVersion<RCOTruckDBContext, RCOTruckDBMigrationConfig>(true));
           
            //handle global exceptions
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

        }

        /// <summary>
        /// handle global exceptions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //StaticServices.LogService.Log(StaticServices.LogTypes.Exception, "Exception", sender.ToString() + " - " + e.ExceptionObject.ToString(), StaticServices.UserService.LoggedInUser.UserID);
        }

    }
}
