using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ALMSamulfBank.Models;

namespace ALMSamulfBank.Controllers
{
    public class HomeController : Controller
    {
        public BankRepository BankRepo { get; set; }

        public HomeController()
        {
            BankRepo = new BankRepository();
            BankRepo.Mock();
        }

        public IActionResult Index()
        {
            return View(BankRepo);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
