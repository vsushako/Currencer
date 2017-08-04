using System;
using WebApplication1.Repository;

namespace WebApplication1.Models
{
    public interface IRate
    {
        /// <summary>
        /// Ссылка на валюту
        /// </summary>
        ICurrency Currency { get; set; }
        
        /// <summary>
        /// Дата получения валюты
        /// </summary>
        DateTime Date { get; set; }

        /// <summary>
        /// Идентификатор записи
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// На сколько изменилась
        /// </summary>
        double RateChange { get; set; }

        /// <summary>
        /// Текущее значение
        /// </summary>
        double Value { get; set; }
    }
}