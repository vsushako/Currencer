namespace WebApplication1.Repository
{
    /// <summary>
    /// Обертка над классами репозитория для более простого доступа к ним
    /// </summary>
    public class DataModel : IDataModel
    {
        private IRateRepository _rate;
        private ICurrencyRepository _currency;

        public IRateRepository Rate => _rate ?? (_rate = new RateRepository());
        public ICurrencyRepository Currency => _currency ?? (_currency = new CurrencyRepository());
    }
}