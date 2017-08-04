using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Repository;

namespace WebApplication1.Models
{
    public interface ICurrencyModel
    {
        /// <summary>
        /// Получает список валют
        /// </summary>
        /// <returns>Список всех валют</returns>
        IQueryable<ICurrency> Get();

        /// <summary>
        /// Получает валюту по идентификатору
        /// </summary>
        /// <param name="id">валюта</param>
        /// <returns></returns>
        ICurrency Get(Guid id);

        /// <summary>
        /// Создает запись валюты
        /// </summary>
        /// <param name="nameFrom">Имя базовой валюты</param>
        /// <param name="nameTo">Имя валюты назначения</param>
        /// <param name="codeFrom">Код базовой валюты</param>
        /// <param name="codeTo">Код валюты назначения</param>
        /// <returns></returns>
        Task<ICurrency> Create(string nameFrom, string nameTo, string codeFrom, string codeTo);

        /// <summary>
        /// ОБновляет данные валюты
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <param name="nameFrom">Имя базовой валюты</param>
        /// <param name="nameTo">Имя валюты назначения</param>
        /// <param name="codeFrom">Код базовой валюты</param>
        /// <param name="codeTo">Код валюты назначения</param>
        /// <returns></returns>
        Task<ICurrency> Update(Guid id, string nameFrom, string nameTo, string codeFrom, string codeTo);

        /// <summary>
        /// Удаляет данные валюты
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <returns></returns>
        Task<int> Delete(Guid id);
    }
}