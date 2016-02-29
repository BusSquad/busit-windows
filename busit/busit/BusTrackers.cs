using System;
using System.Net;
using System.Threading.Tasks;

/// <summary>
/// The async task responsible for contacting servers for bus tracker information
/// Defaults to json_request but will retrieve XML with GetBusTrackerDataAsync((int) 1)s
/// </summary>
namespace busit
{
    class BusTrackers
    {
        private string target;
        private static string json_request = "http://bts.ucsc.edu:8081/location/get";
        private static string xml_request = "http://skynet.cse.ucsc.edu/bts/coord2.xml";

        // GetBusTrackerDataAsync defaults to json_request
        // if no parameters given
        public async Task<string> GetBusTrackerDataAsync()
        {
            return await GetBusTrackerDataAsync(0);
        }

        public async Task<string> GetBusTrackerDataAsync(int arg)
        {
            switch (arg)
            {
                case 1:
                    target = xml_request;
                    break;
                case 0:
                default:
                    target = json_request;
                    break;
            }

            HttpClient client = new HttpClient();
            string response = await client.ExecuteAsync<string>(target);
            return response;
        }

    }
}
