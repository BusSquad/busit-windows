using System;
using System.Windows.Media;

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

        //Constructor class without direction
        Bus(double lat, double lng, int bus_id, String route)
        {
            this.lat = lat;
            this.lng = lng;
            this.bus_id = bus_id;
            this.route = route;
            direction = "UNKNOWN";
        }

        //Constructor class for all fields incl. direction
        Bus(double lat, double lng, int bus_id, String route, String direction)
        {
            this.lat = lat;
            this.lng = lng;
            this.bus_id = bus_id;
            setRouteAndDirection(route, direction);
        }

        // GETTER-SETTERs
        // accessed by dot operator 
        // e.g. for setter: bus.Route = "NIGHT OWL" 
        // or for getter: Console.Write(bus.Route)

        public String Route
        {
            get { return route; }

            set
            {
                setColor(value);
                route = value.ToUpperInvariant();
            }
        }

        public String Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        // SETTERs

        // Sets color associated with bus based on route
        private void setColor(String route)
        {
            switch (route)
            {
                case "UPPER CAMPUS":
                    bus_color = Colors.Yellow;
                    break;
                // need to update based on direction
                // for inner or outer loop
                case "LOOP":
                    if (this.direction == "INNER")
                        bus_color = Colors.Orange;
                    else //if (this.direction == "OUTER")
                        bus_color = Colors.Blue;
                    break;
                case "NIGHT OWL":
                    bus_color = Colors.DarkGray;
                    break;
                default:
                    bus_color = Colors.Red;
                    break;
            }
        }

        // manual set route and direction due to get-set
        // notation not allowing for mult params
        public void setRouteAndDirection(String newRoute, String newDirection)
        {
            this.direction = newDirection;
            this.route = newRoute;
        }

        // GETTERs

        public Color BusColor
        {
            get { return bus_color; }
        }

        public double Lat
        {
            get { return lat; }
        }

        public double Lng
        {
            get { return lng; }
        }

        public int BusId
        {
            get { return bus_id; }
        }
    }

}
