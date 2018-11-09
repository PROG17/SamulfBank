using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALMSamulfBank.Models;
using Microsoft.AspNetCore.Mvc;

namespace ALMSamulfBank.Controllers
{
    public class DepositWithdrawController : Controller
    {
        private BankRepository BankRepo = BankRepository.Instance;

        public IActionResult Index()
        {
            return View(BankRepo.Accounts);
        }

        [HttpPost]
        public async Task<IActionResult> Deposit(DWViewmodel model)
        {
            return View();
        }

        public async Task<IActionResult> Withdraw(DWViewmodel model)
        {
            return View();
        }

    }
}