using MaterialDesignThemes.Wpf;
using RCOTruckApp.Services.PreTrip;
using RCOTruckApp.ViewModels.PreTrip;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace RCOTruckApp.Views.Pages.PreTrip
{
    /// <summary>
    /// Interaction logic for PersonalConveyance.xaml
    /// </summary>
    public partial class PersonalConveyance : Page
    {
        /// <summary>
        /// PaletteHelper
        /// </summary>
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        public PersonalConveyance()
        {
            InitializeComponent();
            ITheme theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(StaticServices.GenericService.GetAppTheme());
            paletteHelper.SetTheme(theme);

            PopulateGrid();
        }

        private void dgPreTripHistory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Windows.Controls.DataGrid dataGrid = (System.Windows.Controls.DataGrid)sender;
            PreTripCheckListHistoryViewModel preTripCheckListHistoryViewModel = (PreTripCheckListHistoryViewModel)dataGrid.SelectedItem;
            if (preTripCheckListHistoryViewModel != null)
            {
                PreTripCheckListDetails preTripCheckListDetails = new PreTripCheckListDetails(preTripCheckListHistoryViewModel.PreTripCheckListID);
                preTripCheckListDetails.Show();
                
            }
        }

        private void PopulateGrid()
        {
            PreTripService preTripService = new PreTripService();
            dgPreTripHistory.ItemsSource = preTripService.GetAllPreTripCheckList(dtFrom.SelectedDate.Value, dtTo.SelectedDate.Value);
        }

        private void btnShowRecords_Click(object sender, RoutedEventArgs e)
        {
            PopulateGrid();
        }
    }
}
