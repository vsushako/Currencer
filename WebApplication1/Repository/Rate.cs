using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    [Table("Rate")]
    public class Rate : IRate
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey("CurrencyEntity")]
        [Column("currency_id")]
        public Guid СurrencyId { get; set; }

        [Column("value")]
        public double Value { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        public ICurrency Currency {
            get { return CurrencyEntity; }
            set { CurrencyEntity = value as Currency; }
        }

        /// <summary>
        /// Обертка для получения валюты
        /// </summary>
        public Currency CurrencyEntity { get; set; }
    }
}