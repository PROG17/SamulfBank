using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ALMSamulfBank.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ALMSamulfBank.Controllers
{
    public class HomeController : Controller
    {
        private BankRepository BankRepo = BankRepository.Instance;

        private IHostingEnvironment _environment;
        private readonly IConfiguration _config;

        public HomeController(IHostingEnvironment environment, IConfiguration config)
        {
            _environment = environment;
            _config = config;
        }

        public IActionResult Index()
        {
            var model = new BankViewModel();
            model.Bank = BankRepo;
            model.Env = _environment.EnvironmentName;
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            var li = BankRepo.Customers.Where(p => p.Id == 3).FirstOrDefault();
            li.Name = "HoolaBandolaBella";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SendInfo(int id)
        {
            var customer = BankRepo.Customers.Where(c => c.Id == id).FirstOrDefault();
            if(customer != null)
            {
                MailTrapSender.Send(customer);
            }

            return RedirectToAction("Index");
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
