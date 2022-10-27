
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows;
using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using RCOTruckApp.Models.DBContext;
using RCOTruckApp.Models.ELD;
using RCOTruckApp.Models.User;
using RCOTruckApp.Services.Driver;
using RCOTruckApp.Services.Helper;
using RCOTruckApp.StaticServices;
using RCOTruckApp.Views.Pages.Dashboard;
using RCOTruckApp.Views.Pages.PreTrip;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RCOTruckApp.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainContainer.xaml
    /// </summary>
    public partial class MainContainer : Window
    {
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        private readonly BackgroundWorker worker = new BackgroundWorker();
        public MainContainer()
        {
            InitializeComponent();

            //set app theme
            ITheme theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(GenericService.GetAppTheme());
            paletteHelper.SetTheme(theme);

            LoggedInUser.Header = "User: " + StaticServices.UserService.LoggedInUserCredentials.username;
            TruckNumber.Header = "Truck #: " + (String.IsNullOrEmpty(StaticServices.UserService.LoggedInUser.trucknumber) ? StaticServices.UserService.TruckNumber : StaticServices.UserService.LoggedInUser.trucknumber);
            Trailer1Number.Header = "Trailer 1 #: " + StaticServices.UserService.Trailer1Number;
            Trailer2Number.Header = "Trailer 2 #: " + StaticServices.UserService.Trailer2Number;

            // background worker for ELD events
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        #region BackgroundWorker
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {

            using (var client = new HttpClient())
            {
                string CountURL = APIURLHelper.ELDEventsCount;

                client.BaseAddress = new Uri(APIURLHelper.BaseURL);
                HttpResponseMessage response = client.GetAsync(CountURL).Result;
                var json = response.Content.ReadAsStringAsync().Result;
                string recordCount = Regex.Match(json, @"\d+").Value;

                if (response.IsSuccessStatusCode && Convert.ToInt32(recordCount) > 0)
                {
                    string ELDEventsRecordsURL = APIURLHelper.ELDEventsRecords;

                    RCOTruckDBContext context = new RCOTruckDBContext();
                    var data = context.ELDEvents.OrderByDescending(x => x.RMSTimestamp).FirstOrDefault();
                    if (data != null)
                    {
                        ELDEventsRecordsURL = ELDEventsRecordsURL.Replace("timeStampValue", data.RMSTimestamp);
                    }
                    else
                    {
                        ELDEventsRecordsURL = ELDEventsRecordsURL.Replace("timeStampValue", "0");
                    }
                    response = client.GetAsync(ELDEventsRecordsURL).Result;
                    var ELDRecodsjson = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        List<ELDEventResponseModel> responseEldModels = JsonConvert.DeserializeObject<List<ELDEventResponseModel>>(ELDRecodsjson);
                        foreach (var responseEldModel in responseEldModels)
                        {
                            var eLDEventObj = context.ELDEvents.FirstOrDefault(x => x.LobjectId == responseEldModel.LobjectId);
                            if (eLDEventObj == null)
                            {
                                ELDEvent eLDEvent = new ELDEvent
                                {
                                    LobjectId = responseEldModel.LobjectId,
                                    MapMobileRecordId = responseEldModel.mapCodingInfo.MobileRecordId,
                                    BarCode = responseEldModel.mapCodingInfo.BarCode,
                                    CheckData = responseEldModel.mapCodingInfo.CheckData,
                                    CheckSum = responseEldModel.mapCodingInfo.CheckSum,
                                    CreationDate = responseEldModel.mapCodingInfo.CreationDate,
                                    CreationTime = responseEldModel.mapCodingInfo.CreationTime,
                                    Date = responseEldModel.mapCodingInfo.Date,
                                    DateTime = responseEldModel.mapCodingInfo.DateTime,
                                    DriverFirstName = responseEldModel.mapCodingInfo.DriverFirstName,
                                    DriverLastName = responseEldModel.mapCodingInfo.DriverLastName,
                                    DriverRecordId = responseEldModel.mapCodingInfo.DriverRecordId,
                                    ELDUsername = responseEldModel.mapCodingInfo.ELDUsername,
                                    EngineHours = responseEldModel.mapCodingInfo.EngineHours,
                                    EventCode = responseEldModel.mapCodingInfo.EventCode,
                                    EventCodeDescription = responseEldModel.mapCodingInfo.EventCodeDescription,
                                    EventSeconds = responseEldModel.mapCodingInfo.EventSeconds,
                                    EventType = responseEldModel.mapCodingInfo.EventType,
                                    iCsvRow = responseEldModel.iCsvRow,
                                    LatitudeString = responseEldModel.mapCodingInfo.LatitudeString,
                                    LongitudeString = responseEldModel.mapCodingInfo.LongitudeString,
                                    LocalizationDescription = responseEldModel.mapCodingInfo.LocalizationDescription,
                                    mobileRecordId = responseEldModel.mobileRecordId,
                                    ObjectName = responseEldModel.mapCodingInfo.ObjectName,
                                    objectType = responseEldModel.objectType,
                                    Odometer = responseEldModel.mapCodingInfo.Odometer,
                                    OrderNumberCMV = responseEldModel.mapCodingInfo.OrderNumberCMV,
                                    OrderNumberUser = responseEldModel.mapCodingInfo.OrderNumberUser,
                                    OrganizationName = responseEldModel.mapCodingInfo.OrganizationName,
                                    OrganizationNumber = responseEldModel.mapCodingInfo.OrganizationNumber,
                                    RecordId = responseEldModel.mapCodingInfo.RecordId,
                                    RecordOrigin = responseEldModel.mapCodingInfo.RecordOrigin,
                                    RecordOriginId = responseEldModel.mapCodingInfo.RecordOriginId,
                                    RecordStatus = responseEldModel.mapCodingInfo.RecordStatus,
                                    RMSCodingTimestamp = responseEldModel.mapCodingInfo.RMSCodingTimestamp,
                                    RMSTimestamp = responseEldModel.mapCodingInfo.RMSTimestamp,
                                    SequenceId = responseEldModel.mapCodingInfo.SequenceId,
                                    ShiftStart = responseEldModel.mapCodingInfo.ShiftStart,
                                    Time = responseEldModel.mapCodingInfo.Time,
                                    VehicleMiles = responseEldModel.mapCodingInfo.VehicleMiles,
                                    VIN = responseEldModel.mapCodingInfo.VIN
                                };
                                context.ELDEvents.Add(eLDEvent);
                            }
                            else
                            {

                                eLDEventObj.LobjectId = responseEldModel.LobjectId;
                                eLDEventObj.MapMobileRecordId = responseEldModel.mapCodingInfo.MobileRecordId;
                                eLDEventObj.BarCode = responseEldModel.mapCodingInfo.BarCode;
                                eLDEventObj.CheckData = responseEldModel.mapCodingInfo.CheckData;
                                eLDEventObj.CheckSum = responseEldModel.mapCodingInfo.CheckSum;
                                eLDEventObj.CreationDate = responseEldModel.mapCodingInfo.CreationDate;
                                eLDEventObj.CreationTime = responseEldModel.mapCodingInfo.CreationTime;
                                eLDEventObj.Date = responseEldModel.mapCodingInfo.Date;
                                eLDEventObj.DateTime = responseEldModel.mapCodingInfo.DateTime;
                                eLDEventObj.DriverFirstName = responseEldModel.mapCodingInfo.DriverFirstName;
                                eLDEventObj.DriverLastName = responseEldModel.mapCodingInfo.DriverLastName;
                                eLDEventObj.DriverRecordId = responseEldModel.mapCodingInfo.DriverRecordId;
                                eLDEventObj.ELDUsername = responseEldModel.mapCodingInfo.ELDUsername;
                                eLDEventObj.EngineHours = responseEldModel.mapCodingInfo.EngineHours;
                                eLDEventObj.EventCode = responseEldModel.mapCodingInfo.EventCode;
                                eLDEventObj.EventCodeDescription = responseEldModel.mapCodingInfo.EventCodeDescription;
                                eLDEventObj.EventSeconds = responseEldModel.mapCodingInfo.EventSeconds;
                                eLDEventObj.EventType = responseEldModel.mapCodingInfo.EventType;
                                eLDEventObj.iCsvRow = responseEldModel.iCsvRow;
                                eLDEventObj.LatitudeString = responseEldModel.mapCodingInfo.LatitudeString;
                                eLDEventObj.LongitudeString = responseEldModel.mapCodingInfo.LongitudeString;
                                eLDEventObj.LocalizationDescription = responseEldModel.mapCodingInfo.LocalizationDescription;
                                eLDEventObj.mobileRecordId = responseEldModel.mobileRecordId;
                                eLDEventObj.ObjectName = responseEldModel.mapCodingInfo.ObjectName;
                                eLDEventObj.objectType = responseEldModel.objectType;
                                eLDEventObj.Odometer = responseEldModel.mapCodingInfo.Odometer;
                                eLDEventObj.OrderNumberCMV = responseEldModel.mapCodingInfo.OrderNumberCMV;
                                eLDEventObj.OrderNumberUser = responseEldModel.mapCodingInfo.OrderNumberUser;
                                eLDEventObj.OrganizationName = responseEldModel.mapCodingInfo.OrganizationName;
                                eLDEventObj.OrganizationNumber = responseEldModel.mapCodingInfo.OrganizationNumber;
                                eLDEventObj.RecordId = responseEldModel.mapCodingInfo.RecordId;
                                eLDEventObj.RecordOrigin = responseEldModel.mapCodingInfo.RecordOrigin;
                                eLDEventObj.RecordOriginId = responseEldModel.mapCodingInfo.RecordOriginId;
                                eLDEventObj.RecordStatus = responseEldModel.mapCodingInfo.RecordStatus;
                                eLDEventObj.RMSCodingTimestamp = responseEldModel.mapCodingInfo.RMSCodingTimestamp;
                                eLDEventObj.RMSTimestamp = responseEldModel.mapCodingInfo.RMSTimestamp;
                                eLDEventObj.SequenceId = responseEldModel.mapCodingInfo.SequenceId;
                                eLDEventObj.ShiftStart = responseEldModel.mapCodingInfo.ShiftStart;
                                eLDEventObj.Time = responseEldModel.mapCodingInfo.Time;
                                eLDEventObj.VehicleMiles = responseEldModel.mapCodingInfo.VehicleMiles;
                                eLDEventObj.VIN = responseEldModel.mapCodingInfo.VIN;
                            }
                        }

                        context.SaveChanges();
                    }
                }
            }
        }

        private void worker_RunWorkerCompleted(object sender,
                                                   RunWorkerCompletedEventArgs e)
        {
            //update ui once worker complete his work
        }
        #endregion

        /// <summary>
        /// Click on drive button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrive_Click(object sender, RoutedEventArgs e)
        {
            frmNavBar.Content = new Dashboard();
        }

        /// <summary>
        /// click on AddPretripChecklist btn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPretripChecklist_Click(object sender, RoutedEventArgs e)
        {
            frmNavBar.Content = new AddPretripCheckList();
        }

        /// <summary>
        /// click on Personal btn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPersonalConveyance_Click(object sender, RoutedEventArgs e)
        {
            frmNavBar.Content = new PersonalConveyance();
        }

        /// <summary>
        /// click on Signout btn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            //StaticServices.LogService.Log(StaticServices.LogTypes.Logout, "Logout", "User: " + StaticServices.UserService.LoggedInUser.UserName + " loggedout.", StaticServices.UserService.LoggedInUser.UserID);
            Application.Current.Shutdown();
        }

        /// <summary>
        /// click on OffDuty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OffDuty_Click(object sender, RoutedEventArgs e)
        {
            DriverServies driverServies = new DriverServies();
            driverServies.UpdateDriverStatus(StaticServices.DriverDutyStatus.OffDuty);
            //StaticServices.LogService.Log(StaticServices.LogTypes.DriverStatus, "Driver status updated", "Off duty", StaticServices.UserService.LoggedInUser.UserID);

            chkOffDuty.IsChecked = true;
            chkOnDuty.IsChecked = false;
            chkSleepingBirth.IsChecked = false;
            chkDriving.IsChecked = false;
            chkBreak.IsChecked = false;
        }

        /// <summary>
        /// click on OnDuty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDuty_Click(object sender, RoutedEventArgs e)
        {
            DriverServies driverServies = new DriverServies();
            driverServies.UpdateDriverStatus(StaticServices.DriverDutyStatus.OnDuty);
            //StaticServices.LogService.Log(StaticServices.LogTypes.DriverStatus, "Driver status updated", "Onduty", StaticServices.UserService.LoggedInUser.UserID);

            chkOffDuty.IsChecked = false;
            chkOnDuty.IsChecked = true;
            chkSleepingBirth.IsChecked = false;
            chkDriving.IsChecked = false;
            chkBreak.IsChecked = false;
        }

        /// <summary>
        /// click on SleepingBirth
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SleepingBirth_Click(object sender, RoutedEventArgs e)
        {
            DriverServies driverServies = new DriverServies();
            driverServies.UpdateDriverStatus(StaticServices.DriverDutyStatus.SleeperBerth);
            //StaticServices.LogService.Log(StaticServices.LogTypes.DriverStatus, "Driver status updated", "SleepingBirth", StaticServices.UserService.LoggedInUser.UserID);

            chkOffDuty.IsChecked = false;
            chkOnDuty.IsChecked = false;
            chkSleepingBirth.IsChecked = true;
            chkDriving.IsChecked = false;
            chkBreak.IsChecked = false;
        }

        /// <summary>
        /// click on Driving
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Driving_Click(object sender, RoutedEventArgs e)
        {
            DriverServies driverServies = new DriverServies();
            driverServies.UpdateDriverStatus(StaticServices.DriverDutyStatus.Driving);
            //StaticServices.LogService.Log(StaticServices.LogTypes.DriverStatus, "Driver status updated", "Driving", StaticServices.UserService.LoggedInUser.UserID);

            chkOffDuty.IsChecked = false;
            chkOnDuty.IsChecked = false;
            chkSleepingBirth.IsChecked = false;
            chkDriving.IsChecked = true;
            chkBreak.IsChecked = false;
        }

        /// <summary>
        /// click on Break
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Break_Click(object sender, RoutedEventArgs e)
        {
            DriverServies driverServies = new DriverServies();
            driverServies.UpdateDriverStatus(StaticServices.DriverDutyStatus.Break);
            //StaticServices.LogService.Log(StaticServices.LogTypes.DriverStatus, "Driver status updated", "Break", StaticServices.UserService.LoggedInUser.UserID);

            chkOffDuty.IsChecked = false;
            chkOnDuty.IsChecked = false;
            chkSleepingBirth.IsChecked = false;
            chkDriving.IsChecked = false;
            chkBreak.IsChecked = true;
        }

        private void TruckNumber_Click(object sender, RoutedEventArgs e)
        {
            Pages.Vehicle.GetVehicleInfo getVehicleInfo = new Pages.Vehicle.GetVehicleInfo();
            getVehicleInfo.Show();
            this.Close();
        }

        private void TrailerNumber_Click(object sender, RoutedEventArgs e)
        {
            Pages.Vehicle.GetVehicleInfo getVehicleInfo = new Pages.Vehicle.GetVehicleInfo();
            getVehicleInfo.Show();
            this.Close();
        }
    }
}
