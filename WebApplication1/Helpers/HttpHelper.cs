using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace WebApplication1.Helpers
{

    public class HttpHelper : IHttpHelper
    {

        public async Task<string> Get(string url, IEnumerable<KeyValuePair<string, object>> queryString = null)
        {
            var client = new WebClient();
            if (queryString != null)
                foreach (var query in queryString)
                    client.QueryString.Add(query.Key, query.Value.ToString());

            client.Encoding = Encoding.UTF8;
            return await
                client.DownloadStringTaskAsync(new Uri(url));
        }


        public async Task<IDictionary<string, object>> GetJson(string url, IEnumerable<KeyValuePair<string, object>> queryString = null)
        {
            var serializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
            return serializer.Deserialize<Dictionary<string, object>>(await Get(url, queryString));
        }


        public async Task<T> GetJson<T>(string url, IEnumerable<KeyValuePair<string, object>> queryString = null)
        {
            var result = await Get(url, queryString);
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(result)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(stream);
            }
        }
    }
}