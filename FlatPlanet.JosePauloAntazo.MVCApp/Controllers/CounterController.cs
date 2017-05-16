using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlatPlanet.JosePauloAntazo.MVCApp.ViewModel;
using FlatPlanet.JosePauloAntazo.MVCApp.DataProvider;

namespace FlatPlanet.JosePauloAntazo.MVCApp.Controllers
{
    public class CounterController : Controller
    {
        // GET: Counter
        private FlatPlanetEntities _dbcontext;

        public CounterController()
        {
            _dbcontext = new FlatPlanetEntities();


        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Counter()
        {
            var lastrecord = _dbcontext.Counters.OrderByDescending(x => x.Count).FirstOrDefault();
            var result = new CounterViewModel();
            if (lastrecord != null)
            {
                result.Count = lastrecord.Count.Value;
            }
            else
            {
                result.Count = 0;
            }
            return View(result);
        }

        [HttpPost]
        public ActionResult Counter(CounterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Count += 1;

            _dbcontext.Counters.Add(new Counter
            {
                Count = model.Count
            });
            _dbcontext.SaveChanges();

            return RedirectToAction("Counter");
        }
    }
}