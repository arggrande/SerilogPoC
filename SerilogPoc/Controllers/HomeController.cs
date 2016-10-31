using System.Web.Mvc;
using Serilog;

namespace SerilogPoc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger logger)
        {
            _logger = logger;
        }
        public ActionResult Index()
        {
            _logger.Information("Invoking Index() Action with injected logger");
            ViewBag.Title = "Home Page";
            _logger.Information("Finished Index() Action with injected logger");
            return View();
        }
    }
}
