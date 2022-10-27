using GMap.NET;
using GMap.NET.MapProviders;
using RCOTruckApp.Services;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RCOTruckApp.Views.Pages.Dashboard
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Map View Loaded 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapView_Loaded(object sender, RoutedEventArgs e)
        {
            GMapProviders.GoogleMap.ApiKey = "AIzaSyCagY1xGIa4uAHOhjrH7ep5zEQb70aUg9A";
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            // choose your provider here
            mapView.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            mapView.MinZoom = 1;
            mapView.MaxZoom = 11;
            // whole world zoom
            mapView.Zoom = 11;
            // lets the map use the mousewheel to zoom
            mapView.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            // lets the user drag the map
            mapView.CanDragMap = true;
            // lets the user drag the map with the left mouse button
            mapView.DragButton = MouseButton.Left;


            var watcher = new System.Device.Location.GeoCoordinateWatcher(System.Device.Location.GeoPositionAccuracy.High);
            watcher.StatusChanged += (s, ev) => Debug.WriteLine($"Status changed: {ev.Status}");
            watcher.PositionChanged += (s, ev) =>
            {
                //var markerOverlay = new GMapOverlay("markers");

                GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
                mapView.Position = new GMap.NET.PointLatLng(ev.Position.Location.Latitude, ev.Position.Location.Longitude);
                mapView.ShowCenter = false;

                GMap.NET.WindowsPresentation.GMapMarker marker = new GMap.NET.WindowsPresentation.GMapMarker(new GMap.NET.PointLatLng(ev.Position.Location.Latitude, ev.Position.Location.Longitude));
                marker.Shape = new Ellipse
                {
                    Width = 10,
                    Height = 10,
                    Stroke = Brushes.Red,
                    StrokeThickness = 1.5,
                    ToolTip = "This is tooltip",
                    Visibility = Visibility.Visible,
                    Fill = Brushes.Red,

                };
                mapView.Markers.Add(marker);



                //markerOverlay.Markers.Add(marker);
                //mapView.Markers.Add(marker);
                mapView.Position = new PointLatLng(ev.Position.Location.Latitude, ev.Position.Location.Longitude);
                
                //markers.Markers.Add(marker);
            };
            watcher.Start();


        }
    }
}
