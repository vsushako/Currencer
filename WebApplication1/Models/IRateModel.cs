using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    /// <summary>
    /// Модель для обработки курсовых значений
    /// </summary>
    public interface IRateModel
    {

        /// <summary>
        /// Получает список курсов
        /// </summary>
        /// <returns>Список всех курсов</returns>
        IQueryable<IRate> Get();

        /// <summary>
        /// Получает курс по идентификатору
        /// </summary>
        /// <param name="id">Курс</param>
        /// <returns></returns>IRate Get(Guid id);
        IRate Get(Guid id);


        /// <summary>
        /// Получает данные по курсам за определенный период
        /// </summary>
        /// <param name="dateBegin">Дата начала</param>
        /// <param name="dateEnd">Дата окончания</param>
        /// <returns>Список курсов</returns>
        IQueryable<IRate> Get(DateTime dateBegin, DateTime dateEnd);

        /// <summary>
        /// Создает запись курса
        /// </summary>
        /// <param name="currencyId">Идентификатор валюты</param>
        /// <param name="value">Значение</param>
        /// <param name="date">Дата</param>
        /// <returns></returns>
        Task<IRate> Create(Guid currencyId, float value, DateTime date);

        /// <summary>
        /// Полуает все курсы по валюте
        /// </summary>
        /// <param name="currency">курс</param>
        /// <returns></returns>
        IQueryable<IRate> Get(string currency);

        /// <summary>
        /// Получает данные по курсам за определенный период и валюту
        /// </summary>
        /// <param name="dateBegin">Дата начала</param>
        /// <param name="dateEnd">Дата окончания</param>
        /// <param name="currency">курс</param>
        IQueryable<IRate> Get(DateTime dateBegin, DateTime dateEnd, string currency);
    }
}