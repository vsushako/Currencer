using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    public interface IRateRepository
    {
        /// <summary>
        /// Список всех курсов
        /// </summary>
        /// <returns>список курсов</returns>
        IQueryable<Rate> Get();

        /// <summary>
        /// Определенный курс
        /// </summary>
        /// <param name="id">идентификатор курса</param>
        /// <returns>курс</returns>
        Rate Get(Guid id);

        /// <summary>
        /// Создание значения курса
        /// </summary>
        /// <param name="currencyId">Курс</param>
        /// <param name="value">Значение валюты</param>
        /// <param name="date">Дата получения</param>
        /// <returns>Курс</returns>
        Task<Rate> Create(Guid currencyId, float value, DateTime date);

        /// <summary>
        /// Удаление курса
        /// </summary>
        /// <param name="rate">Курс</param>
        void Remove(Rate rate);

    }
}