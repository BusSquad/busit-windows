using System.Net;

namespace System.Threading.Tasks
{
    public class HttpClient
    {
        public async Task<T> ExecuteAsync<T>(string url)
        {
            var client = new WebClient();
            var response = await client.DownloadStringTaskAsync(new Uri(url));
            // TODO: Deserialize the response to T and return it
            return default(T);
        }
    }
}
