using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Repository;

namespace WebApplication1.Models
{

    public class RateModel : IRateModel
    {
        private readonly IDataModel _dataModel;

        public RateModel(IDataModel dataModel)
        {
            _dataModel = dataModel;
        }

        public IQueryable<IRate> Get()
        {
            return _dataModel.Rate.Get().OrderByDescending(r => r.Date);
        }

        public IRate Get(Guid id)
        {
            return _dataModel.Rate.Get(id);
        }

        public IQueryable<IRate> Get(DateTime dateBegin, DateTime dateEnd)
        {
            return _dataModel.Rate.Get().Where(r => r.Date >= dateBegin && r.Date <= dateEnd).OrderByDescending(r => r.Date);
        }

        public async Task<IRate> Create(Guid currencyId, float value, DateTime date)
        {
            var previousRate = _dataModel.Rate.Get();
            
            var rateChange = 0;
         //   if (previousRate != null)
           //     rateChange = value - previousRate.value;

            return await _dataModel.Rate.Create(currencyId, value, date);
        }

        public IQueryable<IRate> Get(string currency)
        {
            var currencyEntity = _dataModel.Currency.Get().FirstOrDefault(c => c.CodeFrom + c.CodeTo == currency);
            if (currencyEntity == null)
                return Enumerable.Empty<IRate>().AsQueryable();

            var rateList = _dataModel.Rate.Get();
            return rateList.Where(r => r.СurrencyId == currencyEntity.Id)
                    .OrderByDescending(r => r.Date);
        }


        /// <returns></returns>
        public IQueryable<IRate> Get(DateTime dateBegin, DateTime dateEnd, string currency)
        {
            var currencyEntity = _dataModel.Currency.Get().FirstOrDefault(c => c.CodeFrom + c.CodeTo == currency);
            if (currencyEntity == null)
                return Enumerable.Empty<IRate>().AsQueryable();

            return
                _dataModel.Rate.Get()
                    .Where(
                        r =>
                            r.Date >= dateBegin && r.Date <= dateEnd &&
                            r.СurrencyId == currencyEntity.Id)
                    .OrderByDescending(r => r.Date);
        }
    }


}