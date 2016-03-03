using Newtonsoft.Json;
using System;
using System.Windows.Media;

namespace busit
{

    class Bus
    {
        // local variables + GETTER-SETTERs
        [JsonProperty("id")]
        public int BusID { get; set; }

        [JsonProperty("lon")]
        public decimal Lon { get; set; }

        [JsonProperty("lat")]
        public decimal Lat { get; set; }

        [JsonProperty("type")]
        public String Type { get; set; }

        public Color BusColor { get { return getColor(); } }
        public String Direction { get; set; }


        // SETTERs
        // manual set route and direction 
        public void setRouteAndDirection(String type, String direction)
        {
            Direction = direction;
            Type = type;
        }

        // Sets color associated with bus based on route
        private Color getColor()
        {
            Color busColor;
            switch (Type)
            {
                case "UPPER CAMPUS":
                    busColor = Colors.Yellow;
                    break;
                // need to update based on direction
                // for inner or outer loop
                case "LOOP":
                    if (Direction == "INNER")
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
            return busColor;
        }

        public override string ToString()
        {
            return "[Bus ID: " + BusID.ToString() + ", Type: " + Type + "] ";
        }

    }

}
