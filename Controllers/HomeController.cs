using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunningStats.Data;
using RunningStats.Models;
using System.Diagnostics;
using System.Linq;

namespace RunningStats.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RunningStatsContext _context;

        public HomeController(ILogger<HomeController> logger, RunningStatsContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var runningData = _context.RunningModel
                .OrderBy(entry => entry.Date.Year)
                .ThenBy(entry => entry.Date.Month)
                .ThenBy(entry => entry.Date.Day)
                .ToListAsync();

            return View(await runningData);
        }


    public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
