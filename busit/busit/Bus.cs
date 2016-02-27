using System;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace busit
{
    class Bus
    {
        private String route;
        private String direction;
        private Color bus_color;
        private double lat;
        private double lng;
        private int bus_id;

        Bus(double lat, double lng, String route, int bus_id)
        {
            this.lat = lat;
            this.lng = lng;
            this.bus_id = bus_id;
            setColor(route);
            this.route = route.ToUpperInvariant();
            this.direction = "UNKNOWN";
        }

        // Sets color associated with bus based on route
        private void setColor(String route)
        {
            switch (route)
            {
                case "UPPER CAMPUS":
                    this.bus_color = Colors.Yellow;
                    break;
                // need to update based on direction
                // for inner or outer loop
                case "LOOP":
                    this.bus_color = Colors.Blue;
                    break;
                case "NIGHT OWL":
                    this.bus_color = Colors.DarkGray;
                    break;
                default:
                    this.bus_color = Colors.Red;
                    break;
            }
        }

        public void setRoute(String newRoute)
        {
            setColor(newRoute);
            this.route = newRoute.ToUpperInvariant();
        }

        public void setRoute(String newRoute, String newDirection)
        {
            setRoute(newRoute);
            this.direction = newDirection.ToUpperInvariant();
        }

        public String getRoute()
        {
            return this.route;
        }

        public String getDirection()
        {
            return this.direction;
        }

        public Color getColor()
        {
            return this.bus_color;
        }

        public double getLat()
        {
            return this.lat;
        }

        public double getLng()
        {
            return this.lng;
        }

        public int getBusId()
        {
            return this.bus_id;
        }
    }

}
