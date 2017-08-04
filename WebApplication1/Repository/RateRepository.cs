using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    public class RateRepository : IRateRepository, IDisposable
    {
        private readonly SqlContext _context = new SqlContext();

        public async Task<Rate> Create(Guid currencyId, float value, DateTime date)
        {
            var rate = new Rate
            {
                СurrencyId = currencyId,
                Value = value,
                Date = date
            };
            _context.Rate.Add(rate);
            await _context.SaveChangesAsync();
            return rate;
        }

        public async void Remove(Rate rate)
        {
            _context.Rate.Remove(rate);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Rate> Get()
        {
            return _context.Rate;
        }

        public Rate Get(Guid id)
        {
            return _context.Rate.FirstOrDefault(r => r.Id == id);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}