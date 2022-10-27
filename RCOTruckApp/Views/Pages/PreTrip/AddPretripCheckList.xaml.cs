using MaterialDesignThemes.Wpf;
using RCOTruckApp.Services.PreTrip;
using RCOTruckApp.ViewModels.PreTrip;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RCOTruckApp.Views.Pages.PreTrip
{
    /// <summary>
    /// Interaction logic for AddPretripCheckList.xaml
    /// </summary>
    public partial class AddPretripCheckList : Page
    {
        /// <summary>
        /// PaletteHelper
        /// </summary>
        private readonly PaletteHelper paletteHelper = new PaletteHelper();


        private Dictionary<int, List<System.Drawing.Point>> signatureDriver = new Dictionary<int, List<System.Drawing.Point>>();
        private System.Drawing.Pen signaturePenDriver = new System.Drawing.Pen(System.Drawing.Color.Black, 4);
        private List<System.Drawing.Point> driverCurvePoints;
        private int driverCurve = -1;


        private Dictionary<int, List<System.Drawing.Point>> signatureMechanic = new Dictionary<int, List<System.Drawing.Point>>();
        private System.Drawing.Pen signaturePenMechanic = new System.Drawing.Pen(System.Drawing.Color.Black, 4);
        private List<System.Drawing.Point> mechanicCurvePoints;
        private int mechanicCurve = -1;

        public AddPretripCheckList()
        {
            InitializeComponent();
            ITheme theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(StaticServices.GenericService.GetAppTheme());
            paletteHelper.SetTheme(theme);

            CreateAllFields();

            //Create picturebox and bind events
            System.Windows.Forms.PictureBox picturebox1 = new System.Windows.Forms.PictureBox();
            picturebox1.BackColor = System.Drawing.Color.White;
            windowsFormsHostDriver.Child = picturebox1;
            picturebox1.Paint += new System.Windows.Forms.PaintEventHandler(picturebox1_Paint);
            picturebox1.MouseMove += Picturebox1_MouseMove;
            picturebox1.MouseDown += Picturebox1_MouseDown;

            System.Windows.Forms.PictureBox picturebox2 = new System.Windows.Forms.PictureBox();
            picturebox2.BackColor = System.Drawing.Color.White;
            windowsFormsHostMechanic.Child = picturebox2;
            picturebox2.Paint += new System.Windows.Forms.PaintEventHandler(picturebox2_Paint);
            picturebox2.MouseMove += Picturebox2_MouseMove;
            picturebox2.MouseDown += Picturebox2_MouseDown;
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

        /// <summary>
        /// To Check All Points
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAll_Checked(object sender, RoutedEventArgs e)
        {
            List<string> lstPreTripCheckList = new List<string>();
            lstPreTripCheckList = GetAllpreTripCheckBoxNames();

            foreach (string preTripCheck in lstPreTripCheckList)
            {
                System.Windows.Controls.CheckBox cb = (System.Windows.Controls.CheckBox)this.FindName(preTripCheck);
                if (cb != null)
                {
                    cb.IsChecked = true;
                }
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

        /// <summary>
        /// Uncheck All Points
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAll_Unchecked(object sender, RoutedEventArgs e)
        {
            UnCheckAll();
        }

        private void UnCheckAll()
        {
            List<string> lstPreTripCheckList = new List<string>();
            lstPreTripCheckList = GetAllpreTripCheckBoxNames();

            foreach (string preTripCheck in lstPreTripCheckList)
            {
                System.Windows.Controls.CheckBox cb = (System.Windows.Controls.CheckBox)this.FindName(preTripCheck);
                if (cb != null)
                {
                    cb.IsChecked = false;
                }
            }
            chkAll.IsChecked = false;
        }


        //picturebox implementation to capture signature.
        private void DrawSignatureDriver(Graphics g)
        {
            g.CompositingMode = CompositingMode.SourceOver;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (var curve in signatureDriver)
            {
                if (curve.Value.Count < 2)
                    continue;
                using (GraphicsPath gPath = new GraphicsPath())
                {
                    gPath.AddCurve(curve.Value.ToArray(), 0.5F);
                    g.DrawPath(signaturePenDriver, gPath);
                }
            }
        }

        private void DrawSignatureMechanic(Graphics g)
        {
            g.CompositingMode = CompositingMode.SourceOver;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (var curve in signatureMechanic)
            {
                if (curve.Value.Count < 2)
                    continue;
                using (GraphicsPath gPath = new GraphicsPath())
                {
                    gPath.AddCurve(curve.Value.ToArray(), 0.5F);
                    g.DrawPath(signaturePenMechanic, gPath);
                }
            }
        }

        /// <summary>
        /// click on signature area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Picturebox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            driverCurvePoints = new List<System.Drawing.Point>();
            driverCurve += 1;
            signatureDriver.Add(driverCurve, driverCurvePoints);
        }

        /// <summary>
        ///MouseMove on signature area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Picturebox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || driverCurve < 0)
                return;
            signatureDriver[driverCurve].Add(e.Location);
            windowsFormsHostDriver.Child.Invalidate();
        }

        /// <summary>
        /// click on signature area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Picturebox2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mechanicCurvePoints = new List<System.Drawing.Point>();
            mechanicCurve += 1;
            signatureMechanic.Add(mechanicCurve, mechanicCurvePoints);
        }

        /// <summary>
        ///MouseMove on signature area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Picturebox2_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || mechanicCurve < 0)
                return;
            signatureMechanic[mechanicCurve].Add(e.Location);
            windowsFormsHostMechanic.Child.Invalidate();
        }

        /// <summary>
        /// paint on picturebox1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void picturebox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (driverCurve < 0 || signatureDriver[driverCurve].Count == 0)
                return;
            DrawSignatureDriver(e.Graphics);
        }

        void picturebox2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (mechanicCurve < 0 || signatureMechanic[mechanicCurve].Count == 0)
                return;
            DrawSignatureMechanic(e.Graphics);
        }

        /// <summary>
        /// save form and signature
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            AddPretripCheckListViewModel addPretripCheckListViewModel = new AddPretripCheckListViewModel();

            addPretripCheckListViewModel.Remarks = txtRemarks.Text;
            addPretripCheckListViewModel.OdoMeter = txtodometer.Text;
            addPretripCheckListViewModel.DriverName = txtDriverName.Text;
            addPretripCheckListViewModel.Trailer1Number = txtTrailer1Number.Text;
            addPretripCheckListViewModel.Trailer1ReeferHOS = txtReefer.Text;
            addPretripCheckListViewModel.Trailer2Number = txtTrailer2Number.Text;
            addPretripCheckListViewModel.Trailer2ReeferHOS = txtReefer2.Text;
            addPretripCheckListViewModel.TruckNumber = txtTruckNumber.Text;
            addPretripCheckListViewModel.UserID = StaticServices.UserService.LoggedInUser.id;

            //get all preTripCheckBoxNames
            List<string> lstPreTripCheckList = new List<string>();
            lstPreTripCheckList = GetAllpreTripCheckBoxNames();

            //set values for checkboxes in model
            foreach (string chkListName in lstPreTripCheckList)
            {
                PropertyInfo propertyInfo = addPretripCheckListViewModel.GetType().GetProperty(chkListName);
                propertyInfo.SetValue(addPretripCheckListViewModel, Convert.ChangeType((System.Windows.Controls.CheckBox)this.FindName(lstPreTripCheckList.FirstOrDefault(x => x.Equals(chkListName))) != null ? ((System.Windows.Controls.CheckBox)this.FindName(lstPreTripCheckList.FirstOrDefault(x => x.Equals(chkListName)))).IsChecked.Value : false, propertyInfo.PropertyType), null);
            }

            //save signature
            if (driverCurve < 0 || signatureDriver[driverCurve].Count == 0)
            {
                addPretripCheckListViewModel.DriverSignature = null;
            }
            else
            {
                using (Bitmap imgSignature = new Bitmap(windowsFormsHostDriver.Child.Width, windowsFormsHostDriver.Child.Height))
                {
                    using (Graphics g = Graphics.FromImage(imgSignature))
                    {
                        DrawSignatureDriver(g);
                        addPretripCheckListViewModel.DriverSignature = StaticServices.GenericService.ImageToByte(imgSignature);
                    }
                }
            }

            if (mechanicCurve < 0 || signatureMechanic[mechanicCurve].Count == 0)
            {
                addPretripCheckListViewModel.MechanicSignature = null;
            }
            else
            {
                using (Bitmap imgSignature = new Bitmap(windowsFormsHostMechanic.Child.Width, windowsFormsHostMechanic.Child.Height))
                {
                    using (Graphics g = Graphics.FromImage(imgSignature))
                    {
                        DrawSignatureMechanic(g);
                        addPretripCheckListViewModel.MechanicSignature = StaticServices.GenericService.ImageToByte(imgSignature);
                    }
                }
            }

            PreTripService preTripService = new PreTripService();
            if (preTripService.AddPreTripCheckList(addPretripCheckListViewModel, lstPreTripCheckList))
            {
                UnCheckAll();
                ClearSignature();
                ClearTextFields();
                System.Windows.MessageBox.Show("Changes Saved", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                System.Windows.MessageBox.Show("Error saving changes", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ClearTextFields()
        {
            txtDriverName.Text = "";
            txtodometer.Text = "";
            txtReefer.Text = "";
            txtReefer2.Text = "";
            txtRemarks.Text = "";
            txtTrailer1Number.Text = "";
            txtTrailer2Number.Text = "";
            txtTruckNumber.Text = "";
        }

        /// <summary>
        /// clear signature
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearSignature();
        }

        private void ClearSignature()
        {
            driverCurve = -1;
            signatureDriver.Clear();
            windowsFormsHostDriver.Child.Invalidate();

            mechanicCurve = -1;
            signatureMechanic.Clear();
            windowsFormsHostMechanic.Child.Invalidate();
        }
    }
}
