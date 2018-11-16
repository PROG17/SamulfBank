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
        public async Task<ResponseMessage> Deposit(DWViewmodel model)
        {
            var response = BankRepo.Deposit(model.AccountNumber, model.Amount);
            return response;
        }

        public async Task<ResponseMessage> Withdraw(DWViewmodel model)
        {
            var response = BankRepo.Withdraw(model.AccountNumber, model.Amount);

            return response;
        }

        public async Task<Customer> ShowDetails(int accNo)
        {
            var customer = BankRepo.Customers.Where(c => c.Accounts.Any(a => a.AccountNumber == accNo)).FirstOrDefault();

            return customer;
        }
        public IActionResult TransferMoney()
        {
            return View();
        }
    }
}