using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class CurrencyRepository : ICurrencyRepository, IDisposable
    {
        private readonly SqlContext _context = new SqlContext();

        public async Task<Currency> Create(string nameFrom, string nameTo, string codeFrom, string codeTo)
        {
            // Создаем сущность
            var currency = new Currency
            {
                NameFrom = nameFrom,
                NameTo = nameTo,
                CodeFrom = codeFrom,
                CodeTo = codeTo
            };

            // Сохраняем в БД
            _context.Currency.Add(currency);
            await _context.SaveChangesAsync();
            return currency;
        }

        public async Task<int> Remove(Guid id)
        {
            var currency = Get(id);
            _context.Currency.Remove(currency);
            return await _context.SaveChangesAsync();
        }

        public IQueryable<Currency> Get()
        {
            return _context.Currency;
        }

        public Currency Get(Guid id)
        {
            return _context.Currency.FirstOrDefault(c => c.Id == id);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<ICurrency> Update(Guid id, string nameFrom, string nameTo, string codeFrom, string codeTo)
        {
            var currency = Get(id);
            currency.NameFrom = nameFrom;
            currency.NameTo = nameTo;
            currency.CodeFrom = codeFrom;
            currency.CodeTo = codeTo;
            _context.Currency.AddOrUpdate(currency);
            await _context.SaveChangesAsync();
            return currency;
        }
    }
}