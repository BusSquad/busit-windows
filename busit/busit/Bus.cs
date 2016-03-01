using System;
using System.Windows.Media;

namespace busit
{
    class Bus
    {
        // local variables + GETTER-SETTERs
        public double lat { get; private set; }
        public double lon { get; private set; }
        public int busID { get; private set; }
        public Color busColor { get; private set; }
        public String direction { get; set; }
        public String type
        {
            get { return type; }

            set
            {
                updateColor(value);
                type = value.ToUpperInvariant();
            }
        }

        //CONSTRUCTORs
        //Constructor class without direction
        Bus(double lat, double lon, int busID, String type)
        {
            this.lat = lat;
            this.lon = lon;
            this.busID = busID;
            setRouteAndDirection(type, "UNKNOWN");
        }

        //Constructor class for all fields incl. direction
        Bus(double lat, double lon, int busID, String type, String direction)
        {
            this.lat = lat;
            this.lon = lon;
            this.busID = busID;
            setRouteAndDirection(type, direction);
        }

        // SETTERs
        // manual set route and direction 
        public void setRouteAndDirection(String type, String direction)
        {
            this.direction = direction;
            this.type = type;
        }

        // Sets color associated with bus based on route
        private void updateColor(String type)
        {
            switch (type)
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

        public override string ToString()
        {
            return "[Bus ID: " + busID.ToString() + ", Type: " + type + "] ";
        }

    }

}
