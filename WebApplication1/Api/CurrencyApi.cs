using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Api
{
    /// <summary>
    /// Api для получения валют
    /// </summary>
    [RoutePrefix("currency")]
    public class CurrencyApi : ApiController
    {
        private readonly ICurrencyModel _model;

        public CurrencyApi(ICurrencyModel model)
        {
            _model = model;
        }

        /// <summary>
        /// Список всех валют
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            return Json(_model.Get());
        }
    }
}