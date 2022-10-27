using MaterialDesignThemes.Wpf;
using RCOTruckApp.Services.Vehicle;
using RCOTruckApp.StaticServices;
using RCOTruckApp.Views.Windows;
using System.Windows;


namespace RCOTruckApp.Views.Pages.Vehicle
{
    /// <summary>
    /// Interaction logic for GetVehicleInfo.xaml
    /// </summary>
    public partial class GetVehicleInfo : Window
    {
        /// <summary>
        /// PaletteHelper
        /// </summary>
        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        public GetVehicleInfo()
        {
            InitializeComponent();

            ITheme theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(GenericService.GetAppTheme());
            paletteHelper.SetTheme(theme);
            txtTruckNumber.Text = "123";

            txtTrailerNumber1.Text = StaticServices.UserService.Trailer1Number;
            txtTrailerNumber2.Text = StaticServices.UserService.Trailer2Number;
        }

        /// <summary>
        /// Close Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Capture vehicle info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            StaticServices.UserService.Trailer1Number = txtTrailerNumber1.Text;
            StaticServices.UserService.Trailer2Number = txtTrailerNumber2.Text;
            StaticServices.UserService.TruckNumber = txtTruckNumber.Text;

            if (string.IsNullOrEmpty(txtTruckNumber.Text.Trim()))
            {
                MessageBox.Show("Please enter truck number");
            }
            else
            {
                string truckNumber = txtTruckNumber.Text.Trim();
                VehicleServices vehicleServices = new VehicleServices();
                if (vehicleServices.VerifyVehicleInfo(truckNumber))
                {
                    //StaticServices.LogService.Log(StaticServices.LogTypes.VehicleInfo, "vehicle info added", truckNumber, StaticServices.UserService.LoggedInUser.UserID);
                    MainContainer mainContainer = new MainContainer();

                    mainContainer.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid truck number");
                }

            }
        }
    }
}
