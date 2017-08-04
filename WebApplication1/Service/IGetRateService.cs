using System.Threading.Tasks;

namespace WebApplication1.Service
{
    /// <summary>
    /// Сервис получения курсов
    /// </summary>
    public interface IGetRateService
    {
        /// <summary>
        /// Метод получает курсы
        /// </summary>
        /// <param name="codeFrom">Код валюты с которой перевод</param>
        /// <param name="codeTo">Код валюты на которую перевод</param>
        /// <returns></returns>
        Task<float?> Get(string codeFrom, string codeTo);
    }
}