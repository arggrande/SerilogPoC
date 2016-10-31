using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Serilog;

namespace SerilogPoc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Log.Information("Invoking Index() Action");
            ViewBag.Title = "Home Page";
            Log.Information("Finished Index() Action");
            return View();
        }
    }
}
