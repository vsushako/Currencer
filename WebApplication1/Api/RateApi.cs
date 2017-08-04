using System;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Api
{
    /// <summary>
    /// Api для получения данных
    /// </summary>
    public class RateController : ApiController
    {
        private readonly IRateModel _model;

        public RateController(IRateModel model)
        {
            _model = model;
        }

        /// <summary>
        /// Список всех курсов
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            return Json(_model.Get());
        }

        /// <summary>
        /// Получает данные за определенный период
        /// </summary>
        /// <param name="dateBegin">Дата начала</param>
        /// <param name="dateEnd">Дата окончания</param>
        /// <returns></returns>
        public IHttpActionResult Get(DateTime dateBegin, DateTime dateEnd)
        {
            return Json(_model.Get(dateBegin, dateEnd));
        }

        /// <summary>
        /// Получает данные за определенный период
        /// </summary>
        /// <param name="dateBegin">Дата начала</param>
        /// <param name="dateEnd">Дата окончания</param>
        /// <param name="currency">Валюта</param>
        /// <returns></returns>
        public IHttpActionResult Get(DateTime dateBegin, DateTime dateEnd, string currency)
        {
            return Json(_model.Get(dateBegin, dateEnd, currency));
        }
    }
}