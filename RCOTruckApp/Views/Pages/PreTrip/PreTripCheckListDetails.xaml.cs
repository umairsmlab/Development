using MaterialDesignThemes.Wpf;
using RCOTruckApp.Models.PreTrip;
using RCOTruckApp.Services.PreTrip;
using RCOTruckApp.ViewModels.PreTrip;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;
using System;

namespace RCOTruckApp.Views.Pages.PreTrip
{
    /// <summary>
    /// Interaction logic for PreTripCheckListDetails.xaml
    /// </summary>
    public partial class PreTripCheckListDetails : Window
    {
        /// <summary>
        /// PaletteHelper
        /// </summary>
        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        public PreTripCheckListDetails()
        {
            InitializeComponent();

            ITheme theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(StaticServices.GenericService.GetAppTheme());
            paletteHelper.SetTheme(theme);
        }

        public PreTripCheckListDetails(int preTripCheckListID)
        {
            InitializeComponent();

            ITheme theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(StaticServices.GenericService.GetAppTheme());
            paletteHelper.SetTheme(theme);

            CreateAllFields();
            ShowDetails(preTripCheckListID);
        }

        private void CreateAllFields()
        {
            //create truck checkboxes
            PretripCheckListViewModel addPretripCheckListViewModel = new PretripCheckListViewModel();
            string[] arrTruckCheckList = StaticServices.GenericService.PropertiesFromType(addPretripCheckListViewModel);
            foreach (string preTripCheck in arrTruckCheckList)
            {
                System.Windows.Controls.CheckBox checkBox = new System.Windows.Controls.CheckBox();
                checkBox.Content = preTripCheck;
                checkBox.IsChecked = false;
                checkBox.IsEnabled = true;
                checkBox.Width = 150;
                checkBox.Margin = new Thickness(10, 0, 0, 0);
                checkBox.Name = preTripCheck;
                this.RegisterName(preTripCheck, checkBox);
                wpTruckPreTripCheckList.Children.Add(checkBox);
            }

            //create trailer1 checkboxes
            Trailer1ViewModel trailer1ViewModel = new Trailer1ViewModel();
            string[] arrtrailer1CheckList = StaticServices.GenericService.PropertiesFromType(trailer1ViewModel);
            foreach (string trailer1 in arrtrailer1CheckList)
            {
                System.Windows.Controls.CheckBox checkBox = new System.Windows.Controls.CheckBox();
                checkBox.Content = trailer1;
                checkBox.IsChecked = false;
                checkBox.IsEnabled = true;
                checkBox.Width = 150;
                checkBox.Margin = new Thickness(10, 0, 0, 0);
                checkBox.Name = trailer1;
                this.RegisterName(trailer1, checkBox);
                wpTrailer1CheckList.Children.Add(checkBox);
            }

            //create trailer2 checkboxes
            Trailer2ViewModel trailer2ViewModel = new Trailer2ViewModel();
            string[] arrtrailer2CheckList = StaticServices.GenericService.PropertiesFromType(trailer2ViewModel);
            foreach (string trailer2 in arrtrailer2CheckList)
            {
                System.Windows.Controls.CheckBox checkBox = new System.Windows.Controls.CheckBox();
                checkBox.Content = trailer2;
                checkBox.IsChecked = false;
                checkBox.IsEnabled = true;
                checkBox.Width = 150;
                checkBox.Margin = new Thickness(10, 0, 0, 0);
                checkBox.Name = trailer2;
                this.RegisterName(trailer2, checkBox);
                wpTrailer2CheckList.Children.Add(checkBox);
            }

            //create Remarks checkboxes
            RemarksViewModel remarksViewModel = new RemarksViewModel();
            string[] arrRemarksCheckList = StaticServices.GenericService.PropertiesFromType(remarksViewModel);
            foreach (string remarksCheck in arrRemarksCheckList)
            {
                System.Windows.Controls.CheckBox checkBox = new System.Windows.Controls.CheckBox();
                checkBox.Content = remarksCheck;
                checkBox.IsChecked = false;
                checkBox.IsEnabled = true;
                checkBox.Width = 150;
                checkBox.Margin = new Thickness(10, 0, 0, 0);
                checkBox.Name = remarksCheck;
                this.RegisterName(remarksCheck, checkBox);
                wpRemarksCheckList.Children.Add(checkBox);
            }

            //create driver checkboxes
            DriverViewModel driverViewModel = new DriverViewModel();
            string[] arrDriverCheckList = StaticServices.GenericService.PropertiesFromType(driverViewModel);
            foreach (string driverCheck in arrDriverCheckList)
            {
                System.Windows.Controls.CheckBox checkBox = new System.Windows.Controls.CheckBox();
                checkBox.Content = driverCheck;
                checkBox.IsChecked = false;
                checkBox.IsEnabled = true;
                checkBox.Width = 150;
                checkBox.Margin = new Thickness(10, 0, 0, 0);
                checkBox.Name = driverCheck;
                this.RegisterName(driverCheck, checkBox);
                wpDriverCheckList.Children.Add(checkBox);
            }
        }

