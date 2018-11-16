using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMSamulfBank
{
    public class Account
    {
        public int     AccountNumber { get; set; }
        public decimal Balance       { get; set; }
        public string  Owner         { get; set; }

        public ResponseMessage TransferMoney(Account AccountToTransferTo, decimal Amount)
        {
            ResponseMessage Message = new ResponseMessage();
            if (this.Balance >= Amount)
            {
                this.Balance -= Amount;
                AccountToTransferTo.Balance += Amount;
                
                Message.Success = true;
                Message.Message = "WOHO du lyckades";
                return Message;

            }
            else
            {
                Message.Success = false;
                Message.Message = "Klant Börja jobba";
                return Message;
            }
                   
        }
    }

   
}
