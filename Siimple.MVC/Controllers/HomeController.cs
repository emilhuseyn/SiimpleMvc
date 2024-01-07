using Microsoft.AspNetCore.Mvc;
using Siimple.BUSINESS.Services.Interfaces;
using Siimple.CORE.Models;
using Siimple.MVC.Models;
using System.Diagnostics;

namespace Siimple.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogService _blogService;
        public HomeController(ILogger<HomeController> logger, IBlogService blogService)
        {
            _logger = logger;
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _blogService.GetAllAsync();
            return View(values.ToList());
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