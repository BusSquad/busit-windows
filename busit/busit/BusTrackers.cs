//using System;
//using System.Diagnostics;
//using System.Net;
//using System.Threading.Tasks;
//using System.Windows;
//using WinPhoneExtensions;

//namespace busit
//{
//    class bustrackers
//    {
//        private static string json_request = "http://bts.ucsc.edu:8081/location/get";
//        private static string xml_request = "http://skynet.cse.ucsc.edu/bts/coord2.xml";

//        public async Task<string> GetBusTrackerDataAsync()
//        {
//            HttpWebRequest request = (HttpWebRequest)
//                WebRequest.Create(json_request);
//            request.Method = HttpMethod.Get;
//            request.Accept = "application/json;odata=verbose";

//            try
//            {
//                HttpWebResponse response = (HttpWebResponse)
//                    await request.GetResponseAsync();

//                Debug.WriteLine(response.ContentType);

//                // Read the response into a Stream object.
//                System.IO.Stream responseStream = response.GetResponseStream();
//                string data;
//                using (var reader = new System.IO.StreamReader(responseStream))
//                {
//                    data = reader.ReadToEnd();
//                }
//                responseStream.Close();

//                //var feed =
//                //    Newtonsoft.Json.JsonConvert.DeserializeObject<SupplierODataFeed>(data);
//                //SuppliersList.ItemsSource = feed.d.results;
//            }
//            catch (Exception ex)
//            {
//                var we = ex.InnerException as WebException;
//                if (we != null)
//                {
//                    var resp = we.Response as HttpWebResponse;
//                    var code = resp.StatusCode;
//                    MessageBox.Show("RespCallback Exception raised! Message:{0}" + we.Message);
//                    Debug.WriteLine("Status:{0}", we.Status);
//                }
//                else
//                    throw;
//            }
//        }
//    }
//}
//}
