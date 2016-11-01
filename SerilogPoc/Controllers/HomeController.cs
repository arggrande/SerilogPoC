using System.Web.Mvc;
using Serilog;
using Serilog.Context;
using SerilogPoc.Data;

namespace SerilogPoc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly IPlayerService _playerService;

        public HomeController(ILogger logger, IPlayerService playerService)
        {
            _logger = logger;
            _playerService = playerService;
        }
        public ActionResult Index()
        {
            _logger.Information("Attempting to load all players.");
            ViewBag.Title = "Home Page";

            var players = _playerService.GetPlayers();
            
            if(players.Count > 0)
                _logger.Information("Found players");

            return View(players);
        }

        public ActionResult Player(string alias)
        {
            _logger.Information("Attempting to find player {alias}.", alias);
            var player = _playerService.GetPlayer(alias);
            if (player == null)
            {
                using (LogContext.PushProperty("PlayerCount", _playerService.GetPlayers().Count))
                    _logger.Warning("Player {alias} not found. Valid players include: {players}", alias, _playerService.GetPlayers());

                _logger.Information("Redirecting to Index Action");
                return RedirectToAction("Index");
            }

            _logger.Information("Player with alias {alias} found, with name {name}", alias, player.Name);
            return View(player);
        }
    }
}
