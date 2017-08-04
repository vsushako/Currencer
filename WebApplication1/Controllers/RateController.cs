using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RateController : Controller
    {
        private readonly ICurrencyModel _currencyModel;


        public RateController(ICurrencyModel currencyModel)
        {
            _currencyModel = currencyModel;
        }

        [System.Web.Http.HttpGet]
        public ActionResult Index()
        {
            var currencyList = new SelectList(_currencyModel.Get().Select(c => c.CodeFrom + c.CodeTo));
            ViewBag.CurrencyList = currencyList;
            return View();
        }
    }
}
