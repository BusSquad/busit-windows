using System;
using System.Windows.Media;

namespace busit
{
    class Bus
    {
        // local variables + GETTER-SETTERs
        public double lat { get; private set; }
        public double lng { get; private set; }
        public int busID { get; private set; }
        public Color busColor { get; private set; }
        public String direction { get; set; }
        public String route
        {
            get { return route; }

            set
            {
                updateColor(value);
                route = value.ToUpperInvariant();
            }
        }

        //CONSTRUCTORs
        //Constructor class without direction
        Bus(double lat, double lng, int busID, String route)
        {
            this.lat = lat;
            this.lng = lng;
            this.busID = busID;
            setRouteAndDirection(route, "UNKNOWN");
        }

        //Constructor class for all fields incl. direction
        Bus(double lat, double lng, int busID, String route, String direction)
        {
            this.lat = lat;
            this.lng = lng;
            this.busID = busID;
            setRouteAndDirection(route, direction);
        }

        // SETTERs
        // manual set route and direction 
        public void setRouteAndDirection(String route, String direction)
        {
            this.direction = direction;
            this.route = route;
        }

        // Sets color associated with bus based on route
        private void updateColor(String route)
        {
            switch (route)
            {
                case "UPPER CAMPUS":
                    busColor = Colors.Yellow;
                    break;
                // need to update based on direction
                // for inner or outer loop
                case "LOOP":
                    if (this.direction == "INNER")
                        busColor = Colors.Orange;
                    else //(this.direction == "OUTER")
                        busColor = Colors.Blue;
                    break;
                case "NIGHT OWL":
                    busColor = Colors.DarkGray;
                    break;
                default:
                    busColor = Colors.Red;
                    break;
            }
        }

    }

}
