using System.Collections.Generic;
using System.Device.Location;      // Provides the GeoCoordinate class.
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using Windows.Devices.Geolocation;  // Provides the Geocoordinate class
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Threading;

// TODO: Put ShowBusLocations in a runnable
// and place markers on map

namespace busit
{
    public partial class MainPage : PhoneApplicationPage
    {

        private DispatcherTimer dispatcherTimer;
        private List<Bus> buses;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }


        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateMap();
            ShowUserLocation();
            dispatcherTimer.Start();
            // ShowBusLocations();
        }

        private void UpdateMap()
        {
            CampusMap.SetView(new GeoCoordinate(36.991406, -122.060731), 14);
        }


        // repeats functions in this function 
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //do whatever you want to do here
            ShowBusLocations();
            drawBusMarkers();
        }
        

        // drawMarkersInMap
        private void drawBusMarkers()
        {
            if (buses != null)
            {
                for (int i = 0; i < buses.Count; i++)
                {
                    Debug.WriteLine(buses[i].Type);
                    Debug.WriteLine(buses[i].Lon);
                    Debug.WriteLine(buses[i].Lat);
                    Ellipse userCircle = new Ellipse();
                    //userCircle.Fill = new SolidColorBrush(buses.);
                    userCircle.Height = 16;
                    userCircle.Height = 16;
                    userCircle.Width = 16;

                }
            }
           
        }

        


        // gets a list of buses from the online json file
        private async void ShowBusLocations()
        {
            // poll server for bus locations
            
            BusTrackers busTrackerInfo = new BusTrackers();
            buses = await busTrackerInfo.GetBusTrackerDataAsync();

            // for debugging purposes
            if(buses != null)
            {
                foreach(Bus bus in buses)
                {
                    Debug.WriteLine(bus);
                }
            }

        }




        // shows users location
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