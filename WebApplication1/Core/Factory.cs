using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Core
{
    /// <summary>
    /// фабрика моделей
    /// </summary>
    public static class ModelFactory
    {
        private static readonly IDictionary<Type, Lazy<Type>> ModelInstances = new Dictionary<Type, Lazy<Type>>
        {
            {typeof(IRateModel), new Lazy<Type>(() => typeof(RateModel))},
            {typeof(ICurrencyModel), new Lazy<Type>(() => typeof(CurrencyModel))}
        };

        public static object GetModel(Type type)
        {
            if (!ModelInstances.ContainsKey(type))
                return null;

            var requestedType = ModelInstances[type].Value;
            var dataModel = new DataModel();
            return Activator.CreateInstance(requestedType, new object[] {dataModel});
        }
    }
}