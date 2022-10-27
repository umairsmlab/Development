using MaterialDesignThemes.Wpf;
using RCOTruckApp.Views.Windows;
using System;
using System.Windows;
using System.Windows.Input;
using RCOTruckApp.Services.User;
using RCOTruckApp.StaticServices;

namespace RCOTruckApp.Views.Pages.Login
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        /// <summary>
        /// PaletteHelper
        /// </summary>
        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        public Login()
        {
            InitializeComponent();
            
            //set app theme
            ITheme theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(GenericService.GetAppTheme());
            paletteHelper.SetTheme(theme);

            //for test
            txtUsername.Text = "awais";
            txtPassword.Password = "awais";
        }

        
        /// <summary>
        /// OnMouseLeftButtonDown
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
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
        /// Login Btn click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Please enter username");
            }
            else if (string.IsNullOrEmpty(Convert.ToString(txtPassword.Password)))
            {
                MessageBox.Show("Please enter password");
            }
            else
            {
                UserServices userServices = new UserServices();
                Models.User.Credentials user = new Models.User.Credentials();
                if (userServices.VerifyUserLogin(txtUsername.Text.Trim(), Convert.ToString(txtPassword.Password)))
                {
                    //StaticServices.LogService.Log(StaticServices.LogTypes.Login, "Login", "User: " + user.UserName + " loggedin.", StaticServices.UserService.LoggedInUser.UserID);

                    Vehicle.GetVehicleInfo getVehicleInfo = new Vehicle.GetVehicleInfo();
                    getVehicleInfo.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("UserName or password is incorrect.");
                }
            }
        }
    }
}
