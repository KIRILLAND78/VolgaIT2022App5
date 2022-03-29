using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VolgaIT2022App5.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using VolgaIT2022App5.Pages;
using VolgaIT2022App5.Views;

namespace VolgaIT2022App5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Apps()
        {
            return View();
        }
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult AppDetailedStatistics()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        
        public IActionResult Register()
        {
            return View();
        }
        
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}