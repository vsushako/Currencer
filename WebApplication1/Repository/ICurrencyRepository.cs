using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    /// <summary>
    /// Методы для работы с источником данных 
    /// </summary>
    public interface ICurrencyRepository
    {
        /// <summary>
        /// Создание валюты
        /// </summary>
        /// <param name="nameFrom">Имя базовой валюты</param>
        /// <param name="nameTo">Имя валюты назначения</param>
        /// <param name="codeFrom">Код базовой валюты</param>
        /// <param name="codeTo">Код валюты назначения</param>
        /// <returns></returns>
        Task<Currency> Create(string nameFrom, string nameTo, string codeFrom, string codeTo);

        /// <summary>
        /// Удаление валюты
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        Task<int> Remove(Guid id);

        /// <summary>
        /// Получение валюты
        /// </summary>
        /// <returns>Список валюты</returns>
        IQueryable<Currency> Get();

        /// <summary>
        /// Получение валюты по id 
        /// </summary>
        /// <param name="id">Идентификатор валюты</param>
        /// <returns></returns>
        Currency Get(Guid id);

        /// <summary>
        /// обновление сущности валюты
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="nameFrom">Имя базовой валюты</param>
        /// <param name="nameTo">Имя валюты назначения</param>
        /// <param name="codeFrom">Код базовой валюты</param>
        /// <param name="codeTo">Код валюты назначения</param>
        /// <returns></returns>
        Task<ICurrency> Update(Guid id, string nameFrom, string nameTo, string codeFrom, string codeTo);
    }
}