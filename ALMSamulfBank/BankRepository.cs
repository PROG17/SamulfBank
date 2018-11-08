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
    }
}
