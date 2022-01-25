using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Telewatch_proto
{
    public class Shared
    {
        public const string ServerLocation = "http://";

        public static string POST(string path, string json)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ServerLocation + path);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return result;
            }
        }

        public static async Task<string> GET(string path)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(ServerLocation + path);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
