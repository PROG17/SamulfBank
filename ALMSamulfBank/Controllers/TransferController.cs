using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace ALMSamulfBank.Controllers
{
    public class TransferController : Controller
    {
        public IActionResult Index()
        {
            ResponseMessage Message = new ResponseMessage();
            return View(Message);
        }

        [HttpPost]
        public IActionResult Index(int FromAccountId, int ToAccountId, decimal Amount)
        {
            BankRepository bank = BankRepository.Instance;
            ResponseMessage Message = new ResponseMessage(); 

            var accFrom = bank.Accounts.Where(a => a.AccountNumber == FromAccountId).FirstOrDefault();
            var accTo = bank.Accounts.Where(a => a.AccountNumber == ToAccountId).FirstOrDefault();

            if(accFrom != null && accTo != null)
            {
                 Message = accFrom.TransferMoney(accTo, Amount);
                return View(Message);
            }
            else
            {
                Message.Success = false;
                Message.Message = "Något av kontona finns inte";
                return View(Message);
            }
            
        }
    }
}