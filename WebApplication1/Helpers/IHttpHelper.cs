using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Helpers
{
    /// <summary>
    /// Хелпер для создания http запросов
    /// </summary>
    public interface IHttpHelper
    {
        /// <summary>
        /// Метод получает данные по ссылке с определенными параметрами
        /// </summary>
        /// <param name="url">ссылка</param>
        /// <param name="queryString">Параметры запроса</param>
        /// <returns></returns>
        Task<string> Get(string url, IEnumerable<KeyValuePair<string, object>> queryString = null);

        /// <summary>
        /// Метод получает коллекцию ключ значение json
        /// </summary>
        /// <param name="url">ссылка</param>
        /// <param name="queryString">Параметры запроса</param>
        /// <returns></returns>
        Task<IDictionary<string, object>> GetJson(string url,
            IEnumerable<KeyValuePair<string, object>> queryString = null);

        /// <summary>
        /// Метод получает коллекцию ключ значение json
        /// </summary>
        /// <param name="url">ссылка</param>
        /// <param name="queryString">Параметры запроса</param>
        /// <returns></returns>
        Task<T> GetJson<T>(string url, IEnumerable<KeyValuePair<string, object>> queryString = null);

    }
}