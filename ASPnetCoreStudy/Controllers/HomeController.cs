using ASPnetCoreStudy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASPnetCoreStudy.Controllers
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
            var HongUser = new User
            {
                UserNo = 1,
                UserName = "홍길동"
            };

            // 1번째 방식: View(Model)
            //return View(HongUser);

            // 2번째 방식: ViewBag
            //ViewBag.User = HongUser;
            //return View();

            // 3번째 방식: ViewData
            ViewData["UserNo"] = HongUser.UserNo;
            ViewData["UserName"] = HongUser.UserName;
            return View();
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
