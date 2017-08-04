using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly ICurrencyModel _model;

        public CurrencyController(ICurrencyModel model)
        {
            _model = model;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.CurrencyList = _model.Get();
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Show(Guid id)
        {
            ViewBag.Currency = _model.Get(id);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(string nameFrom, string nameTo, string codeFrom, string codeTo)
        {
            if (string.IsNullOrWhiteSpace(nameFrom))
                ModelState.AddModelError("nameFrom", "Поле имя базовой валюты обязательно для заполнения");

            if (string.IsNullOrWhiteSpace(nameTo))
                ModelState.AddModelError("nameTo", "Поле имя валюты назначения обязательно для заполнения");

            if (string.IsNullOrWhiteSpace(codeFrom))
                ModelState.AddModelError("codeFrom", "Поле код базовой валюты обязательно для заполнения");

            if (string.IsNullOrWhiteSpace(codeTo))
                ModelState.AddModelError("codeTo", "Поле код валюты назначения обязательно для заполнения");

            if (!ModelState.IsValid)
                return View();

            await _model.Create(nameFrom, nameTo, codeFrom, codeTo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(Guid id)
        {
            ViewBag.Currency = _model.Get(id);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Update(Guid id, string nameFrom, string nameTo, string codeFrom, string codeTo)
        {
            if (string.IsNullOrWhiteSpace(nameFrom))
                ModelState.AddModelError("nameFrom", "Поле имя базовой валюты обязательно для заполнения");

            if (string.IsNullOrWhiteSpace(nameTo))
                ModelState.AddModelError("nameTo", "Поле имя валюты назначения обязательно для заполнения");

            if (string.IsNullOrWhiteSpace(codeFrom))
                ModelState.AddModelError("codeFrom", "Поле код базовой валюты обязательно для заполнения");

            if (string.IsNullOrWhiteSpace(codeTo))
                ModelState.AddModelError("codeTo", "Поле код валюты назначения обязательно для заполнения");

            if (!ModelState.IsValid)
                return View();

            await _model.Update(id, nameFrom, nameTo, codeFrom, codeTo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _model.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
