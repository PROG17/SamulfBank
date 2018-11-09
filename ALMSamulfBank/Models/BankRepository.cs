using ALMSamulfBank.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMSamulfBank
{
    public class BankRepository
    {
        private static BankRepository instance;
        public List<Customer> Customers { get; set; }
        public List<Account>  Accounts  { get; set; }

        private BankRepository() {}

        public static BankRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BankRepository();
                    instance.Customers = new List<Customer>();
                    instance.Accounts = new List<Account>();
                    instance.Mock();
                }
                return instance;
            }
        }

        private BankRepository Mock()
        {
            this.Customers.Add(new Customer()
            {
                Id = 1,
                Name = "Samuel",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = 1000,
                        Balance       = 500m,
                        Owner         = "Samuel"    
                    },
                    new Account()
                    {
                        AccountNumber = 1001,
                        Balance       = 10m,
                        Owner         = "Samuel"
                    }
                }
            });

            this.Customers.Add(new Customer()
            {
                Id = 2,
                Name = "Olle",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = 1002,
                         Balance      = 1000m,
                         Owner        = "Olle"
                    },
                    new Account()
                    {
                        AccountNumber = 1003,
                        Balance       = 0m,
                        Owner        = "Olle"
                    }
                }
            });

            this.Customers.Add(new Customer()
            {
                Id = 3,
                Name = "Lisa",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = 1004,
                        Balance      = 100000m,
                        Owner        = "Lisa"
                    },
                    new Account()
                    {
                        AccountNumber = 1005,
                        Balance       = 500m,
                        Owner        = "Lisa"
                    }
                }
            });

            foreach (var cust in Customers)
            {
                foreach (var acc in cust.Accounts)
                {
                    Accounts.Add(acc);
                }
            }

            return this;
        }

        public ResponseMessage Withdraw(int accountNumber, decimal amount)
        {
            var responseMessage = new ResponseMessage();
            var account = Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();

            if (amount < 0)
            {
                responseMessage.Message = $"Amount can't be below 0";
            }
            else
            {
                if (account != null)
                {
                    if (account.Balance >= amount)
                    {
                        account.Balance -= amount;
                        responseMessage.Success = true;
                        responseMessage.Message = $"Successfull withdrawal. New balance on account {accountNumber}: {account.Balance}";
                    }
                    else
                    {
                        responseMessage.Message = $"Balance too low on Account {accountNumber}. Balance: {account.Balance}. Amount {amount}.";
                    }
                }
                else
                {
                    responseMessage.Message = $"Account with account number {accountNumber} not found";
                }
            }
           
            return responseMessage;
        }

        public ResponseMessage Deposit(int accountNumber, decimal amount)
        {
            var responseMessage = new ResponseMessage();
            var account = Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();

            if(amount < 0)
            {
                responseMessage.Message = $"Amount can't be below 0";
            }
            else
            {
                if (account != null)
                {
                    account.Balance += amount;
                    responseMessage.Success = true;
                    responseMessage.Message = $"Successfull deposit. New balance on account {accountNumber}: {account.Balance}";
                }
                else
                {
                    responseMessage.Message = $"Account with account number {accountNumber} not found";
                }
            }
            
            return responseMessage;
        }
    }
}
