using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMSamulfBank
{
    public class BankRepository
    {
        public List<Customer> Customers { get; set; }

        public BankRepository()
        {
            Customers = new List<Customer>();
        }

        public BankRepository Mock()
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
                         Balance      = 500m
                    },
                    new Account()
                    {
                        AccountNumber = 1001,
                        Balance       = 10m
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
                         Balance      = 1000m
                    },
                    new Account()
                    {
                        AccountNumber = 1003,
                        Balance       = 0m
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
                         Balance      = 100000m
                    },
                    new Account()
                    {
                        AccountNumber = 1005,
                        Balance       = 500m
                    }
                }
            });

            return this;
        }
    }
}
