using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
        private bool jsonFlag;
        private string target;
        private WebClient client;
        readonly string json_request = "http://bts.ucsc.edu:8081/location/get";
        readonly string xml_request = "http://skynet.cse.ucsc.edu/bts/coord2.xml";

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
                    jsonFlag = false;
                    break;
                case 0:
                default:
                    target = json_request;
                    jsonFlag = true;
                    break;
            }

            TaskCompletionSource<string> response = new TaskCompletionSource<string>();
            WebClient client = new WebClient();
            client.DownloadStringCompleted += (sender, e) =>
            {
                if (e.Error != null)
                {
                    response.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    response.TrySetCanceled();
                }
                else
                {
                    response.TrySetResult(e.Result);
                }
            };
            client.DownloadStringAsync(new Uri(target));
            return await response.Task;
        }

        public List<Bus> parseJson(string jAString)
        {
            JArray a = JArray.Parse(jAString);
            List<Bus> buses = JsonConvert.DeserializeObject<List<Bus>>(jsonString);
            return buses;
        }
    }
}
