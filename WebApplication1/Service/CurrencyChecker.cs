using System;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class CurrencyChecker : ICurrencyChecker
    {
        // Работа через модели, что бы была единая точка входа и при изменении места хранения только ее изменять
        private readonly IRateModel _rateModel;
        private readonly ICurrencyModel _currencyModel;
        private readonly IGetRateService _rateGetter;

        public CurrencyChecker(ICurrencyModel currencyMode, IRateModel rateModel, IGetRateService rateGetter)
        {
            _rateModel = rateModel;
            _currencyModel = currencyMode;
            _rateGetter = rateGetter;
        }

        public async void GetCurrensies()
        {
            var currencies = _currencyModel.Get();
            foreach (var currency in currencies)
            {
                try
                {
                    // Получаем данные
                    var result = await _rateGetter.Get(currency.CodeFrom, currency.CodeTo);
                    if (!result.HasValue)
                        continue;

                    //Создаем запись
                    await _rateModel.Create(currency.Id, result.Value, DateTime.Now);
                }
                // Если при запросе что то пошло не так, то по хорошему тут должна быть логика логирования
                catch
                {
                    continue;
                }
            }
        }
    }
}