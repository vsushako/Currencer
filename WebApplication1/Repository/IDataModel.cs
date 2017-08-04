using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Repository
{
    public interface IDataModel
    {
        IRateRepository Rate { get; }
        ICurrencyRepository Currency { get; }
    }
}