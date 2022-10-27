using GMap.NET;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.Services
{
    internal class LocationService
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public void GetCurrentLocation()
        {
                var watcher = new System.Device.Location.GeoCoordinateWatcher(System.Device.Location.GeoPositionAccuracy.High);
                watcher.StatusChanged += (s, e) => Debug.WriteLine($"Status changed: {e.Status}");
                watcher.PositionChanged += (s, e) =>
                {
                     this.Latitude = e.Position.Location.Latitude;
                    this.Longitude = e.Position.Location.Longitude;

                };
                watcher.Start();
            // watcher.Stop();
        }
        // this receives the current GPS position (or the simulated one in the emulator)
    }
}