        private void ShowDetails(int preTripCheckListID)
        {
            PreTripService preTripService = new PreTripService();
            PreTripCheckList preTripCheckList = preTripService.GetPreTripCheckListByID(preTripCheckListID);

            if (preTripCheckList != null)
            {
                txtRemarks.Text = String.IsNullOrEmpty(preTripCheckList.Remarks) ? "No remarks" : preTripCheckList.Remarks;
                txtodometer.Text = String.IsNullOrEmpty(preTripCheckList.OdoMeter) ? "No OdoMeter Number" : preTripCheckList.OdoMeter;
                txtDriverName.Text = String.IsNullOrEmpty(preTripCheckList.DriverName) ? "No driver name" : preTripCheckList.DriverName;
                txtTrailer1Number.Text = String.IsNullOrEmpty(preTripCheckList.Trailer1Number) ? "No Trailer 1 Number" : preTripCheckList.Trailer1Number;
                txtReefer.Text = String.IsNullOrEmpty(preTripCheckList.Trailer1ReeferHOS) ? "No Trailer 1 ReeferHOS" : preTripCheckList.Trailer1ReeferHOS;
                txtTrailer2Number.Text = String.IsNullOrEmpty(preTripCheckList.Trailer2Number) ? "No Trailer 2 Number" : preTripCheckList.Trailer2Number;
                txtReefer2.Text = String.IsNullOrEmpty(preTripCheckList.Trailer2ReeferHOS) ? "No Trailer 2 ReeferHOS" : preTripCheckList.Trailer2ReeferHOS;
                txtTruckNumber.Text = String.IsNullOrEmpty(preTripCheckList.TruckNumber) ? "No Truck Number" : preTripCheckList.TruckNumber;

                //get all preTripCheckBoxNames
                List<string> lstPreTripCheckList = new List<string>();
                lstPreTripCheckList = GetAllpreTripCheckBoxNames();

                //set values for checkboxes in model
                foreach (string chkListName in lstPreTripCheckList)
                {
                    PropertyInfo propertyInfo = preTripCheckList.GetType().GetProperty(chkListName);
                    System.Windows.Controls.CheckBox chkTemp = (System.Windows.Controls.CheckBox)this.FindName(chkListName);
                    if(chkTemp != null)
                    {
                        chkTemp.IsChecked = Convert.ToBoolean(propertyInfo.GetValue(preTripCheckList));
                    }
                }

                //Create picturebox and bind events
                System.Drawing.Image imgDriverSignature;
                PictureBox picturebox1 = new System.Windows.Forms.PictureBox();
                picturebox1.BackColor = System.Drawing.Color.White;
                if (preTripCheckList.DriverSignature != null)
                {
                    using (System.IO.MemoryStream memstr = new System.IO.MemoryStream(preTripCheckList.DriverSignature))
                    {
                        imgDriverSignature = System.Drawing.Image.FromStream(memstr);
                        picturebox1.Image = new Bitmap(imgDriverSignature);
                    }
                }
                windowsFormsHostDriver.Child = picturebox1;

                //Create picturebox and bind events
                System.Drawing.Image imgMechanicSignature;
                PictureBox picturebox2 = new System.Windows.Forms.PictureBox();
                picturebox2.BackColor = System.Drawing.Color.White;
                if (preTripCheckList.DriverSignature != null)
                {
                    using (System.IO.MemoryStream memstr = new System.IO.MemoryStream(preTripCheckList.MechanicSignature))
                    {
                        imgMechanicSignature = System.Drawing.Image.FromStream(memstr);
                        picturebox2.Image = new Bitmap(imgMechanicSignature);
                    }
                }
                windowsFormsHostMechanic.Child = picturebox2;
            }
        }

        private List<string> GetAllpreTripCheckBoxNames()
        {
            List<string> lstPreTripCheckList = new List<string>();

            PretripCheckListViewModel addPretripCheckListViewModel = new PretripCheckListViewModel();
            string[] arrPreTripCheckList = StaticServices.GenericService.PropertiesFromType(addPretripCheckListViewModel);
            lstPreTripCheckList.AddRange(arrPreTripCheckList.ToList());

            Trailer1ViewModel trailer1ViewModel = new Trailer1ViewModel();
            arrPreTripCheckList = StaticServices.GenericService.PropertiesFromType(trailer1ViewModel);
            lstPreTripCheckList.AddRange(arrPreTripCheckList.ToList());

            Trailer2ViewModel trailer2ViewModel = new Trailer2ViewModel();
            arrPreTripCheckList = StaticServices.GenericService.PropertiesFromType(trailer2ViewModel);
            lstPreTripCheckList.AddRange(arrPreTripCheckList.ToList());

            DriverViewModel driverViewModel = new DriverViewModel();
            arrPreTripCheckList = StaticServices.GenericService.PropertiesFromType(driverViewModel);
            lstPreTripCheckList.AddRange(arrPreTripCheckList.ToList());

            RemarksViewModel remarksViewModel = new RemarksViewModel();
            arrPreTripCheckList = StaticServices.GenericService.PropertiesFromType(remarksViewModel);
            lstPreTripCheckList.AddRange(arrPreTripCheckList.ToList());

            return lstPreTripCheckList;
        }
    }
}
