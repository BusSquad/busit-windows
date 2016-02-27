using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Maps.Controls;
using busit.Resources;
using System.Device.Location;

namespace busit
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Map OurMap = new Map();
            ContentPanel.Children.Add(OurMap);
            Loaded += MainPage_Loaded;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }


        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateMap();
        }



        private void UpdateMap()
        {
            CampusMap.SetView(new GeoCoordinate(36.991406, -122.060731), 15);
        }

    }
}