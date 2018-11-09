using ALMSamulfBank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestBank
{
    [TestClass]
    public class UnitTestBankRepo
    {
        [TestMethod]
        public void MockTest()
        {
            var BankRepo = BankRepository.Instance;
            var expected = "Samuel";
            Assert.AreEqual(expected, BankRepo.Customers[0].Name);
        }

        [TestMethod]
        public void WithdrawSuccess()
        {
            //Singleton instance of BankRepository
            var BankRepo = BankRepository.Instance;

            //Get the account 
            int accountNo = 1000;
            var account = BankRepo.Accounts.Where(a => a.AccountNumber == accountNo).FirstOrDefault();

            //Set the amount of the account 
            account.Balance = 100m;
            
            //Withdraws 90, 10 remains.
            BankRepo.Withdraw(accountNo, 90m);
            decimal expected = 10m;
            decimal newBalance = account.Balance;

            Assert.AreEqual(expected, newBalance);
        }

        [TestMethod]
        public void WithdrawRollback()
        {
            //Singleton instance of BankRepository
            var BankRepo = BankRepository.Instance;

            //Get the account 
            int accountNo = 1000;
            var account   = BankRepo.Accounts.Where(a => a.AccountNumber == accountNo).FirstOrDefault();

            //Set the amount of the account 
            account.Balance = 100m;

            //Try to withdraws 200, fails and 100 still remains.
            BankRepo.Withdraw(accountNo, 200m);
            decimal expected   = 100m;
            decimal newBalance = account.Balance;

            Assert.AreEqual(expected, newBalance);
        }

        [TestMethod]
        public void DepositSuccess()
        {
            //Singleton instance of BankRepository
            var BankRepo = BankRepository.Instance;

            //Get the account 
            int accountNo = 1000;
            var account   = BankRepo.Accounts.Where(a => a.AccountNumber == accountNo).FirstOrDefault();

            //Set the amount of the account 
            account.Balance = 100m;

            //Deposit 90, balance is now 190.
            BankRepo.Deposit(accountNo, 90m);
            decimal expected   = 190m;
            decimal newBalance = account.Balance;

            Assert.AreEqual(expected, newBalance);
        }

        [TestMethod]
        public void WithdrawNegativeAmount()
        {
            //Singleton instance of BankRepository
            var BankRepo = BankRepository.Instance;

            //Get the account 
            int accountNo = 1000;
            var account = BankRepo.Accounts.Where(a => a.AccountNumber == accountNo).FirstOrDefault();

            //Set the amount of the account 
            account.Balance = 100m;

            //Deposit -100, balance should still be 100.
            BankRepo.Withdraw(accountNo, -100m);
            decimal expected = 100m;
            decimal newBalance = account.Balance;

            Assert.AreEqual(expected, newBalance);

        }

        [TestMethod]
        public void DepositNegativeAmount()
        {
            //Singleton instance of BankRepository
            var BankRepo = BankRepository.Instance;

            //Get the account 
            int accountNo = 1000;
            var account = BankRepo.Accounts.Where(a => a.AccountNumber == accountNo).FirstOrDefault();

            //Set the amount of the account 
            account.Balance = 100m;

            //Deposit -100, balance should still be 100.
            BankRepo.Deposit(accountNo, -100m);
            decimal expected = 100m;
            decimal newBalance = account.Balance;

            Assert.AreEqual(expected, newBalance);

        }
    }
}
