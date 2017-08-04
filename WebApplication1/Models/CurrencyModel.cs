using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Repository;

namespace WebApplication1.Models
{
    public class CurrencyModel : ICurrencyModel
    {
        private readonly IDataModel _dataModel;

        public CurrencyModel(IDataModel dataModel)
        {
            _dataModel = dataModel;
        }


        public IQueryable<ICurrency> Get()
        {
            return _dataModel.Currency.Get();
        }


        public ICurrency Get(Guid id)
        {
            return _dataModel.Currency.Get(id);
        }

        public async Task<ICurrency> Create(string nameFrom, string nameTo, string codeFrom, string codeTo)
        {
            return await _dataModel.Currency.Create(nameFrom, nameTo, codeFrom, codeTo);
        }

        public async Task<ICurrency> Update(Guid id, string nameFrom, string nameTo, string codeFrom, string codeTo)
        {
            return await _dataModel.Currency.Update(id, nameFrom, nameTo, codeFrom, codeTo);
        }

        public async Task<int> Delete(Guid id)
        {
            return await _dataModel.Currency.Remove(id);
        }
    }
}