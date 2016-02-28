using System;
using System.Net;
using System.Threading.Tasks;

namespace busit
{
    class BusTrackers
    {
        private Uri target;
        private static string json_request = "http://bts.ucsc.edu:8081/location/get";
        private static string xml_request = "http://skynet.cse.ucsc.edu/bts/coord2.xml";

        public async Task<string> GetBusTrackerDataAsync()
        {
            return await GetBusTrackerDataAsync(0);
        }

        public async Task<string> GetBusTrackerDataAsync(int arg)
        {
            switch (arg)
            {
                case 1:
                    target = new Uri(xml_request);
                    break;
                case 0:
                default:
                    target = new Uri(json_request);
                    break;
            }

            var client = new WebClient();
            string response = await client.DownloadStringTaskAsync(target);
            return response;
        }

    }
}
