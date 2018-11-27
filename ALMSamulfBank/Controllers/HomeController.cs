using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ALMSamulfBank.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.DependencyInjection;

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
            var hej = "hej";
            var li = BankRepo.Customers.Where(p => p.Id == 3).FirstOrDefault();
            li.Name = "HoolaBandolaBella";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SendInfo(int id)
        {
            var customer = BankRepo.Customers.Where(c => c.Id == id).FirstOrDefault();
            if (customer != null)
            {
                EmailSender(customer);
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

        private void EmailSender(Customer customer)
        {
            using (var smtpClient = HttpContext.RequestServices.GetRequiredService<SmtpClient>())
            {
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress($"{_environment.EnvironmentName}.samulfbank@nackademin.se"),
                    Subject = $"MailTest({_environment.EnvironmentName}) - {customer.Name}",
                    Body = BuildMessage(customer),
                    IsBodyHtml = true
                };
                mail.To.Add("samuel.OlofssonJonsson@yh.nackademin.se");
                smtpClient.Send(mail);
            }
        }

        private string BuildMessage(Customer customer)
        {
            var row1 = $"<h3>Customer #{customer.Id}</h3>";
            var row2 = $"<h4>{customer.Name}</h4>";
            var row3 = $"<h4>Accounts ({customer.Accounts.Count()})</h4>";
            var accs = "";
            foreach (var item in customer.Accounts)
            {
                accs += $"<li>#{item.AccountNumber} Balance: {item.Balance} kr</li>";
            }
            var row4 = $"<ul>{accs}</ul>";

            return (row1 + row2 + row3 + row4);
        }
    }
}
