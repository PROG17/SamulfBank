using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ALMSamulfBank
{
    public class MailTrapSender
    {

        public static ResponseMessage Send(Customer customer)
        {
            ResponseMessage res = new ResponseMessage();

            MailMessage mail = new MailMessage("from@SamulfBank.com", "to@TestPerson.com", "Customer Info", BuildMessage(customer));
            mail.IsBodyHtml = true;

            var client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("9a132135408591", "e377ba7b96ed7d"),
                EnableSsl = true,
               
            };
            client.Send(mail);

            return res;
        }

        private static string BuildMessage(Customer customer)
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
