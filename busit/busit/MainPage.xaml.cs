using System.Collections.Generic;
using System.Device.Location;      // Provides the GeoCoordinate class.
using System.Linq;
using System;
using System.Net;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Maps.Controls;
using Windows.Devices.Geolocation;  // Provides the Geocoordinate class
using busit.Resources;
using System.Threading.Tasks;

namespace busit
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }


        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateMap();
            ShowUserLocation();
            ShowBusLocations();
        }

        private void UpdateMap()
        {
            CampusMap.SetView(new GeoCoordinate(36.991406, -122.060731), 14);
        }

        private async void ShowBusLocations()
        {
            // poll server for bus locations
            BusTrackers busTrackerInfo = new BusTrackers();
            List<Bus> buses = await busTrackerInfo.GetBusTrackerDataAsync();
            
            // for debugging purposes
            Console.Write(buses);

            // TODO: Parse Json Array and place markers on map
            // refer to documentation for Json.NET
            // @ http://www.newtonsoft.com/json/help/html/Introduction.htm
            // Preferred that BusTrackers return a list of Buses.
        }

        private async void ShowUserLocation()
        {
            // Get my current location requires stupid conversions
            Geolocator myGeolocator = new Geolocator();
            Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
            Geocoordinate myGeocoordinate = myGeoposition.Coordinate;
            GeoCoordinate userLocation =
                CoordinateConverter.ConvertGeocoordinate(myGeocoordinate);

            // Create a small circle to indicate location
            Ellipse userCircle = new Ellipse();
            userCircle.Fill = new SolidColorBrush(Colors.Blue);
            userCircle.Height = 16;
            userCircle.Height = 16;
            userCircle.Width = 16;

            // Create a MapOverlay to contain the circle.
            MapOverlay myLocationOverlay = new MapOverlay();
            myLocationOverlay.Content = userCircle;
            myLocationOverlay.PositionOrigin = new Point(0.5, 0.5);
            myLocationOverlay.GeoCoordinate = userLocation;

            // Create a MapLayer to contain the MapOverlay.
            MapLayer myLocationLayer = new MapLayer();
            myLocationLayer.Add(myLocationOverlay);
            // Add the MapLayer to the Map
            CampusMap.Layers.Add(myLocationLayer);

            // NOTE: The following is disabled due to Microsoft
            // defaulting geolocations to their headquarters in
            // Redmond, WA until obtaining a token for location
            // information -- which is only available when
            // submitting an app to their store.

            // Center map on current location
            //this.CampusMap.Center = userLocation;
            //this.CampusMap.ZoomLevel = 13;
        }
    }
}