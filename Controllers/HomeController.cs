using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLifeTime.Models;

namespace ServiceLifeTime.Controllers
{
    public class HomeController : Controller
    {
        private IUtilitySingleton _utilitySingleton;
        private IUtilitySingleton _utilitySingleton2;

        private IUtilityTransient _utilityTransient;
        private IUtilityTransient _utilityTransient2;

        private IUtilityScoped _utilityScoped;
        private IUtilityScoped _utilityScoped2;

        public HomeController(IUtilitySingleton utilitySingleton, IUtilitySingleton utilitySingleton2, IUtilityTransient utilityTransient, IUtilityTransient utilityTransient2, IUtilityScoped utilityScoped, IUtilityScoped utilityScoped2)
        {
            _utilitySingleton = utilitySingleton;
            _utilitySingleton2 = utilitySingleton2;

            _utilityTransient = utilityTransient;
            _utilityTransient2 = utilityTransient2;

            _utilityScoped = utilityScoped;
            _utilityScoped2 = utilityScoped2;
        }
        public IActionResult Index()
        {
            ViewBag.Singleton = _utilitySingleton;
            ViewBag.Singleton2 = _utilitySingleton2;

            ViewBag.Transient = _utilityTransient;
            ViewBag.Transient2 = _utilityTransient2;

            ViewBag.Scoped = _utilityScoped;
            ViewBag.Scoped2 = _utilityScoped2;

            return View();
        }
    }
}