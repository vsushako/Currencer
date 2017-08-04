using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using WebApplication1.Helpers;
using WebApplication1.Service;

namespace WebApplication1
{
    public class YahooapisRateGetter : IGetRateService
    {
        private readonly IHttpHelper _httpHelper;

        public YahooapisRateGetter(IHttpHelper helper)
        {
            _httpHelper = helper;
        }
        
        public async Task<float?> Get(string codeFrom, string codeTo)
        {
            var yahooapisUrl = ConfigurationManager.AppSettings["yahooapis.url"];
            var queryParams = new Dictionary<string, object>
            {
                {"q", $"select+*+from+yahoo.finance.xchange+where+pair+=+%22{codeFrom}{codeTo}%22"},
                {"format", "json"},
                {"env", "store%3A%2F%2Fdatatables.org%2Falltableswithkeys"}
            };

            // Получаем данные и серилизуем их
            var result = await _httpHelper.GetJson<YahooapisResponse>(yahooapisUrl, queryParams);
            return result.query?.results?.rate?.RateVal;
        }
    }
}